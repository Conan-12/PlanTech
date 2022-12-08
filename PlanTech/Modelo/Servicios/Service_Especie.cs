using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PlanTech.Modelo.Servicios
{
    public class Service_Especie
    {
        public string cadenaCnx;
        public MySqlConnection conexion;
        string server = "localhost";
        string database = "PlanTech";
        string user = "root";
        string password = "978607Ale";

        public Service_Especie()
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

        public bool Insertar(Especie especie)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Especie (nom, temp, horas_luz, humedad) VALUES (@nom, @temp, @horas_luz, @humedad)", conexion);

                    cmd.Parameters.AddWithValue("@nom", especie.Nom);
                    cmd.Parameters.AddWithValue("@temp", especie.Temp);
                    cmd.Parameters.AddWithValue("@horas_luz", especie.Horas_luz);
                    cmd.Parameters.AddWithValue("@humedad", especie.Humedad);

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

        public bool Actualizar(Especie especie)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Especie SET id_Especie = @id_Especie, nom = @nom, temp = @temp, horas_luz = @horas_luz, humedad = @humedad where id_Especie = @id_Especie", conexion);

                    cmd.Parameters.AddWithValue("@id_Especie", especie.Id_Especie);
                    cmd.Parameters.AddWithValue("@nom", especie.Nom);
                    cmd.Parameters.AddWithValue("@temp", especie.Temp);
                    cmd.Parameters.AddWithValue("@horas_luz", especie.Horas_luz);
                    cmd.Parameters.AddWithValue("@humedad", especie.Humedad);

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

        public Especie SelectId(int id)
        {
            string query = "select * from Especie where id_Especie = '";
            query += id + "'";
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                Especie especie = new Especie();
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    especie.Id_Especie = Convert.ToInt32(dataReader["id_Especie"]);
                    especie.Nom = Convert.ToString(dataReader["nom"]);
                    especie.Temp = Convert.ToInt32(dataReader["temp"]);
                    especie.Humedad = Convert.ToInt32(dataReader["humedad"]);
                    especie.Horas_luz = Convert.ToInt32(dataReader["id_Especie"]);

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
                return especie;
            }
            else
            {
                return null;
            }
        }

        public List<Especie> Select()
        {
            string query = "SELECT * FROM Especie";
            List<Especie> lista = new List<Especie>();
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Especie especie = new Especie();

                        especie.Id_Especie = Convert.ToInt32(dataReader["id_Especie"]);
                        especie.Nom = Convert.ToString(dataReader["nom"]);
                        especie.Temp = Convert.ToInt32(dataReader["temp"]);
                        especie.Humedad = Convert.ToInt32(dataReader["humedad"]);
                        especie.Horas_luz = Convert.ToInt32(dataReader["id_Especie"]);

                        lista.Add(especie);
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
