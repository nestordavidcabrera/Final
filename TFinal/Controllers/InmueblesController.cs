using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Context;
using TFinal.Models;

namespace TFinal.Controllers
{
        public class InmueblesController : Controller
        {
            private readonly InmuebleContext _context;
            public InmueblesController(InmuebleContext context)
            {
                _context = context;
            }

            //GET: Inmuebles
            public async Task<IActionResult> Index()
            {
                return View(await _context.Inmuebles.ToListAsync());
            }

            // GET: Ventas/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null || _context.Inmuebles == null)
                {
                    return NotFound();
                }

                var inmueble = await _context.Inmuebles
                    .FirstOrDefaultAsync(m => m.id_inmueble == id);
                if (inmueble == null)
                {
                    return NotFound();
                }

                return View(inmueble);
            }


            // GET: Inmuebles/Create
            public IActionResult Create()
            {
                return View();
            }


            // POST: Inmuebles/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("id_inmueble,id_tipo_inmueble,desc_inmueble,ubic_inmueble,costo_inmueble")] Inmueble inmueble)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(inmueble);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(inmueble);
            }
            // GET: Inmuebles/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.Inmuebles == null)
                {
                    return NotFound();
                }

                var inmueble = await _context.Inmuebles.FindAsync(id);
                if (inmueble == null)
                {
                    return NotFound();
                }
                return View(inmueble);
            }
            // POST: Inmuebles/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("id_inmueble,id_tipo_inmueble,desc_inmueble,ubic_inmueble,costo_inmueble")] Inmueble inmueble)
            {
                if (id != inmueble.id_inmueble)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(inmueble);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!InmuebleExists(inmueble.id_inmueble))
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
                return View(inmueble);
            }
            // GET: Inmuebles/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.Inmuebles == null)
                {
                    return NotFound();
                }

                var inmueble = await _context.Inmuebles
                    .FirstOrDefaultAsync(m => m.id_inmueble == id);
                if (inmueble == null)
                {
                    return NotFound();
                }

                return View(inmueble);
            }

            // POST: Productos/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                if (_context.Inmuebles == null)
                {
                    return Problem("Entity set 'InmuebleContext.Inmueble'  is null.");
                }
                var inmueble = await _context.Inmuebles.FindAsync(id);
                if (inmueble != null)
                {
                    _context.Inmuebles.Remove(inmueble);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool InmuebleExists(int id)
            {
                return _context.Inmuebles.Any(e => e.id_inmueble == id);
            }
        }
}
