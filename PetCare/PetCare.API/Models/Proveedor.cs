using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.API.Models
{
    /// <summary>
    /// Representa a un proveedor de productos veterinarios.
    /// </summary>
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        /// <summary>
        /// Productos suministrados por este proveedor.
        /// </summary>
        public ICollection<Producto> Productos { get; set; }
    }
}
