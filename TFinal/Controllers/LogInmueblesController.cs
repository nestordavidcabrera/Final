using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
    public class LogInmueblesController : Controller
    {
        private readonly InmuebleContext _context;
        public LogInmueblesController(InmuebleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inmueble>>> GetInmueble()
        {
            return await _context.Inmuebles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inmueble>> GetInmueble(int? id)
        {
            if (id == null || _context.Inmuebles == null)
            {
                return NotFound();
            }
            var inmueble = await _context.Inmuebles
            .FirstOrDefaultAsync(m => m.id_inmueble == id);
            if (id == null)
            {
                return NotFound();
            }
            return inmueble;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInmueble(int id, Inmueble inmueble)
        {
            if (id != inmueble.id_inmueble)
            {
                return BadRequest();
            }
            _context.Entry(inmueble).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InmuebleExist(id))
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
        public async Task<ActionResult<Inmueble>> PostInmueble(Inmueble inmueble)
        {
            _context.Inmuebles.Add(inmueble);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetInmueble", new { id = inmueble.id_inmueble }, inmueble);
        }
        private bool InmuebleExist(int id)
        {
            return _context.Inmuebles.Any(e => e.id_inmueble == id);
        }
    }
}
