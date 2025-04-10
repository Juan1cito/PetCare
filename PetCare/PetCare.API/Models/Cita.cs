using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.API.Models
{
    /// <summary>
    /// Representa una cita médica para una mascota.
    /// </summary>
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public int IdMascota { get; set; }

        [Required]
        public int IdServicio { get; set; }

        /// <summary>
        /// Mascota que recibe el servicio en la cita.
        /// </summary>
        public Mascota Mascota { get; set; }

        /// <summary>
        /// Servicio veterinario aplicado en la cita.
        /// </summary>
        public Servicio Servicio { get; set; }

        /// <summary>
        /// Productos utilizados durante la cita.
        /// </summary>
        public ICollection<CitaProducto> CitaProductos { get; set; }
    }
}
