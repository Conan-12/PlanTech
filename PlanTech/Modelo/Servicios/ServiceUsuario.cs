using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PlanTech.Modelo.Servicios
{
    public class ServiceUsuario
    {
        public string cadenaCnx;
        public MySqlConnection conexion;
        string server = "localhost";
        string database = "PlanTech";
        string user = "root";
        string password = "978607Ale";

        public ServiceUsuario()
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

        public bool Insertar(Usuario usuario)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Usuario (nom_Usuario, contraseña) VALUES (@nom_Usuario, @contraseña)", conexion);

                    cmd.Parameters.AddWithValue("@nom_Usuario", usuario.Nom_Usuario);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);

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

        public bool Actualizar(Usuario usuario)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Usuario SET id_Usuario = @id_Usuario, nom_Usuario = @nom_Usuario, contraseña = @contraseña where id_Usuario = @id_Usuario", conexion);

                    cmd.Parameters.AddWithValue("@id_Usuario", usuario.Id_Usuario);
                    cmd.Parameters.AddWithValue("@nom_Usuario", usuario.Nom_Usuario);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);

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

        public Usuario SelectId(int id)
        {
            string query = "select * from Usuario where id_Usuario = '";
            query += id + "'";
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                Usuario usuario = new Usuario();
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    usuario.Id_Usuario = Convert.ToInt32(dataReader["id_Usuario"]);
                    usuario.Nom_Usuario = Convert.ToString(dataReader["nom_Usuario"]);
                    usuario.Contraseña = Convert.ToString(dataReader["contraseña"]);

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

        public List<Usuario> Select()
        {
            string query = "SELECT * FROM Usuario";
            List<Usuario> lista = new List<Usuario>();
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Usuario usuario = new Usuario();

                        usuario.Id_Usuario = Convert.ToInt32(dataReader["id_Usuario"]);
                        usuario.Nom_Usuario = Convert.ToString(dataReader["nom_Usuario"]);
                        usuario.Contraseña = Convert.ToString(dataReader["contraseña"]);

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
