using System;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System.Linq;

namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;

        public IActionResult Index()
        {
            
            //Instancia del Modelo
            var escuela = _context.Escuelas.FirstOrDefault();

            /*
            
            */

            return View(escuela);//Llama la vista Index
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}