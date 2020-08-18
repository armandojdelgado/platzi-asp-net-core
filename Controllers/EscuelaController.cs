using System;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            //Instancia del Modelo
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";

            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Calle 70 # 13";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            ViewBag.CosaDinamica = "La Monja"; //Dato dinamico

            return View(escuela);//Llama la vista Index
        }
    }
}