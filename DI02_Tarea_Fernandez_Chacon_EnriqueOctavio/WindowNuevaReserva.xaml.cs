using DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using DI02_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
        private int errores;
        private int numeroClientes;
        private bool modificar = false;
        
        
        public WindowNuevaReserva(Clientes clientes, Reservas reservas)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.clientes = clientes;
            this.reservas = reservas;
            this.reserva = new Reserva();
            this.DataContext = this.reserva;
            InicializarComponentes();
        }

        public WindowNuevaReserva(Clientes clientes, Reservas reservas, Reserva reserva)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.clientes = clientes;
            this.reservas = reservas;
            this.reserva = reserva;
            this.DataContext = this.reserva;
            modificar = true;
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            cbClientes.ItemsSource = clientes.GetClientes();
            cbMotivo.ItemsSource = Enum.GetValues(typeof(TipoCita)).Cast<TipoCita>();
            numeroClientes = clientes.GetClientes().Count();

            if (modificar)
            {
                tbHora.Text = reserva.Fecha.Hour.ToString();
                tbMinutos.Text = reserva.Fecha.Minute.ToString();
                btReservar.Content = "Modificar";
                this.Title = "Modificar Reserva";
                lTitulo.Content = "Modificar Reserva";
            }
            else
            {
                reserva.Fecha = DateTime.Now;
                reserva.Cliente = clientes.BuscarCliente(1);
                reserva.TipoCita = TipoCita.Revision;
                tbHora.Text = "10";
            }
     
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonReservar_Click(object sender, RoutedEventArgs e)
        {
            bool centinela = true;
            int hora = 0;
            int minutos = 0;

            if (!int.TryParse(tbHora.Text, out hora)) 
            {
                centinela = false;
                MessageBox.Show("El campo hora debe ser numérico", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!int.TryParse(tbMinutos.Text, out minutos))
            {
                centinela = false;
                MessageBox.Show("El campo minutos debe ser numérico", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (minutos < 0 || minutos > 59)
            {
                centinela = false;
                MessageBox.Show("Valor del campo minutos fuera de rango", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (centinela)
            {
                if (hora < 10 || hora > 23)
                {
                    centinela = false;
                    MessageBox.Show("El horario de reserva es de 10:00 a 23:59", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (centinela)
            {
                DateTime fecha = new DateTime(reserva.Fecha.Year, reserva.Fecha.Month, reserva.Fecha.Day, Int32.Parse(tbHora.Text), Int32.Parse(tbMinutos.Text), 0);

                if (DateTime.Compare(fecha, DateTime.Now.AddHours(1)) < 0)
                {
                    centinela = false;
                    MessageBox.Show("La fecha y hora de la reserva debe ser posterior a 1 hora desde el momento actual", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (centinela)
                {
                    reserva.Fecha = fecha;
                    reserva.Seguro = (bool)rbSi.IsChecked;
                    if (modificar)
                    {
                        reservas.ModificarReserva(reserva);
                    } 
                    else
                    {
                        reservas.AgregarReserva(reserva);
                    }
                    this.Close();
                }
            }
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

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errores++;
            else
                errores--;

            if (errores == 0)
                this.btReservar.IsEnabled = true;
            else
                this.btReservar.IsEnabled = false;

        }

        private void VisibilidadChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (numeroClientes != clientes.GetClientes().Count)
            {
                //reserva.Cliente = clientes.GetClientes().LastOrDefault();
                cbClientes.SelectedIndex = clientes.GetClientes().Count - 1;
            }
        }
    }
}
