using System.ComponentModel.DataAnnotations;

namespace SistemaGestionEscolar.Models
{
    public class Asignatura
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la asignatura es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El codigo es obligatorio.")]
        [StringLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las horas semanales son obligatorias.")]
        [Range(1,50)]
        public int HorasSemanales { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; } = string.Empty;
    }
}