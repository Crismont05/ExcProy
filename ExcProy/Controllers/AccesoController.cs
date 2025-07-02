using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcProy.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string clave)
        {
            Usuario oUsuario = new Usuario();
            oUsuario = new CN_Usuario().Listar()
                .Where(u => u.usuario == usuario && u.clave == CN_Recursos.ConvertirSHA256(clave))
                .FirstOrDefault();

            if (oUsuario == null)
            {
                ViewBag.Error = "Usuario o contraseña no correcta";
                return View();
            }
            else
            {
                // Guarda el usuario y rol en la sesión
                Session["usuario"] = oUsuario.usuario;
                Session["rol"] = oUsuario.rol; 

                return RedirectToAction("Index", "Home");
            }
        }

    }
}