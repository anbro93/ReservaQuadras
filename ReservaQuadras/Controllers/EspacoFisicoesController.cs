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
    public class EspacoFisicoesController : Controller
    {
        private readonly ReservaQuadraContext _context;

        public EspacoFisicoesController(ReservaQuadraContext context)
        {
            _context = context;
        }

        // GET: EspacoFisicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EspacoFisico.ToListAsync());
        }

        // GET: EspacoFisicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacoFisico = await _context.EspacoFisico
                .FirstOrDefaultAsync(m => m.EspacoFisicoID == id);
            if (espacoFisico == null)
            {
                return NotFound();
            }

            return View(espacoFisico);
        }

        // GET: EspacoFisicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EspacoFisicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EspacoFisicoID,Nome,IsLiberado")] EspacoFisico espacoFisico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(espacoFisico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(espacoFisico);
        }

        // GET: EspacoFisicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacoFisico = await _context.EspacoFisico.FindAsync(id);
            if (espacoFisico == null)
            {
                return NotFound();
            }
            return View(espacoFisico);
        }

        // POST: EspacoFisicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EspacoFisicoID,Nome,IsLiberado")] EspacoFisico espacoFisico)
        {
            if (id != espacoFisico.EspacoFisicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(espacoFisico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspacoFisicoExists(espacoFisico.EspacoFisicoID))
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
            return View(espacoFisico);
        }

        // GET: EspacoFisicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacoFisico = await _context.EspacoFisico
                .FirstOrDefaultAsync(m => m.EspacoFisicoID == id);
            if (espacoFisico == null)
            {
                return NotFound();
            }

            return View(espacoFisico);
        }

        // POST: EspacoFisicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var espacoFisico = await _context.EspacoFisico.FindAsync(id);
            _context.EspacoFisico.Remove(espacoFisico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspacoFisicoExists(int id)
        {
            return _context.EspacoFisico.Any(e => e.EspacoFisicoID == id);
        }
    }
}
