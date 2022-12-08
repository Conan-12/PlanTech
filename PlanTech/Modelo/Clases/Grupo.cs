using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanTech.Modelo
{
    public class Grupo
    {
        int id_Grupo;
        string nombre;
        DateTime fecha;

        public int Id_Grupo { get => id_Grupo; set => id_Grupo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
