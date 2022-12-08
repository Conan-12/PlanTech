using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PlanTech.Modelo.Servicios
{
    public class Service_Grupo
    {
        public string cadenaCnx;
        public MySqlConnection conexion;
        string server = "localhost";
        string database = "PlanTech";
        string user = "root";
        string password = "978607Ale";

        public Service_Grupo()
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

        public bool Insertar(Grupo grupo)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Grupo (nombre, fecha) VALUES (@nombre, @fecha)", conexion);

                    cmd.Parameters.AddWithValue("@nombre", grupo.Nombre);
                    cmd.Parameters.AddWithValue("@fecha", grupo.Fecha);

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

        public bool Actualizar(Grupo grupo)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Grupo SET id_Grupo = @id_Grupo, nombre = @nombre, fecha = @fecha where id_Grupo = @id_Grupo", conexion);

                    cmd.Parameters.AddWithValue("@id_Grupo", grupo.Id_Grupo);
                    cmd.Parameters.AddWithValue("@nom_Grupo", grupo.Nombre);
                    cmd.Parameters.AddWithValue("@contraseña", grupo.Fecha);

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

        public Grupo SelectId(int id)
        {
            string query = "select * from Grupo where id_Grupo = '";
            query += id + "'";
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                Grupo grupo = new Grupo();
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    grupo.Id_Grupo = Convert.ToInt32(dataReader["id_Grupo"]);
                    grupo.Nombre = Convert.ToString(dataReader["nombre"]);
                    grupo.Fecha = Convert.ToDateTime(dataReader["fecha"]);

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
                return grupo;
            }
            else
            {
                return null;
            }
        }

        public List<Grupo> Select()
        {
            string query = "SELECT * FROM Grupo";
            List<Grupo> lista = new List<Grupo>();
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Grupo grupo = new Grupo();

                        grupo.Id_Grupo = Convert.ToInt32(dataReader["id_Grupo"]);
                        grupo.Nombre = Convert.ToString(dataReader["nombre"]);
                        grupo.Fecha = Convert.ToDateTime(dataReader["fecha"]);

                        lista.Add(grupo);
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
