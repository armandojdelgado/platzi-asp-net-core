using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View(new Asignatura{Nombre="Programacion",
                                        UniqueId=Guid.NewGuid().ToString()
                        });
        }

        public IActionResult MultiAsignatura()
        {
            //Instancia del Modelo
            var listaAsignaturas = new List<Asignatura>()
                    {
                        new Asignatura{Nombre="Matematicas",
                                        UniqueId=Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Educación Física",
                                        UniqueId=Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Español",
                                        UniqueId=Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Ciencias Naturales",
                                        UniqueId=Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Programacion",
                                        UniqueId=Guid.NewGuid().ToString()
                        }
                    };



            ViewBag.CosaDinamica = "La Monja"; //Dato dinamico
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAsignatura", listaAsignaturas);//Llama la vista Index
        }
    }
}