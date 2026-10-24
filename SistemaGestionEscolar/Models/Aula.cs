using System.ComponentModel.DataAnnotations;

namespace SistemaGestionEscolar.Models
{
    public class Aula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del aula es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La capacidad es obligatoria.")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        [StringLength(100)]
        public string Ubicacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El codigo es obligatorio.")]
        [StringLength(10)]
        public string Codigo { get; set; } = string.Empty;
    }
}