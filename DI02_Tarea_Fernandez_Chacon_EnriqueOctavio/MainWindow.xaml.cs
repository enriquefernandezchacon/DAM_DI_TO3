using DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DI02_Tarea_Fernandez_Chacon_EnriqueOctavio
{
    public partial class MainWindow : Window
    {
        private Reservas reservas;
        private Clientes clientes;
        public MainWindow()
        {
            InitializeComponent();
            reservas = new Reservas();
            clientes = new Clientes();
            InicializarDatos();
            CrearTabla();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    
        private void MenuItem_Click_NuevaReserva(object sender, RoutedEventArgs e) {
            WindowNuevaReserva window = new WindowNuevaReserva(clientes, reservas);
            window.Owner = this;
            this.Hide();
            window.Show();
        }

        private void BorrarReserva_Click(object sender, RoutedEventArgs e)
        {
            if (dgReservas.SelectedIndex == -1) 
            {
                MessageBox.Show("No ha seleccionado ninguna reserva para borrar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                MessageBoxResult result = MessageBox.Show("¿Esta seguro de borrar la reserva?", "Borrar Reserva", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Reserva reserva = (Reserva) dgReservas.SelectedItem;
                    reservas.BorrarReserva(reserva.Id);
                }
            }
        }

        private void ModificarReserva_Click(object sender, RoutedEventArgs e)
        {
            if (dgReservas.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado ninguna reserva para modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Reserva reserva = (Reserva)dgReservas.SelectedItem;
                WindowNuevaReserva window = new WindowNuevaReserva(clientes, reservas, reserva);
                window.Owner = this;
                this.Hide();
                window.Show();
            }
            
        }

        private void MenuItem_Click_Salir(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void MenuItem_ClickAcercaDe(object sender, RoutedEventArgs e) {
            WindowAcercaDe windowAcercaDe = new WindowAcercaDe();
            windowAcercaDe.Owner = this;
            windowAcercaDe.Title = "Acerca De";
            this.Hide();
            windowAcercaDe.Show();
        }

        private void ReiniciarContenido(object sender, RoutedEventArgs e)
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            reservas.GetReservas().Clear();
            clientes.GetClientes().Clear();
            Cliente c1 = new Cliente("Enrique Octavio", "Fernandez Chacon", "656656656");
            clientes.AgregarCliente(c1);
            Reserva r1 = new Reserva(c1, DateTime.Now, TipoCita.Revision, true);
            reservas.AgregarReserva(r1);
        }

        private void CrearTabla()
        {
            dgReservas.ItemsSource = reservas.GetReservas();

            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Fecha") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("TipoCita") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Cliente.Nombre") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Cliente.Apellidos") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Cliente.Telefono") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Seguro") });

            dgReservas.Columns[0].Header = "Fecha";
            dgReservas.Columns[1].Header = "Tipo de cita";
            dgReservas.Columns[2].Header = "Nombre del Paciente";
            dgReservas.Columns[3].Header = "Apellidos del Paciente";
            dgReservas.Columns[4].Header = "Teléfono";
            dgReservas.Columns[5].Header = "Seguro Privado";
        }

        private void VisibilidadChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            dgReservas.Items.Refresh();
        }
    }
}
