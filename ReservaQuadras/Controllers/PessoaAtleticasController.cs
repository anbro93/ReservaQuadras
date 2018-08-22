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
    public class PessoaAtleticasController : Controller
    {
        private readonly ReservaQuadraContext _context;

        public PessoaAtleticasController(ReservaQuadraContext context)
        {
            _context = context;
        }

        // GET: PessoaAtleticas
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.PessoaID = id;

            var reservaQuadraContext = _context.PessoaAtleticas.Where(pa => pa.PessoaID == id).Include(p => p.Atletica).Include(p => p.Pessoa);
            return View(await reservaQuadraContext.ToListAsync());
        }

        // GET: PessoaAtleticas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaAtletica = await _context.PessoaAtleticas
                .Include(p => p.Atletica)
                .Include(p => p.Pessoa)
                .SingleOrDefaultAsync(m => m.PessoaAtleticaID == id);
            if (pessoaAtletica == null)
            {
                return NotFound();
            }

            return View(pessoaAtletica);
        }

        // GET: PessoaAtleticas/Create
        public IActionResult Create(int id)
        {
            ViewData["AtleticaID"] = new SelectList(_context.Atleticas, "AtleticaID", "Nome");
            ViewData["PessoaID"] = id;
            return View();
        }

        // POST: PessoaAtleticas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaAtleticaID,PessoaID,AtleticaID")] PessoaAtletica pessoaAtletica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaAtletica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PessoaAtleticas", new { id = pessoaAtletica.PessoaID });
            }
            ViewData["AtleticaID"] = new SelectList(_context.Atleticas, "AtleticaID", "Nome", pessoaAtletica.AtleticaID);
            ViewData["PessoaID"] = pessoaAtletica.PessoaID;
            return View(pessoaAtletica);
        }

        // GET: PessoaAtleticas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaAtletica = await _context.PessoaAtleticas.SingleOrDefaultAsync(m => m.PessoaAtleticaID == id);
            if (pessoaAtletica == null)
            {
                return NotFound();
            }
            ViewData["AtleticaID"] = new SelectList(_context.Atleticas, "AtleticaID", "Nome", pessoaAtletica.AtleticaID);
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "PessoaID", "CPF", pessoaAtletica.PessoaID);
            return View(pessoaAtletica);
        }

        // POST: PessoaAtleticas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaAtleticaID,PessoaID,AtleticaID")] PessoaAtletica pessoaAtletica)
        {
            if (id != pessoaAtletica.PessoaAtleticaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaAtletica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaAtleticaExists(pessoaAtletica.PessoaAtleticaID))
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
            ViewData["AtleticaID"] = new SelectList(_context.Atleticas, "AtleticaID", "Nome", pessoaAtletica.AtleticaID);
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "PessoaID", "CPF", pessoaAtletica.PessoaID);
            return View(pessoaAtletica);
        }

        // GET: PessoaAtleticas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaAtletica = await _context.PessoaAtleticas
                .Include(p => p.Atletica)
                .Include(p => p.Pessoa)
                .SingleOrDefaultAsync(m => m.PessoaAtleticaID == id);
            if (pessoaAtletica == null)
            {
                return NotFound();
            }

            return View(pessoaAtletica);
        }

        // POST: PessoaAtleticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaAtletica = await _context.PessoaAtleticas.SingleOrDefaultAsync(m => m.PessoaAtleticaID == id);
            var pessoaID = pessoaAtletica.PessoaID;
            _context.PessoaAtleticas.Remove(pessoaAtletica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = pessoaID });
        }

        private bool PessoaAtleticaExists(int id)
        {
            return _context.PessoaAtleticas.Any(e => e.PessoaAtleticaID == id);
        }
    }
}
