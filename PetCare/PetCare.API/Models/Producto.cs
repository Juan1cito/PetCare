using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.API.Models
{
    /// <summary>
    /// Representa un producto disponible en la veterinaria.
    /// </summary>
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        public int? IdProveedor { get; set; }

        /// <summary>
        /// Proveedor del producto.
        /// </summary>
        public Proveedor Proveedor { get; set; }

        /// <summary>
        /// Citas en las que se ha utilizado este producto.
        /// </summary>
        public ICollection<CitaProducto> CitaProductos { get; set; }
    }
}
