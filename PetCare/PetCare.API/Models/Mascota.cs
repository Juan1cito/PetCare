using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCare.API.Models
{
    /// <summary>
    /// Representa a una mascota registrada en el sistema.
    /// </summary>
    public class Mascota
    {
        [Key]
        public int IdMascota { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Especie { get; set; }

        [MaxLength(50)]
        public string Raza { get; set; }

        public int Edad { get; set; }

        [Required]
        public int IdCliente { get; set; }

        /// <summary>
        /// Cliente propietario de la mascota.
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Citas médicas relacionadas con esta mascota.
        /// </summary>
        public ICollection<Cita> Citas { get; set; }
    }
}
