using System.ComponentModel.DataAnnotations;

namespace Proyecto_Cliente.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Rut { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string Email { get; set; }
        [Required]
        public string Fecha_Alta { get; set; }

    }
}
