using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanTech.Modelo
{
    public class Especie
    {
        int id_Especie, horas_luz, humedad, temp;
        string nom;

        public int Id_Especie { get => id_Especie; set => id_Especie = value; }
        public int Horas_luz { get => horas_luz; set => horas_luz = value; }
        public int Humedad { get => humedad; set => humedad = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Temp { get => temp; set => temp = value; }
    }
}
