using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Challenge.Models;

namespace Challenge.Views.Admin
{
    public class AlumnoController : Controller
    {
        RepositorioAdmin r = new RepositorioAdmin();
        RepositorioAlumno ra = new RepositorioAlumno();
        // GET: Alumno
        public ActionResult Index()
        {
            if (Session["Alumno"] != null)
            {
                Alumno a  = (Alumno)Session["Alumno"];

                return View(r.ListaMateria(a.id));
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
       public ActionResult CrearAlumno()
        {

            return View();
        }


        [HttpPost]
        public ActionResult CrearAlumno(Alumno a)
        {

            if (ModelState.IsValid)
            {
                RepositorioAdmin r = new RepositorioAdmin();
                if (r.AltaAlumno(a))
                {
                    TempData["mensaje1"] = "Alta Existosa";
                        return RedirectToAction("Index","Home",null);
                    }

                TempData["mensaje2"] = "Ya existe un usuario con el Dni o los datos no son correctos.";
            }

                return View(a);
            }
        public ActionResult Inscribirse(int id)
        {
            if (Session["Alumno"] != null)
            {

                return View(r.BuscarMateriaPorId(id));

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RealizarInscripcion(int id)
        {
            if (Session["Alumno"] != null)
            {
                Alumno a = (Alumno)Session["Alumno"];
                if (ra.Inscribirse(id, a.id))
                {
                    TempData["mensaje1"] = "Inscripto con exito";
                    return RedirectToAction("Index", "Alumno");

                }
                else
                {
                    TempData["Mensaje"] = "Los Horarios Coinciden o ya estas registrado en la materia";
                    return RedirectToAction("Index", "Alumno");
                }


            }
            return RedirectToAction("Index", "Home");

        }


        public ActionResult ListadoMateriasInscripto()
        {
            if (Session["Alumno"] != null)
            {
                Alumno a = (Alumno)Session["Alumno"];

                return View(ra.ListaMateriasInscripto(a.id));
            }
            return RedirectToAction("Index", "Home");

        }


     
        public ActionResult EliminarInscripcion(int id) {

            if (Session["Alumno"] != null)
            {
                Alumno a = (Alumno)Session["Alumno"];

                ra.EliminarInscripcion(id, a.id);
                return RedirectToAction("ListadoMateriasInscripto", ra.ListaMateriasInscripto(a.id));
              
            }
            return RedirectToAction("Index", "Home");

        }



    }

       
}
