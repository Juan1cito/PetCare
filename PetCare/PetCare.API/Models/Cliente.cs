using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.API.Models
{
    /// <summary>
    /// Representa a un cliente de la veterinaria PetCare.
    /// </summary>
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        /// <summary>
        /// Relación con las mascotas del cliente.
        /// </summary>
        public ICollection<Mascota> Mascotas { get; set; }
    }
}
