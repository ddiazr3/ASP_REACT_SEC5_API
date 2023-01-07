using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CastForCreationDTO
    {
        private string ErrorMax = "Máximo de caracteres es 50";

        [Required (ErrorMessage ="Nombre es requerido *")]
        [StringLength(50, ErrorMessage = "Nombre es requerido *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Character es requerido *")]
        [StringLength(50, ErrorMessage = "Máximo de caracteres es 50")]
        public string Character { get; set; }
    }
}
