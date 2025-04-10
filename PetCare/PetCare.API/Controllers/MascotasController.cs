using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare.API.Data;
using PetCare.API.Models;

namespace PetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotasController : ControllerBase
    {
        private readonly PetDbContext _context;
        public MascotasController(PetDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascota>>> GetMascotas() => await _context.Mascotas.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> GetMascota(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            return mascota == null ? NotFound() : mascota;
        }

        [HttpPost]
        public async Task<ActionResult<Mascota>> PostMascota(Mascota mascota)
        {
            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMascota), new { id = mascota.IdMascota }, mascota);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascota(int id, Mascota mascota)
        {
            if (id != mascota.IdMascota) return BadRequest();
            _context.Entry(mascota).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null) return NotFound();
            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
