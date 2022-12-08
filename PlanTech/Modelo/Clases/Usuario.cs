using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanTech.Modelo
{
    public class Usuario
    {
        int id_Usuario;
        string nom_Usuario;
        string contraseña;

        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }
        public string Nom_Usuario { get => nom_Usuario; set => nom_Usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
    }
}
