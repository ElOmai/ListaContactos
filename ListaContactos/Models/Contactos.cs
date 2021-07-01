using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContactos.Models
{
    public class Contactos
    {
        [Key]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int ContactoId { get; set; }
        [Required,Phone(ErrorMessage = "Teléfono no puede estar vacío")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Nombre no puede estar vacío")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido no puede estar vacío")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La Direccion no puede estar vacía")]
        public string Direccion { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        public Contactos()
        {
            ContactoId = 0;
            Telefono = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
        }
    }
}
