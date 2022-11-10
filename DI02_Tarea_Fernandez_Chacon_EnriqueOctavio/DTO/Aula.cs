using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO
{
    public class Aula
    {
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        public Aula(string nombre, int capacidad)
        {
            Nombre = nombre;
            Capacidad = capacidad;
        }
    }
}
