using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
    [Route("api/LogForma_PagoController")]
    [ApiController]
    public class LogForma_PagoController : ControllerBase
    {
        private readonly InmuebleContext _context;
        public LogForma_PagoController(InmuebleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Forma_Pago>>> GetForma_Pago()
        {
            return await _context.FormaPagos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Forma_Pago>> GetForma_Pago(int? id)
        {
            if (id == null || _context.FormaPagos == null)
            {
                return NotFound();
            }
            var forma_pago = await _context.FormaPagos
            .FirstOrDefaultAsync(m => m.id_forma_pago == id);
            if (id == null)
            {
                return NotFound();
            }
            return forma_pago;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutForma_Pago(int id, Forma_Pago forma_pago)
        {
            if (id != forma_pago.id_forma_pago)
            {
                return BadRequest();
            }
            _context.Entry(forma_pago).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagoExist(id))
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
        public async Task<ActionResult<Forma_Pago>> PostForma_Pago(Forma_Pago forma_pago)
        {
            _context.FormaPagos.Add(forma_pago);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetForma_Pago", new { id = forma_pago.id_forma_pago }, forma_pago);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Forma_Pago>> DeleteForma_Pago(int id)
        {
            var forma_pago = await _context.FormaPagos.FindAsync(id);
            if (forma_pago == null)
            {
                return NotFound();
            }
            _context.FormaPagos.Remove(forma_pago);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool FormaPagoExist(int id)
        {
            return _context.FormaPagos.Any(e => e.id_forma_pago == id);
        }
    }
}
