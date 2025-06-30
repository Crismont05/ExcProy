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
    public class CD_Entrada
    {
        public List<Entrada> Listar()
        {
            List<Entrada> lista = new List<Entrada>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT idEntrada, idInventario, idProducto, cantidad, fecha FROM Entradas";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Entrada()
                                {
                                    idEntrada = Convert.ToInt32(dr["idEntrada"]),
                                    idInventario = Convert.ToInt32(dr["idInventario"]),
                                    idProducto = Convert.ToInt32(dr["idProducto"]),
                                    cantidad = Convert.ToInt32(dr["cantidad"]),
                                    fecha = Convert.ToDateTime(dr["fecha"]),
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Entrada>();
            }
            return lista;
        }
        public int Registrar(Entrada obj, out string mensaje)
        {
            int id = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEntrada", oconexion);
                    cmd.Parameters.AddWithValue("idInventario", obj.idInventario);
                    cmd.Parameters.AddWithValue("idProducto", obj.idProducto);
                    cmd.Parameters.AddWithValue("Cantidad", obj.cantidad);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                id = 0;
                mensaje = ex.Message;
            }
            return id;
        }
        public bool Editar(Entrada obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarInventario", oconexion);
                    cmd.Parameters.AddWithValue("idEntrada", obj.idEntrada);
                    cmd.Parameters.AddWithValue("idInventario", obj.idInventario);
                    cmd.Parameters.AddWithValue("idProducto", obj.idProducto);
                    cmd.Parameters.AddWithValue("Cantidad", obj.cantidad);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }
        public bool Eliminar(int id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                CD_Entrada obj1 = new CD_Entrada();
                Entrada oEntrada = obj1.Listar().Where(e => e.idEntrada == id).FirstOrDefault();
                if (oEntrada == null) 
                {
                    mensaje = "Entrada no encontrada";
                    return false;
                }
                CD_Existencia obj2 = new CD_Existencia();
                Existencia oExistencia = obj2.Listar().Where(e => e.idInventario == oEntrada.idInventario && e.idProducto == oEntrada.idProducto).FirstOrDefault();

                int stockActual = oExistencia.stock;
                int stockDespuesElimninacion = stockActual - oEntrada.cantidad;
                if(stockDespuesElimninacion < 0)
                {
                    mensaje = "No se puede eliminar esta entrada porque no hay suficientes productos en stock. Considere eliminar una salida o editar una entrada";
                    return false;
                }

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarEntrada", oconexion);
                    cmd.Parameters.AddWithValue("idEntrada", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
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
