using System.ComponentModel.DataAnnotations;

namespace Proyecto_Cliente.Models
{
    public class CreateClientRequest
    {
        public int Id { get; set; }
        [Required]
        public string Rut { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
