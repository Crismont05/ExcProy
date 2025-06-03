using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT * FROM Usuarios WHERE estado = 1";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario()
                                {
                                    idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    usuario = dr["usuario"].ToString(),
                                    nombres = dr["nombres"].ToString(),
                                    apellidos = dr["apellidos"].ToString(),
                                    clave = dr["clave"].ToString(),
                                    rol = dr["rol"].ToString(),
                                    estado = Convert.ToBoolean(dr["estado"])
                                });
                        }
                    }
                }
            }
            catch 
            {
                lista = new List<Usuario>();
            }
            return lista;   
        }
        public int Registrar(Usuario obj, out string mensaje)
        {
            int id = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn)) 
                { 
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion );
                    cmd.Parameters.AddWithValue("Usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("Nombres", obj.nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.apellidos);
                    cmd.Parameters.AddWithValue("Clave", obj.clave);
                    cmd.Parameters.AddWithValue("Rol", obj.rol);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; 

                    oconexion.Open();

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
        public bool Editar(Usuario obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("idUsuario", obj.idUsuario);
                    cmd.Parameters.AddWithValue("Usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("Nombres", obj.nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.apellidos);
                    cmd.Parameters.AddWithValue("Clave", obj.clave);
                    cmd.Parameters.AddWithValue("Rol", obj.rol);
                    cmd.Parameters.AddWithValue("Estado", obj.estado);
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
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET estado = 0 WHERE idUsuario = @id", oconexion);
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
