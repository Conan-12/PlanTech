using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PlanTech.Modelo;
using PlanTech.Modelo.Servicios;
using System.Threading;
using PlanTech.Vista;

namespace PlanTech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*
            ThreadStart newThread = new ThreadStart(Simulador);
            Thread thread = new Thread(newThread);
            thread.Start();
            */

            panel1.Controls.Add(new UserControl1());

        }
        
        public void Simulador()
        {
            Service_Registro service_Registro = new Service_Registro();
            int temp = 19, horas_luz = 0, humedad = 53;
            DateTime encendido_luz = DateTime.Now;

            while (true)
            {
                Registro registro = new Registro();
                registro.Id_Planta = 2;
                registro.Momento = DateTime.Now;
                registro.Temp = temp;
                registro.Horas_luz = horas_luz;
                registro.Humedad = humedad;

                service_Registro.Insertar(registro);

                horas_luz = registro.Momento.Hour - encendido_luz.Hour;
                temp += new Random().Next(-2, 2);
                humedad += new Random().Next(-2, 2);

                Thread.Sleep(1000);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "non";
        }
    }
}


