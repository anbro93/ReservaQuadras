using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservaQuadras.Models;
using ReservaQuadras.Models.ViewModels;

namespace ReservaQuadras.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaQuadraContext _context;

        public ReservaController(ReservaQuadraContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var reservas = _context.Reserva.ToList();
            return View(reservas);
        }

        public IActionResult Create(int ID)
        {
            ViewBag.TipoID = ID;
            return View();
        }
    }
}