using System.ComponentModel.DataAnnotations;

namespace SistemaGestionEscolar.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10)]
        public string Cedula { get; set; } = string.Empty;
    }
}