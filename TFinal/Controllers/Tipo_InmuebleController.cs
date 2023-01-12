using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
    public class Tipo_InmuebleController : Controller
    {
        private readonly InmuebleContext _context;
        public Tipo_InmuebleController(InmuebleContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposInmuebles.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposInmuebles == null)
            {
                return NotFound();
            }

            var tipo_inmueble = await _context.TiposInmuebles
                .FirstOrDefaultAsync(m => m.id_tipo_inmueble == id);
            if (tipo_inmueble == null)
            {
                return NotFound();
            }

            return View(tipo_inmueble);
        }


        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipo_inmueble,desc_inmueble")] Tipo_Inmueble tipo_inmueble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_inmueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_inmueble);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposInmuebles == null)
            {
                return NotFound();
            }

            var tipo_inmueble = await _context.TiposInmuebles.FindAsync(id);
            if (tipo_inmueble == null)
            {
                return NotFound();
            }
            return View(tipo_inmueble);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tipo_inmueble,desc_inmueble")] Tipo_Inmueble tipo_inmueble)
        {
            if (id != tipo_inmueble.id_tipo_inmueble)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_inmueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_InmuebleExists(tipo_inmueble.id_tipo_inmueble))
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
            return View(tipo_inmueble);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposInmuebles == null)
            {
                return NotFound();
            }

            var tipo_inmueble = await _context.TiposInmuebles
                .FirstOrDefaultAsync(m => m.id_tipo_inmueble == id);
            if (tipo_inmueble == null)
            {
                return NotFound();
            }

            return View(tipo_inmueble);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposInmuebles == null)
            {
                return Problem("Entity set 'InmuebleContext.Tipo_Inmueble'  is null.");
            }
            var tipo_inmueble = await _context.TiposInmuebles.FindAsync(id);
            if (tipo_inmueble != null)
            {
                _context.TiposInmuebles.Remove(tipo_inmueble);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_InmuebleExists(int id)
        {
            return _context.TiposInmuebles.Any(e => e.id_tipo_inmueble == id);
        }
    }
}
