using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Challenge.Models;

namespace Challenge.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login(string UserName, string Password, int Usuario)
        {

            RepositorioAdmin r = new RepositorioAdmin();
            RepositorioAlumno ra = new RepositorioAlumno();
            if (Usuario == 1)
            {

                admin a = r.LoginAdmin(UserName, Password);
                if (a != null)
                {
                    Session["Admin"] = a;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewData["Mensaje"] = "Volver a ingresar un Usuario o contraseña valido ";
                    return RedirectToAction("Index", "Home");
                }
            }
            if (Usuario == 2)
            {
                Alumno a = ra.LoginAlumno(UserName, Password);
                if (a != null)
                {
                    Session["Alumno"] = a;
                    return RedirectToAction("Index", "Alumno");
                }
                else {
                    ViewData["Mensaje"] = "Volver a ingresar un Usuario o contraseña valido ";
                    return RedirectToAction("Index", "Home");
                }
            }



            return RedirectToAction("Index", "Home");
        }




        public ActionResult LogOut() {

            Session["Alumno"] = null;
            Session["Admin"] = null;

            return RedirectToAction("Index", "Home");
        }






    }
}