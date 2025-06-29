using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Venta
    {
        public List<Venta> Listar()
        {
            List<Venta> lista = new List<Venta>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT idVenta, idSalida, total FROM Ventas";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Venta()
                                {
                                    idVenta = Convert.ToInt32(dr["idVenta"]),
                                    idSalida = Convert.ToInt32(dr["idSalida"]),
                                    total = Convert.ToDecimal(dr["total"]),
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Venta>();
            }
            return lista;
        }
    }
}
