using Microsoft.EntityFrameworkCore;
using PetCare.API.Models;

namespace PetCare.API.Data
{
    /// <summary>
    /// Contexto de la base de datos para el sistema de gestión veterinaria PetCare.
    /// </summary>
    public class PetDbContext : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto</param>
        public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
        {
        }

        // DbSets: Definición de las tablas del sistema
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<CitaProducto> CitaProductos { get; set; }

        /// <summary>
        /// Configuración adicional del modelo y relaciones.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la clave primaria compuesta para la tabla intermedia CitaProducto
            modelBuilder.Entity<CitaProducto>()
                .HasKey(cp => new { cp.IdCita, cp.IdProducto });

            // Relaciones para CitaProducto
            modelBuilder.Entity<CitaProducto>()
                .HasOne(cp => cp.Cita)
                .WithMany(c => c.CitaProductos)
                .HasForeignKey(cp => cp.IdCita);

            modelBuilder.Entity<CitaProducto>()
                .HasOne(cp => cp.Producto)
                .WithMany(p => p.CitaProductos)
                .HasForeignKey(cp => cp.IdProducto);
        }
    }
}
