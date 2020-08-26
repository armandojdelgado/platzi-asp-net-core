using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace platzi_asp_net_core.Models
{
    public class EscuelaContext: DbContext
    {
        public DbSet<Escuela> Escuelas{get; set;}

        public DbSet<Asignatura> Asignaturas{get; set;}

        public DbSet<Alumno> Alumnos {get;set;}

        public DbSet<Curso> Cursos {get; set;}

        public DbSet<Evaluación> Evaluaciones{get; set;}

        public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Calle 70 # 13";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            modelBuilder.Entity<Escuela>().HasData(escuela);

            modelBuilder.Entity<Asignatura>().HasData(
                     new List<Asignatura>()
                    {
                        new Asignatura{Nombre="Matematicas",
                                        Id=Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Educación Física",
                                        Id=Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Español",
                                        Id=Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Ciencias Naturales",
                                        Id=Guid.NewGuid().ToString()
                        },
                        new Asignatura{Nombre="Programacion",
                                        Id=Guid.NewGuid().ToString()
                        }
                    });
                
                modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar().ToArray());

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
                                            Id = Guid.NewGuid().ToString()                                            
                                            };
            return listaAlumnos.OrderBy((al) => al.Id).ToList();
        }
    }
}