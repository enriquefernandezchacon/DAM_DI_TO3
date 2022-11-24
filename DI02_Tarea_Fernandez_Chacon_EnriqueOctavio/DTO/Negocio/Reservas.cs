using DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio
{
    public class Reservas
    {
        private ObservableCollection<Reserva> listado;

        public Reservas()
        {
            listado = new ObservableCollection<Reserva>();
        }

        public void AgregarReserva(Reserva reserva)
        {
            if (reserva != null)
            {
                reserva.Id = listado.Count + 1;
                listado.Add(reserva);
            } 
        }

        public ObservableCollection<Reserva> GetReservas()
        {
            return listado;
        }
    }
}
