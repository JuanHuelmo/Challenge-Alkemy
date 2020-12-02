using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Challenge.Models;

namespace Challenge.Controllers
{
    public class AdminController : Controller
    {
       
        RepositorioAdmin r = new RepositorioAdmin();
        // GET: Admin
        public ActionResult Index()
        {
            if(Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult GestionProfesores() {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public ActionResult CrearDocente()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult CrearDocente(Profesor p)
        {
            if (Session["Admin"] != null)
            {
                if (ModelState.IsValid)
                {
                    RepositorioAdmin r = new RepositorioAdmin();
                    if (r.AltaProfesor(p))
                    {
                        return RedirectToAction("Index");
                    }


                }

                return View(p);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult ModificarDocente()
        {

            if (Session["Admin"] != null) { 
                ViewBag.Lista = r.ListaProfesores();

            return View();
        }
        return RedirectToAction("Index", "Home");
    }

        [HttpPost]
        public ActionResult ModificarDocente(int idDocente)
        {
            if (Session["Admin"] != null)
            {
                if (idDocente >= 0)
                {
                    Profesor p = r.BuscarProfesorPorId(idDocente);
                    return View(p);
                }
                else
                {
                    return RedirectToAction("ModificarDocente");
                }
            }
            return RedirectToAction("Index", "Home");
        }

      
         
        [HttpPost]
        public ActionResult GuardarModificacion(Profesor p)
        {
            if (Session["Admin"] != null)
            {

                r.ModificarProfesor(p);
                TempData["Mensaje"] = "Profesor " + p.Name + " " + p.Lastname + " Modificado";
                return RedirectToAction("ModificarDocente");
            }
            return RedirectToAction("Index", "Home");

        }




        public ActionResult Materias()
        {
            if (Session["Admin"] != null)
            {


                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult CrearMateria()
        {

            if (Session["Admin"] != null)
            {
                ViewBag.Lista = r.ListaProfesoresActivos();
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CrearMateria(Materia m,int idDocente)
        {
            if (Session["Admin"] != null)
            {

     
                if (r.AltaMateria(m,idDocente))
                {
                    
                    TempData["Mensaje"] = "Creada materia " + m.Name;
                    return RedirectToAction("Index");
                }

                ViewBag.Lista = r.ListaProfesoresActivos();
                return View();
            }
            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public ActionResult ModificarMateria()
        {
            if (Session["Admin"] != null) {

                ViewBag.Lista = r.ListaMateria(null);

            return View();
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult ModificarMateria(int idMateria)
        {
            if (Session["Admin"] != null)
            {
                if (idMateria >= 0)
                {
                    ViewBag.ListaProfesor = r.ListaProfesoresActivos();
                    Materia m = r.BuscarMateriaPorId(idMateria);
                    return View(m);
                }
                else
                {
                    return RedirectToAction("ModificarMateria");
                }
            }

            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public ActionResult GuardarModificacionMateria(Materia m,int idDocente)
        {
            if (Session["Admin"] != null) {
                m.Professor = r.BuscarProfesorPorId(idDocente);
                r.ModificarMateria(m);
            TempData["Mensaje"] = "Materia modificada " ;
            return RedirectToAction("ModificarMateria");
                 }

            return RedirectToAction("Index", "Home");
        }



    }
}