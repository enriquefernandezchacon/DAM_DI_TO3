using DI03_Tarea_Fernandez_Chacon_EnriqueOctavio.Extensiones;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DI03_Tarea_Fernandez_Chacon_EnriqueOctavio.Vistas.Clientes
{
    /// <summary>
    /// Lógica de interacción para WindowAnadirCliente.xaml
    /// </summary>
    public partial class WindowAnadirCliente : Window
    {
        private List<string> errores = new List<string>();
        public WindowAnadirCliente()
        {
            InitializeComponent();
        }

        private void AnadirCliente(object sender, RoutedEventArgs e)
        {
            ComprobarCampos();
            
            
        }

        private void ComprobarCampos()
        {
            if (string.IsNullOrEmpty(TextBoxNombre.Text.Trim()))
            {
                errores.Add("nombre".ErrorVacio());
            }
            else if (!TextBoxNombre.Text.EsValido()) 
            {
                errores.Add("nombre".ErrorFormato());
            }

            if (string.IsNullOrEmpty(TextBoxApellidos.Text.Trim()))
            {
                errores.Add("apellidos".ErrorVacio());
            }
            else if (!TextBoxApellidos.Text.EsValido())
            {
                errores.Add("apellidos".ErrorFormato());
            }

            //TELEFONO

            if (string.IsNullOrEmpty(TextBoxTelefono.Text.Trim()))
            {
                errores.Add("telefono".ErrorVacio());
            }
            else if (!TextBoxTelefono.Text.EsTelefono())
            {
                errores.Add("telefono".ErrorFormato());
            }
            //EMAIL
            if (string.IsNullOrEmpty(TextBoxTelefono.Text.Trim()))
            {
                errores.Add("email".ErrorVacio());
            }
            else if (!TextBoxTelefono.Text.EsEmail())
            {
                errores.Add("email".ErrorFormato());
            }
            //DNI
            //DIRECCION
        }

        

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }
    }
}
