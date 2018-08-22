using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservaQuadras.Models;

namespace ReservaQuadras.Controllers
{
    public class AtleticasController : Controller
    {
        private readonly ReservaQuadraContext _context;

        public AtleticasController(ReservaQuadraContext context)
        {
            _context = context;
        }

        // GET: Atleticas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atleticas.ToListAsync());
        }

        // GET: Atleticas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atletica = await _context.Atleticas
                .SingleOrDefaultAsync(m => m.AtleticaID == id);
            if (atletica == null)
            {
                return NotFound();
            }

            return View(atletica);
        }

        // GET: Atleticas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atleticas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtleticaID,Nome")] Atletica atletica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atletica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atletica);
        }

        // GET: Atleticas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atletica = await _context.Atleticas.SingleOrDefaultAsync(m => m.AtleticaID == id);
            if (atletica == null)
            {
                return NotFound();
            }
            return View(atletica);
        }

        // POST: Atleticas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtleticaID,Nome")] Atletica atletica)
        {
            if (id != atletica.AtleticaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atletica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtleticaExists(atletica.AtleticaID))
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
            return View(atletica);
        }

        // GET: Atleticas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atletica = await _context.Atleticas
                .SingleOrDefaultAsync(m => m.AtleticaID == id);
            if (atletica == null)
            {
                return NotFound();
            }

            return View(atletica);
        }

        // POST: Atleticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atletica = await _context.Atleticas.SingleOrDefaultAsync(m => m.AtleticaID == id);
            _context.Atleticas.Remove(atletica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtleticaExists(int id)
        {
            return _context.Atleticas.Any(e => e.AtleticaID == id);
        }
    }
}
