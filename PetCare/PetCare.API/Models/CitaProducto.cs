using System.ComponentModel.DataAnnotations;

namespace PetCare.API.Models
{
    /// <summary>
    /// Relación entre citas y productos utilizados en ellas.
    /// </summary>
    public class CitaProducto
    {
        [Required]
        public int IdCita { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public Cita Cita { get; set; }

        public Producto Producto { get; set; }
    }
}
