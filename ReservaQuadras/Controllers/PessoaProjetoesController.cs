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
    public class PessoaProjetoesController : Controller
    {
        private readonly ReservaQuadraContext _context;

        public PessoaProjetoesController(ReservaQuadraContext context)
        {
            _context = context;
        }

        // GET: PessoaProjetoes
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.PessoaID = id;

            var reservaQuadraContext = _context.PessoaProjeto.Where(pp => pp.PessoaID == id).Include(p => p.Pessoa).Include(p => p.Projeto);
            return View(await reservaQuadraContext.ToListAsync());
        }

        // GET: PessoaProjetoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaProjeto = await _context.PessoaProjeto
                .Include(p => p.Pessoa)
                .Include(p => p.Projeto)
                .SingleOrDefaultAsync(m => m.PessoaProjetoID == id);
            if (pessoaProjeto == null)
            {
                return NotFound();
            }

            return View(pessoaProjeto);
        }

        // GET: PessoaProjetoes/Create
        public IActionResult Create(int id)
        {
            ViewData["PessoaID"] = id;
            ViewData["ProjetoID"] = new SelectList(_context.Projeto, "ProjetoID", "Nome"); ;
            return View();
        }

        // POST: PessoaProjetoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaProjetoID,PessoaID,ProjetoID")] PessoaProjeto pessoaProjeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaProjeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = pessoaProjeto.PessoaID });
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "PessoaID", "CPF", pessoaProjeto.PessoaID);
            ViewData["ProjetoID"] = pessoaProjeto.PessoaID;
            return View(pessoaProjeto);
        }

        // GET: PessoaProjetoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaProjeto = await _context.PessoaProjeto.SingleOrDefaultAsync(m => m.PessoaProjetoID == id);
            if (pessoaProjeto == null)
            {
                return NotFound();
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "PessoaID", "CPF", pessoaProjeto.PessoaID);
            ViewData["ProjetoID"] = new SelectList(_context.Projeto, "ProjetoID", "Nome", pessoaProjeto.ProjetoID);
            return View(pessoaProjeto);
        }

        // POST: PessoaProjetoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaProjetoID,PessoaID,ProjetoID")] PessoaProjeto pessoaProjeto)
        {
            if (id != pessoaProjeto.PessoaProjetoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaProjeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaProjetoExists(pessoaProjeto.PessoaProjetoID))
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
            ViewData["PessoaID"] = new SelectList(_context.Pessoas, "PessoaID", "CPF", pessoaProjeto.PessoaID);
            ViewData["ProjetoID"] = new SelectList(_context.Projeto, "ProjetoID", "Nome", pessoaProjeto.ProjetoID);
            return View(pessoaProjeto);
        }

        // GET: PessoaProjetoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaProjeto = await _context.PessoaProjeto
                .Include(p => p.Pessoa)
                .Include(p => p.Projeto)
                .SingleOrDefaultAsync(m => m.PessoaProjetoID == id);
            if (pessoaProjeto == null)
            {
                return NotFound();
            }

            return View(pessoaProjeto);
        }

        // POST: PessoaProjetoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaProjeto = await _context.PessoaProjeto.SingleOrDefaultAsync(m => m.PessoaProjetoID == id);
            int pessoaID = pessoaProjeto.PessoaID;
            _context.PessoaProjeto.Remove(pessoaProjeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = pessoaID });
        }

        private bool PessoaProjetoExists(int id)
        {
            return _context.PessoaProjeto.Any(e => e.PessoaProjetoID == id);
        }
    }
}
