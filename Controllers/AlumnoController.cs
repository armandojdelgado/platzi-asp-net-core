using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View(new Alumno{Nombre="adg",
                                        UniqueId=Guid.NewGuid().ToString()
                        });
        }

        public IActionResult MultiAlumno()
        {
            //Instancia del Modelo
            var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.CosaDinamica = "La Monja"; //Dato dinamico
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno", listaAlumnos);//Llama la vista Index
        }

         private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Donald", "Alvaro", "Nicolas" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murthy", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            //se realiza una combinatoria con arreglos
            //Linq lenguaje envevido de consulta
            var listaAlumnos = from n1 in nombre1 //Por cada nombre 1 se combinara con nombre 2 y se combinara con apellido1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { 
                                            Nombre = $"{n1} {n2} {a1}",
                                            UniqueId = Guid.NewGuid().ToString()                                            
                                            };
            return listaAlumnos.OrderBy((al) => al.UniqueId).ToList();
        }
    }
}