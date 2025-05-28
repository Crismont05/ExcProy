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
    public class CD_Proveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT * FROM Proveedores";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Proveedor()
                                {
                                    idProveedor = Convert.ToInt32(dr["idProveedor"]),
                                    nombres = dr["nombres"].ToString(),
                                    apellidos = dr["apellidos"].ToString(),
                                    nombreORG = dr["nombreORG"].ToString(),
                                    estado = Convert.ToBoolean(dr["estado"])
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Proveedor>();
            }
            return lista;
        }
        public bool Eliminar(int id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from Proveedores where idProveedor = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
