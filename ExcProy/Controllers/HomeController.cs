using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcProy.Controllers
{
    public class HomeController : Controller
    {
        //Vistas
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
        public ActionResult Productos()
        {
            return View();
        }
        public ActionResult Proveedores()
        {
            return View();
        }
        //Usuarios
        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            lista = new CN_Usuario().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarUsuario(Usuario obj)
        {
            object result;
            string mensaje = string.Empty;
            if (obj.idUsuario == 0)
            {
                result = new CN_Usuario().Registrar(obj, out mensaje);
            }
            else
            {
                result = new CN_Usuario().Editar(obj, out mensaje);
            }
            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool result = false;
            string mensaje = string.Empty;

            result = new CN_Usuario().Eliminar(id, out mensaje);

            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        //Proveedores
        [HttpGet]
        public JsonResult ListarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            lista = new CN_Proveedor().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarProveedor(Proveedor obj)
        {
            object result;
            string mensaje = string.Empty;
            if (obj.idProveedor == 0)
            {
                result = new CN_Proveedor().Registrar(obj, out mensaje);
            }
            else
            {
                result = new CN_Proveedor().Editar(obj, out mensaje);
            }
            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarProveedor(int id)
        {
            bool result = false;
            string mensaje = string.Empty;

            result = new CN_Proveedor().Eliminar(id, out mensaje);

            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        //Productos
        [HttpGet]
        public JsonResult ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            lista = new CN_Producto().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarProducto(Producto obj)
        {
            object result;
            string mensaje = string.Empty;
            if (obj.idProducto == 0)
            {
                result = new CN_Producto().Registrar(obj, out mensaje);
            }
            else
            {
                result = new CN_Producto().Editar(obj, out mensaje);
            }
            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool result = false;
            string mensaje = string.Empty;

            result = new CN_Producto().Eliminar(id, out mensaje);

            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        //Existencias
        [HttpGet]
        public JsonResult ListarExistencias()
        {
            List<Existencia> lista = new List<Existencia>();
            lista = new CN_Existencia().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        //Entradas
        [HttpGet]
        public JsonResult ListarEntradas()
        {
            List<Entrada> lista = new List<Entrada>();
            lista = new CN_Entrada().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarEntrada(Entrada obj)
        {
            object result;
            string mensaje = string.Empty;
            if (obj.idEntrada == 0)
            {
                result = new CN_Entrada().Registrar(obj, out mensaje);
            }
            else
            {
                result = new CN_Entrada().Editar(obj, out mensaje);
            }
            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarEntrada(int id)
        {
            bool result = false;
            string mensaje = string.Empty;

            result = new CN_Entrada().Eliminar(id, out mensaje);

            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        //Salida
        [HttpGet]
        public JsonResult ListarSalidas()
        {
            List<Salida> lista = new List<Salida>();
            lista = new CN_Salida().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarSalida(Salida obj)
        {
            object result;
            string mensaje = string.Empty;
            if (obj.idSalida == 0)
            {
                result = new CN_Salida().Registrar(obj, out mensaje);
            }
            else
            {
                result = new CN_Salida().Editar(obj, out mensaje);
            }
            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarSalida(int id)
        {
            bool result = false;
            string mensaje = string.Empty;

            result = new CN_Salida().Eliminar(id, out mensaje);

            return Json(new { resultado = result, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaReporte(string fechainicio, string fechafin)
        {
            List<Reporte> olista = new List<Reporte>();

            olista = new CN_Reporte().Ventas(fechainicio, fechafin);

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult VistaDashboard()
        {
            Dashboard objeto = new CN_Reporte().VerDashboard();
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public FileResult ExportarVenta(string fechainicio, string fechafin)
        {
            List<Reporte> lista = new List<Reporte>();
            lista = new CN_Reporte().Ventas(fechainicio, fechafin);

            DataTable dt = new DataTable();

            dt.Locale = new CultureInfo("es-ES");
            dt.Columns.Add("FechaVenta", typeof(string));
            dt.Columns.Add("NombredelProducto", typeof(string));
            dt.Columns.Add("precio", typeof(decimal));
            dt.Columns.Add("cantidad", typeof(int));
            dt.Columns.Add("total", typeof(decimal));

            foreach (Reporte item in lista)
            {
                dt.Rows.Add( new object[]
                {
                    item.FechaVenta,
                    item.NombredelProducto,
                    item.precio,
                    item.cantidad,
                    item.total
                });
            }

            dt.TableName = "Datos";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    byte[] content = stream.ToArray();
                    string fileName = $"ReporteVentas_{fechainicio}_{fechafin}.xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }
    }
}

