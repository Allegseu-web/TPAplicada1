using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TPAplicada1.BLL;
using TPAplicada1.Entidades;

namespace TPAplicada1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cJuegos.xaml
    /// </summary>
    public partial class cJuegos : Window
    {
        public cJuegos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Datos.ItemsSource = null;
            var listado = new List<Juegos>();

            if (DesdeDate.SelectedDate != null)
            {
                listado = JuegosBLL.GetList(c => c.FechaCompra.Date >= DesdeDate.SelectedDate);
            }
            else
            {
                listado = JuegosBLL.GetList(c => true);
            }

            if (HastaDate.SelectedDate != null)
            {
                listado = JuegosBLL.GetList(c => c.FechaCompra.Date <= HastaDate.SelectedDate);
            }
            else
            {
                listado = JuegosBLL.GetList(c => true);
            }
            Datos.ItemsSource = listado;
        }
    }
}
