using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
    public class Forma_PagoController : Controller
    {
        private readonly InmuebleContext _context;
        public Forma_PagoController(InmuebleContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaPagos.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormaPagos == null)
            {
                return NotFound();
            }

            var forma_pago = await _context.FormaPagos
                .FirstOrDefaultAsync(m => m.id_forma_pago == id);
            if (forma_pago == null)
            {
                return NotFound();
            }

            return View(forma_pago);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_forma_pago,desc_fprma_pago")] Forma_Pago forma_pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forma_pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forma_pago);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormaPagos == null)
            {
                return NotFound();
            }

            var forma_Pago = await _context.FormaPagos.FindAsync(id);
            if (forma_Pago == null)
            {
                return NotFound();
            }
            return View(forma_Pago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("if_forma_pago,desc_forma_pago")] Forma_Pago forma_pago)
        {
            if (id != forma_pago.id_forma_pago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forma_pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPagoExists(forma_pago.id_forma_pago))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(forma_pago);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormaPagos == null)
            {
                return NotFound();
            }

            var forma_Pago = await _context.FormaPagos
                .FirstOrDefaultAsync(m => m.id_forma_pago == id);
            if (forma_Pago == null)
            {
                return NotFound();
            }

            return View(forma_Pago);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormaPagos == null)
            {
                return Problem("Entity set 'InmuebleContext.Forma_Pago'  is null.");
            }
            var forma_Pago = await _context.FormaPagos.FindAsync(id);
            if (forma_Pago != null)
            {
                _context.FormaPagos.Remove(forma_Pago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPagoExists(int id)
        {
            return _context.FormaPagos.Any(e => e.id_forma_pago == id);
        }
    }
}
