using System;

namespace DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO
{
    public class Reserva
    {
        int Id { get; set; }
        public string Nombre { get; set; }
        public Aula Aula { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroAlumnos { get; set; }

        public Reserva(int id, string nombre, Aula aula, DateTime fecha, int numeroAlumnos)
        {
            Id = id;
            Nombre = nombre;
            Aula = aula;
            Fecha = fecha;
            NumeroAlumnos = numeroAlumnos;
        }
    }
}
