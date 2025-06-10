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
    public class CD_Existencia
    {
        public List<Existencia> Listar()
        {
            List<Existencia> lista = new List<Existencia>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT idExistencia, idInventario, idProducto, cantidad FROM Existencias";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Existencia()
                                {
                                    idExistencia = Convert.ToInt32(dr["idEntrada"]),
                                    idInventario = Convert.ToInt32(dr["idInventario"]),
                                    idProducto = Convert.ToInt32(dr["idProducto"]),
                                    stock = Convert.ToInt32(dr["cantidad"])
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Existencia>();
            }
            return lista;
        }
    }
}
