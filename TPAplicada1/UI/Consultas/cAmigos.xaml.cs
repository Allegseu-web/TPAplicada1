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
    /// Interaction logic for cAmigos.xaml
    /// </summary>
    public partial class cAmigos : Window
    {
        public cAmigos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Datos.ItemsSource = null;
            var listado = new List<Amigos>();

            if (DesdeDate.SelectedDate != null)
            {
                listado = AmigosBLL.GetList(c => c.FechaNacimiento.Date >= DesdeDate.SelectedDate);
            }
            else
            {
                listado = AmigosBLL.GetList(c => true);
            }

            if (HastaDate.SelectedDate != null)
            {
                listado = AmigosBLL.GetList(c => c.FechaNacimiento.Date <= HastaDate.SelectedDate);
            }
            else
            {
                listado = AmigosBLL.GetList(c => true);
            }
            Datos.ItemsSource = listado;
        }
    }
}
