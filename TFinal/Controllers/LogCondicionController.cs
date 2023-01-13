using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
    [Route("api/LogCondicionController")]
    [ApiController]
    public class LogCondicionController : ControllerBase
    {
        private readonly InmuebleContext _context;
        public LogCondicionController(InmuebleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condicion>>> GetCondicion()
        {
            return await _context.Condiciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Condicion>> GetCondicion(int? id)
        {
            if (id == null || _context.Condiciones == null)
            {
                return NotFound();
            }
            var condicion = await _context.Condiciones
            .FirstOrDefaultAsync(m => m.id_condicion == id);
            if (id == null)
            {
                return NotFound();
            }
            return condicion;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondicion(int id, Condicion condicion)
        {
            if (id != condicion.id_condicion)
            {
                return BadRequest();
            }
            _context.Entry(condicion).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondicionExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Condicion>> PostVenta(Condicion condicion)
        {
            _context.Condiciones.Add(condicion);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCondicion", new { id = condicion.id_condicion }, condicion);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Condicion>> DeleteCondicion(int id)
        {
            var condicion = await _context.Condiciones.FindAsync(id);
            if (condicion == null)
            {
                return NotFound();
            }
            _context.Condiciones.Remove(condicion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CondicionExist(int id)
        {
            return _context.Condiciones.Any(e => e.id_condicion == id);
        }
    }
}
