using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanTech.Modelo
{
    public class Registro
    {
        int id_Registro, id_Planta, temp, horas_luz, humedad;
        DateTime momento;

        public int Id_Registro { get => id_Registro; set => id_Registro = value; }
        public int Id_Planta { get => id_Planta; set => id_Planta = value; }
        public int Temp { get => temp; set => temp = value; }
        public int Horas_luz { get => horas_luz; set => horas_luz = value; }
        public int Humedad { get => humedad; set => humedad = value; }
        public DateTime Momento { get => momento; set => momento = value; }
    }
}
