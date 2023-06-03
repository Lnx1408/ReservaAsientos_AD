using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pasajero
    {
        public string Nombre { get; set; }
        public string DNI { get; set;}
        public Asiento Asiento { get; set;}

        public Pasajero(string nombre)
        {
            Nombre = nombre;
        }

    }
}
