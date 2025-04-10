using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.API.Models
{
    /// <summary>
    /// Representa un servicio veterinario ofrecido por PetCare.
    /// </summary>
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        /// <summary>
        /// Citas que utilizan este servicio.
        /// </summary>
        public ICollection<Cita> Citas { get; set; }
    }
}
