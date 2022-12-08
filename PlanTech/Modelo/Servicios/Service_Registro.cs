using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PlanTech.Modelo.Servicios
{
    public class Service_Registro
    {
        public string cadenaCnx;
        public MySqlConnection conexion;
        string server = "localhost";
        string database = "PlanTech";
        string user = "root";
        string password = "978607Ale";

        public Service_Registro()
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
                        MessageBox.Show(ex.Message);
                        break;
                    case 1045:
                        MessageBox.Show(ex.Message);
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

        public bool Insertar(Registro registro)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Registro (id_Planta, momento, temp, horas_luz, humedad) VALUES (@id_Planta, @momento, @temp, @horas_luz, @humedad)", conexion);

                    cmd.Parameters.AddWithValue("@id_Planta", registro.Id_Planta);
                    cmd.Parameters.AddWithValue("@momento", registro.Momento);
                    cmd.Parameters.AddWithValue("@temp", registro.Temp);
                    cmd.Parameters.AddWithValue("@horas_luz", registro.Horas_luz);
                    cmd.Parameters.AddWithValue("@humedad", registro.Humedad);

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

        public bool Actualizar(Registro registro)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Registro SET id_Registro = @id_Registro, id_Planta = @id_Planta, momento = @momento, temp = @temp, horas_luz = @horas_luz, humedad = @humedad where id_Registro = @id_Registro", conexion);

                    cmd.Parameters.AddWithValue("@id_Registro", registro.Id_Registro);
                    cmd.Parameters.AddWithValue("@id_Planta", registro.Id_Planta);
                    cmd.Parameters.AddWithValue("@contraseña", registro.Momento);
                    cmd.Parameters.AddWithValue("@temp", registro.Temp);
                    cmd.Parameters.AddWithValue("@horas_luz", registro.Horas_luz);
                    cmd.Parameters.AddWithValue("@humedad", registro.Humedad);

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

        public Registro SelectId(int id)
        {
            string query = "select * from Registro where id_Registro = '";
            query += id + "'";
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                Registro registro = new Registro();
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    registro.Id_Registro = Convert.ToInt32(dataReader["id_Registro"]);
                    registro.Id_Planta = Convert.ToInt32(dataReader["id_Planta"]);
                    registro.Momento = Convert.ToDateTime(dataReader["momento"]);
                    registro.Temp = Convert.ToInt32(dataReader["temp"]);
                    registro.Humedad = Convert.ToInt32(dataReader["humedad"]);
                    registro.Horas_luz = Convert.ToInt32(dataReader["id_Especie"]);

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
                return registro;
            }
            else
            {
                return null;
            }
        }

        public List<Registro> Select()
        {
            string query = "SELECT * FROM Registro";
            List<Registro> lista = new List<Registro>();
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Registro registro = new Registro();

                        registro.Id_Registro = Convert.ToInt32(dataReader["id_Registro"]);
                        registro.Id_Planta = Convert.ToInt32(dataReader["id_Planta"]);
                        registro.Momento = Convert.ToDateTime(dataReader["momento"]);
                        registro.Temp = Convert.ToInt32(dataReader["temp"]);
                        registro.Humedad = Convert.ToInt32(dataReader["humedad"]);
                        registro.Horas_luz = Convert.ToInt32(dataReader["horas_luz"]);

                        lista.Add(registro);
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
