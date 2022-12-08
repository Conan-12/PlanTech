using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PlanTech.Modelo.Servicios
{
    public class Service_Grupo_Planta
    {
        public string cadenaCnx;
        public MySqlConnection conexion;
        string server = "localhost";
        string database = "PlanTech";
        string user = "root";
        string password = "978607Ale";

        public Service_Grupo_Planta()
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

        public bool Insertar(Grupo_Planta grupo_planta)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Grupo_Planta (id_Grupo, id_Planta) VALUES (@id_Grupo, @id_Planta)", conexion);

                    cmd.Parameters.AddWithValue("@id_Grupo", grupo_planta.Id_Grupo);
                    cmd.Parameters.AddWithValue("@id_Planta", grupo_planta.Id_Planta);

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

        public bool Actualizar(Grupo_Planta grupo_planta)
        {
            try
            {
                if (this.AbrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Grupo_Planta SET id_Grupo_Planta = @id_Grupo_Planta, id_Grupo = @id_Grupo, id_Planta = @id_Planta where id_Grupo_Planta = @id_Grupo_Planta", conexion);

                    cmd.Parameters.AddWithValue("@id_Grupo", grupo_planta.Id_Grupo);
                    cmd.Parameters.AddWithValue("@id_Planta", grupo_planta.Id_Planta);

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

        public Grupo_Planta SelectId(int id)
        {
            string query = "select * from Grupo_Planta where id_Grupo_Planta = '";
            query += id + "'";
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                Grupo_Planta grupo_planta = new Grupo_Planta();
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    grupo_planta.Id_Grupo = Convert.ToInt32(dataReader["id_Grupo"]);
                    grupo_planta.Id_Planta = Convert.ToInt32(dataReader["id_Planta"]);

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
                return grupo_planta;
            }
            else
            {
                return null;
            }
        }

        public List<Grupo_Planta> Select()
        {
            string query = "SELECT * FROM Grupo_Planta";
            List<Grupo_Planta> lista = new List<Grupo_Planta>();
            if (this.AbrirConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                try
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Grupo_Planta grupo_planta = new Grupo_Planta();

                        grupo_planta.Id_Grupo = Convert.ToInt32(dataReader["id_Grupo"]);
                        grupo_planta.Id_Planta = Convert.ToInt32(dataReader["id_Planta"]);

                        lista.Add(grupo_planta);
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
