using DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio;
using System;
using System.Linq;
using System.Windows;

namespace DI02_Tarea_Fernandez_Chacon_EnriqueOctavio
{
    /// <summary>
    /// Lógica de interacción para WindowNuevaReserva.xaml
    /// </summary>
    public partial class WindowNuevaReserva : Window
    {
        private Clientes clientes;
        private Reservas reservas;
        private Reserva reserva;
        int errores
        public WindowNuevaReserva(Clientes clientes, Reservas reservas)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.clientes = clientes;
            this.reservas = reservas;
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            dpFecha.Text = DateTime.Now.ToString();

            cbClientes.ItemsSource = clientes.GetClientes();
            cbClientes.SelectedIndex = 0;

            cbMotivo.ItemsSource = Enum.GetValues(typeof(TipoCita)).Cast<TipoCita>();
            cbMotivo.SelectedIndex = 0;

            
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            //
            //
            //
            this.Close();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void ButtonNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            DialogoCliente dialogoCliente = new DialogoCliente(clientes);
            dialogoCliente.Owner = this;
            dialogoCliente.Show();
            this.Hide();
        }
    }
}
