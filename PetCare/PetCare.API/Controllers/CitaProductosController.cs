using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare.API.Data;
using PetCare.API.Models;

namespace PetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaProductosController : ControllerBase
    {
        private readonly PetDbContext _context;
        public CitaProductosController(PetDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaProducto>>> GetCitaProductos() =>
            await _context.CitaProductos.Include(cp => cp.Cita).Include(cp => cp.Producto).ToListAsync();

        [HttpPost]
        public async Task<ActionResult<CitaProducto>> PostCitaProducto(CitaProducto cp)
        {
            _context.CitaProductos.Add(cp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCitaProductos), new { cp.IdCita, cp.IdProducto }, cp);
        }

        [HttpDelete("{idCita}/{idProducto}")]
        public async Task<IActionResult> DeleteCitaProducto(int idCita, int idProducto)
        {
            var cp = await _context.CitaProductos.FindAsync(idCita, idProducto);
            if (cp == null) return NotFound();
            _context.CitaProductos.Remove(cp);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
