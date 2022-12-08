using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlanTech.Modelo;
using PlanTech.Modelo.Servicios;

namespace PlanTech.Vista
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            List<Registro> registros = new Service_Registro().Select();

            grafica.Series.Clear();
            grafica.DataBindTable(registros, "Id_Registro");

            grafica.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            grafica.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            grafica.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            grafica.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            grafica.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            grafica.Series.RemoveAt(0);
            grafica.Series.RemoveAt(3);

        }
    }
}
