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
    public class HorariosController : Controller
    {
        private readonly ReservaQuadraContext _context;

        public HorariosController(ReservaQuadraContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.EspacoID = id;
            var reservaQuadraContext = _context.Horario.Where(hc => hc.EspacoFisicoID == id).Include(h => h.Dia).Include(h => h.EspacoFisico);
            return View(await reservaQuadraContext.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Dia)
                .Include(h => h.EspacoFisico)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create(int id)
        {
            ViewData["DiaID"] = new SelectList(_context.DiaDaSemana, "DiaDaSemanaID", "Dia");
            ViewData["EspacoFisicoID"] = id;

            ViewBag.HorariosInicio = new SelectList(HorasDoDia(), "Key", "Value");
            ViewBag.HorariosFim = new SelectList(HorasDoDia(), "Key", "Value");
            return View();
        }

        private Dictionary<TimeSpan, string> HorasDoDia()
        {
            var horariosDict = new Dictionary<TimeSpan, string>();
            horariosDict.Add(new TimeSpan(0, 0, 0), "00:00");
            horariosDict.Add(new TimeSpan(0, 30, 0), "00:30");
            return horariosDict;
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorarioID,DiaID,EspacoFisicoID,HoraInicio,HoraFim")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = horario.EspacoFisicoID });
            }
            ViewData["DiaID"] = new SelectList(_context.DiaDaSemana, "DiaDaSemanaID", "Dia", horario.DiaID);
            ViewData["EspacoFisicoID"] = horario.EspacoFisicoID;
            ViewBag.HorariosInicio = new SelectList(HorasDoDia(), "Key", "Value");
            ViewBag.HorariosFim = new SelectList(HorasDoDia(), "Key", "Value");
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["DiaID"] = new SelectList(_context.DiaDaSemana, "DiaDaSemanaID", "DiaDaSemanaID", horario.DiaID);
            ViewData["EspacoFisicoID"] = new SelectList(_context.EspacoFisico, "EspacoFisicoID", "Nome", horario.EspacoFisicoID);
            ViewBag.HorariosInicio = new SelectList(HorasDoDia(), "Key", "Value");
            ViewBag.HorariosFim = new SelectList(HorasDoDia(), "Key", "Value");

            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorarioID,DiaID,EspacoFisicoID,HoraInicio,HoraFim")] Horario horario)
        {
            if (id != horario.HorarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.HorarioID))
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
            ViewData["DiaID"] = new SelectList(_context.DiaDaSemana, "DiaDaSemanaID", "DiaDaSemanaID", horario.DiaID);
            ViewData["EspacoFisicoID"] = new SelectList(_context.EspacoFisico, "EspacoFisicoID", "Nome", horario.EspacoFisicoID);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Dia)
                .Include(h => h.EspacoFisico)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horario.FindAsync(id);
            var espacoID = horario.EspacoFisicoID;
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = espacoID });
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.HorarioID == id);
        }
    }
}
