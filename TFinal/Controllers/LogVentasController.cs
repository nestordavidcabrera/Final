using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
    public class LogVentasController : Controller
    {
        private readonly InmuebleContext _context;
        public LogVentasController(InmuebleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVenta()
        {
            return await _context.Ventas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }
            var venta = await _context.Ventas
            .FirstOrDefaultAsync(m => m.id_venta == id);
            if (id == null)
            {
                return NotFound();
            }
            return venta;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            if (id != venta.id_venta)
            {
                return BadRequest();
            }
            _context.Entry(venta).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExist(id))
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
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVenta", new { id = venta.id_venta }, venta);
        }
        private bool VentaExist(int id)
        {
            return _context.Ventas.Any(e => e.id_venta == id);
        }
    }
}
