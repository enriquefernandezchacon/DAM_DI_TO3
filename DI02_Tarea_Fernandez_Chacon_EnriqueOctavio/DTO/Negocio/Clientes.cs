using DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio
{
    public class Clientes
    {
        private ObservableCollection<Cliente> listadoClientes;

        public Clientes()
        {
            listadoClientes = new ObservableCollection<Cliente>();
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.Id = listadoClientes.Count + 1;
                listadoClientes.Add(cliente);
            }
        }

        public Cliente? BuscarCliente(int id)
        {
            return listadoClientes.FirstOrDefault(c => c.Id == id);
        }

        public ObservableCollection<Cliente> GetClientes()
        {
            return listadoClientes;
        }
    }
}
