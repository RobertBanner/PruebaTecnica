﻿using System.ComponentModel.DataAnnotations;

namespace Proyecto_Cliente.Models
{
    public class UpdateClientRequest
    {
        public int Id { get; set; }
        public string? Rut { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
