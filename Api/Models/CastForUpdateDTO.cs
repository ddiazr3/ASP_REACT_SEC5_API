using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CastForUpdateDTO
    {
        private string ErrorMax = "Máximo de caracteres es 50";

        [Required (ErrorMessage ="Nombre es requerido *")]
        [StringLength(50, ErrorMessage = "Nombre es requerido *")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Máximo de caracteres es 50")]
        public string Character { get; set; }
    }
}
