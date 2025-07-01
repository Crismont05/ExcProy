using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public List<Reporte> Ventas(string fechainicio, string fechafin)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Reporte()
                                {
                                    FechaVenta = dr["FechaVenta"].ToString(),
                                    NombredelProducto = dr["NombredelProducto"].ToString(),
                                    precio = Convert.ToDecimal(dr["precio"], new CultureInfo("es-PE")),
                                    cantidad = Convert.ToInt32(dr["cantidad"].ToString()),
                                    total = Convert.ToDecimal(dr["total"], new CultureInfo("es-PE"))
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }
            return lista;
        }

        public Dashboard VerDashboard()
        {
            Dashboard objeto = new Dashboard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_ReporteDashboard", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Dashboard()
                            {
                                TotalProductos = Convert.ToInt32(dr["TotalProductos"]),
                                TotalVentas = Convert.ToInt32(dr["TotalVentas"]),
                                TotalEntradas = Convert.ToInt32(dr["TotalEntradas"]),
                                TotalSalidas = Convert.ToInt32(dr["TotalSalidas"])
                            };
                        }
                    }
                }
            }
            catch
            {
                objeto = new Dashboard();
            }
            return objeto;
        }

    }
}
