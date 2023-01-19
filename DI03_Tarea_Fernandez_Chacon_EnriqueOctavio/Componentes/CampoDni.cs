using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace DI03_Tarea_Fernandez_Chacon_EnriqueOctavio.Componentes
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class CampoDni : UserControl, INotifyPropertyChanged
    {
        private string _dni = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Dni
        {
            get { return _dni; } 
            set {
                EstadoBoton = value.Length > 7;
                _dni = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dni)));
            }
        }

        public int LongitudMaxima { get; set; } = 8;
        private bool _estadoBoton;
        public bool EstadoBoton { 
            get { return _estadoBoton; } 
            set {
                _estadoBoton = value;
                Console.WriteLine(EstadoBoton);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoBoton)));
            } } 

        public CampoDni()
        {
            InitializeComponent();
            this.DataContext = this;
            EstadoBoton = Dni.Length > 7;
        }

        public void CalcularLetra(object sender, EventArgs e)
        {
            if (Dni.Length == 8)
            {
                string[] control = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
                bool flag = Int32.TryParse(Dni, out var dni);
                if (flag)
                {
                    LongitudMaxima = 9;
                    Dni += control[dni % 23];
                }
            }
            
        }

        public void QuitarLetra(object sender, EventArgs e)
        {
            if (Dni.Length == 9)
            {
                LongitudMaxima = 8;
                Dni = Dni[..8];
            } 
        }

        public void CheckDni(object sender, EventArgs e)
        {
            EstadoBoton = TextBoxEntidad.Text.Length > 7;
        }
    }
}
