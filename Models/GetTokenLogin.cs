using System.ComponentModel.DataAnnotations;

namespace Proyecto_Cliente.Models
{
    public class GetTokenLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Clave { get; set; }

    }
}
