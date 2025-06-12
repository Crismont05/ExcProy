using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcProy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inventario()
        {
            return View();
        }
        public ActionResult Ventas()
        { 
            return View();
        }
        public ActionResult Reportes()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }

        public JsonResult ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            lista = new CN_Usuario().Listar();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}