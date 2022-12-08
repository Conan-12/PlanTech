using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PlanTech.Modelo.Servicios
{
    public class Service_Planta
    {
        public string cadenaCnx;
        public MySqlConnection conexion;
        string server = "localhost";
        string database = "PlanTech";
        string user = "root";
        string password = "978607Ale";

        public Service_Planta()
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

        public bool Insertar(Planta planta)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Planta (id_Especie, fecha) VALUES (@id_Especie, @fecha)", conexion);

                    cmd.Parameters.AddWithValue("@id_Especie", planta.Id_Especie);
                    cmd.Parameters.AddWithValue("@fecha", planta.Fecha);

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

        public bool Actualizar(Planta planta)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Planta SET id_Planta = @id_Planta, id_Especie = @id_Especie, fecha = @fecha where id_Planta = @id_Planta", conexion);

                    cmd.Parameters.AddWithValue("@id_Planta", planta.Id_Planta);
                    cmd.Parameters.AddWithValue("@id_Especie", planta.Id_Especie);
                    cmd.Parameters.AddWithValue("@fecha", planta.Fecha);

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

        public Planta SelectId(int id)
        {
            string query = "select * from Planta where id_Planta = '";
            query += id + "'";
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                Planta planta = new Planta();
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    planta.Id_Planta = Convert.ToInt32(dataReader["id_Planta"]);
                    planta.Id_Especie = Convert.ToInt32(dataReader["id_Especie"]);
                    planta.Fecha = Convert.ToDateTime(dataReader["fecha"]);

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
                return planta;
            }
            else
            {
                return null;
            }
        }

        public List<Planta> Select()
        {
            string query = "SELECT * FROM Planta";
            List<Planta> lista = new List<Planta>();
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Planta planta = new Planta();

                        planta.Id_Planta = Convert.ToInt32(dataReader["id_Planta"]);
                        planta.Id_Especie = Convert.ToInt32(dataReader["id_Especie"]);
                        planta.Fecha = Convert.ToDateTime(dataReader["fecha"]);

                        lista.Add(planta);
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
