using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TPAplicada1.UI.Consultas;
using TPAplicada1.UI.Registros;

namespace TPAplicada1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrosAmigos_Click(object sender, RoutedEventArgs e)
        {
            rAmigos ventana = new rAmigos();
            ventana.Show();
        }

        private void RegistrosJuegos_Click(object sender, RoutedEventArgs e)
        {
            rJuegos ventana = new rJuegos();
            ventana.Show();
        }

        private void RegistrosEntrada_Click(object sender, RoutedEventArgs e)
        {
            rEntrada ventana = new rEntrada();
            ventana.Show();
        }

        private void RegistrosPrestamos_Click(object sender, RoutedEventArgs e)
        {
            rPrestamos ventana = new rPrestamos();
            ventana.Show();
        }

        private void ConsultaAmigos_Click(object sender, RoutedEventArgs e)
        {
            cAmigos ventana = new cAmigos();
            ventana.Show();
        }

        private void ConsultasJuegos_Click(object sender, RoutedEventArgs e)
        {
            cJuegos ventana = new cJuegos();
            ventana.Show();
        }

        private void ConsultasPrestamos_Click(object sender, RoutedEventArgs e)
        {
            cPrestamos ventana = new cPrestamos();
            ventana.Show();
        }
    }
}
