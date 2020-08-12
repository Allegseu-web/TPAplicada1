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

namespace TPAplicada1.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEntrada.xaml
    /// </summary>
    public partial class rEntrada : Window
    {
        Entradas Entrada = new Entradas();
        public rEntrada()
        {
            InitializeComponent();
            DataContext = Entrada;
            JuegoIdComboBox.ItemsSource = JuegosBLL.GetList(x => true);
            JuegoIdComboBox.SelectedValuePath = "JuegoId";
            JuegoIdComboBox.DisplayMemberPath = "Descripcion";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var entradita = EntradasBLL.Buscar(int.Parse(EntradaIdTextBox.Text));

            if (entradita != null)
            {
                Entrada = entradita;
            }
            else
            {
                Entrada = new Entradas();
            }
            DataContext = Entrada;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Refrescar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            var ingreso = JuegosBLL.Buscar(JuegoIdComboBox.SelectedIndex+1);
            ingreso.Existencias += int.Parse(CantidadTextBox.Text);
            JuegosBLL.Guardar(ingreso);
            var proceso = EntradasBLL.Guardar(Entrada);

            if (proceso == true)
            {
                Refrescar();
                MessageBox.Show("Guardado Correctamente.", "Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Guardado Fallido", "Incompleto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Refrescar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EntradasBLL.Eliminar(int.Parse(EntradaIdTextBox.Text)))
            {
                Refrescar();
                MessageBox.Show("Datos Eliminados", "Completo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar los datos", "Incompleto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Refrescar();
        }

        private void Refrescar()
        {
            Entrada = new Entradas();
            DataContext = Entrada;
        }

        private bool Validar()
        {
            bool esOkay = true;

            if (JuegoIdComboBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Nombre esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (CantidadTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Direccion esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return esOkay;
        }
    }
}
