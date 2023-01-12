using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
    public class CondicionController : Controller
    {
        private readonly InmuebleContext _context;
        public CondicionController(InmuebleContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Condiciones.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Condiciones == null)
            {
                return NotFound();
            }

            var condicion = await _context.Condiciones
                .FirstOrDefaultAsync(m => m.id_condicion == id);
            if (condicion == null)
            {
                return NotFound();
            }

            return View(condicion);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_condicion,desc_condicion")] Condicion condicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condicion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condicion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Condiciones == null)
            {
                return NotFound();
            }

            var condicion = await _context.Condiciones.FindAsync(id);
            if (condicion == null)
            {
                return NotFound();
            }
            return View(condicion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_condicion,desc_condicion")] Condicion condicion)
        {
            if (id != condicion.id_condicion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condicion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondicionExists(condicion.id_condicion))
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
            return View(condicion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Condiciones == null)
            {
                return NotFound();
            }

            var condicion = await _context.Condiciones
                .FirstOrDefaultAsync(m => m.id_condicion == id);
            if (condicion == null)
            {
                return NotFound();
            }

            return View(condicion);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Condiciones == null)
            {
                return Problem("Entity set 'InmuebleContext.Condicion'  is null.");
            }
            var condicion = await _context.Condiciones.FindAsync(id);
            if (condicion != null)
            {
                _context.Condiciones.Remove(condicion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondicionExists(int id)
        {
            return _context.Condiciones.Any(e => e.id_condicion == id);
        }
    }
}
