using System.ComponentModel.DataAnnotations;

namespace SistemaGestionEscolar.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        [StringLength(50)]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El autor es obligatorio.")]
        [StringLength(50)]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código ISBN es obligatorio.")]
        [StringLength(10)]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de publicación es obligatorio.")]
        public int AnioPublicacion { get; set; }
    }
}
