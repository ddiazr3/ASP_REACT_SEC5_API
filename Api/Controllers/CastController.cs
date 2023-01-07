using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId}/casts")]
    public class CastController : ControllerBase
    {
        private ILogger<CastController> _logger;
        private IMailService _localMailService;

        /**
         * Estos servicios inyectados tienen que star configurados el Program.cs*
         */
        public CastController(ILogger<CastController> logger, IMailService mailService) {
           _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           _localMailService = mailService ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        public IActionResult GetCasts(int movieId)
        {
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                return NotFound();
            }

           return Ok(movie.Casts);
        }

        [HttpGet("{id}", Name = "GetCast")]
        public IActionResult GetCast(int movieId, int id)
        {

            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                return NotFound();
            }

            var cast = movie.Casts.FirstOrDefault(x => x.Id == id);

            if (cast == null)
            {
                _localMailService.send("404", "Recurso No encontrado");
                _logger.LogInformation($"El cast con el id {id} no fue encontrado");
                return NotFound();
            }

            return Ok(cast);
        }

        //Aqui por ende va a tomar la siguiente ruta solo que en POST api/movies/{movieId}/casts
        [HttpPost]
        public IActionResult CreateCast(int movieId, CastForCreationDTO castForCreationDTO) {

            /**
             * Esto es para agregar un error personalizado libre al del Modelo DTO
             */
            if (castForCreationDTO.Name == castForCreationDTO.Character)
            {
                ModelState.AddModelError(
                     "Name",
                     "El Nombre debe ser distinto al character"
                    );

                return BadRequest(ModelState);
            }

            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                return NotFound();
            }
            
            int count = movie.Casts?.Count?? 0;

            var newCast = new CastDTO
            {
                Id = count + 1,
                Name = castForCreationDTO.Name,
                Character = castForCreationDTO.Character,
            };

            movie.Casts.Add(newCast);

           return CreatedAtRoute(
               nameof(GetCast),
               new { movieId , id = newCast.Id},
               castForCreationDTO
               );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCast(int movieId,int id, CastForUpdateDTO castForUpdateDTO)
        {
            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                return NotFound();
            }

            var castFromStore = movie.Casts.FirstOrDefault(x => x.Id == movieId);

            if (castFromStore == null)
            {
                return NotFound();
            }

            castFromStore.Name = castForUpdateDTO.Name;
            castFromStore.Character = castForUpdateDTO.Character;

            //NoContent = No retorna nada porque el consumidor ya tiene data solo un 204 que ya fue actualizado
            return NoContent();
        }

        [HttpPatch]
        public IActionResult PartialUpdateCast(int movieId, int id, JsonPatchDocument<CastForUpdateDTO> jsonPatchDocument)
        {

            var movie = MoviesDataStore.Current.Movies.FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                return NotFound();
            }

            var castFromStore = movie.Casts.FirstOrDefault(x => x.Id == movieId);

            if (castFromStore == null)
            {
                return NotFound();
            }

            var castToPatch = new CastForUpdateDTO()
            {
                Name = castFromStore.Name,
                Character= castFromStore.Character,
            };

            //AplayTo sirve para poder agregar al objeto lo que nos llega
            //jsonPatchDocument.ApplyTo(castToPatch, ModelState);

            //NoContent = No retorna nada porque el consumidor ya tiene data solo un 204 que ya fue actualizado
            return NoContent();
        }
    }
}
