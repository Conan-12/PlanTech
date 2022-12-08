using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PlanTech.Modelo.Servicios
{
    public class Service_Usuario_Sesion
    {
        public string cadenaCnx;
        public MySqlConnection conexion;
        string server = "localhost";
        string database = "PlanTech";
        string user = "root";
        string password = "978607Ale";

        public Service_Usuario_Sesion()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=" + server + ";database=" + database + ";Uid=" + user + ";pwd=" + password + ";";
        }

        private bool AbrirConexion()
        {
            try
            {
                CerrarConexion();
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("No");
                        break;
                    case 1045:
                        MessageBox.Show("No");
                        break;
                }
                return false;
            }
        }

        private bool CerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Insertar(Usuario_Sesion usuario)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Usuario_Sesion (sesion) VALUES (@sesion)", conexion);

                    cmd.Parameters.AddWithValue("@nom_Usuario", usuario.Sesion);

                    cmd.ExecuteNonQuery();
                    this.CerrarConexion();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Actualizar(Usuario_Sesion usuario)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Usuario SET id_Usuario = @id_Usuario, sesion = @sesion where id_Usuario = @id_Usuario", conexion);

                    cmd.Parameters.AddWithValue("@id_Usuario", usuario.Id_usuario);
                    cmd.Parameters.AddWithValue("@sesion", usuario.Sesion);

                    cmd.ExecuteNonQuery();
                    this.CerrarConexion();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Usuario_Sesion SelectId(int id)
        {
            string query = "select * from Usuario_Sesion where id_usuario = '";
            query += id + "'";
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                Usuario_Sesion usuario = new Usuario_Sesion();
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    usuario.Id_usuario = Convert.ToInt32(dataReader["id_Usuario"]);
                    usuario.Sesion = Convert.ToByte(dataReader["sesion"]);

                    dataReader.Close();
                }
                catch (MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                    return null;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.StackTrace);
                    MessageBox.Show(ex2.Message);
                    return null;
                }
                this.CerrarConexion();
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public List<Usuario_Sesion> Select()
        {
            string query = "SELECT * FROM Usuario_Sesion";
            List<Usuario_Sesion> lista = new List<Usuario_Sesion>();
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Usuario_Sesion usuario = new Usuario_Sesion();

                        usuario.Id_usuario = Convert.ToInt32(dataReader["id_usuario"]);
                        usuario.Sesion = Convert.ToByte(dataReader["sesion"]);

                        lista.Add(usuario);
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                    return null;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.StackTrace);
                    MessageBox.Show(ex2.Message);
                    return null;
                }
                this.CerrarConexion();
                return lista;
            }
            else
            {
                return null;
            }
        }
    }
}
