using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
    [Route("api/LogTipo_InmuebleController")]
    [ApiController]
    public class LogTipo_InmuebleController : ControllerBase
    {
        private readonly InmuebleContext _context;
        public LogTipo_InmuebleController(InmuebleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo_Inmueble>>> GetTipo_Inmueble()
        {
            return await _context.TiposInmuebles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo_Inmueble>> GetTipo_Inmueble(int? id)
        {
            if (id == null || _context.TiposInmuebles == null)
            {
                return NotFound();
            }
            var tipo_inmueble = await _context.TiposInmuebles
            .FirstOrDefaultAsync(m => m.id_tipo_inmueble == id);
            if (id == null)
            {
                return NotFound();
            }
            return tipo_inmueble;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo_Inmueble(int id, Tipo_Inmueble tipo_inmueble)
        {
            if (id != tipo_inmueble.id_tipo_inmueble)
            {
                return BadRequest();
            }
            _context.Entry(tipo_inmueble).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_InmuebleExist(id))
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
        public async Task<ActionResult<Tipo_Inmueble>> PostTipo_Inmueble(Tipo_Inmueble tipo_inmueble)
        {
            _context.TiposInmuebles.Add(tipo_inmueble);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTipo_Inmueble", new { id = tipo_inmueble.id_tipo_inmueble }, tipo_inmueble);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tipo_Inmueble>> DeleteTipo_Inmueble(int id)
        {
            var tipo_inmueble = await _context.TiposInmuebles.FindAsync(id);
            if (tipo_inmueble == null)
            {
                return NotFound();
            }
            _context.TiposInmuebles.Remove(tipo_inmueble);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool Tipo_InmuebleExist(int id)
        {
            return _context.TiposInmuebles.Any(e => e.id_tipo_inmueble == id);
        }
    }
}
