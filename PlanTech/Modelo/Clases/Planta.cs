using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanTech.Modelo
{
    public class Planta
    {
        int id_Planta, id_Especie;
        DateTime fecha;

        public int Id_Planta { get => id_Planta; set => id_Planta = value; }
        public int Id_Especie { get => id_Especie; set => id_Especie = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
