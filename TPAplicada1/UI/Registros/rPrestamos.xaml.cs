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
    /// Interaction logic for rPrestamos.xaml
    /// </summary>
    public partial class rPrestamos : Window
    {
        Prestamos Prestamo = new Prestamos();
        public rPrestamos()
        {
            InitializeComponent();
            DataContext = Prestamo;
            JuegoIdComboBox.ItemsSource = JuegosBLL.GetList(x => true);
            JuegoIdComboBox.SelectedValuePath = "JuegoId";
            JuegoIdComboBox.DisplayMemberPath = "Descripcion";
            AmigoComboBox.ItemsSource = AmigosBLL.GetList(x => true);
            AmigoComboBox.SelectedValuePath = "AmigoId";
            AmigoComboBox.DisplayMemberPath = "Nombre";
        }

        private void Cargar()
        {
            DataContext = null;
            DataContext = Prestamo;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamito = PrestamosBLL.Buscar(int.Parse(PrestamoTextBox.Text));

            if (prestamito != null)
            {
                Prestamo = prestamito;
                Cargar();
            }
            else
            {
                Refrescar();
                MessageBox.Show("No existe en la base de datos", "No encontrado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Refrescar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            Prestamo.AmigoId += 1;
            var proceso = PrestamosBLL.Guardar(Prestamo);

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
            if (PrestamosBLL.Eliminar(int.Parse(PrestamoTextBox.Text)))
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
            Prestamo = new Prestamos();
            DataContext = Prestamo;
        }

        private bool Validar()
        {
            bool esOkay = true;

            if (ObsevacionTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Nombre esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return esOkay;
        }

        private void AñadirButton_Click(object sender, RoutedEventArgs e)
        {
            if(AmigoComboBox.Text.Length != 0 && CantidadJuegosTextBox.Text.Length != 0 && ObsevacionTextBox.Text.Length != 0 && JuegoIdComboBox.Text.Length != 0)
            {
                var remover = JuegosBLL.Buscar(JuegoIdComboBox.SelectedIndex + 1);
                remover.Existencias -= int.Parse(CantidadJuegosTextBox.Text);
                JuegosBLL.Guardar(remover);
                Prestamo.Detalles.Add(new PrestamosDetalle(Prestamo.PrestamoId, JuegoIdComboBox.SelectedIndex + 1, int.Parse(CantidadJuegosTextBox.Text), AmigoComboBox.Text, JuegoIdComboBox.Text));

                Cargar();
                CantidadJuegosTextBox.Text = "0";
                JuegoIdComboBox.Text = string.Empty;
                AmigoComboBox.Text = string.Empty;
            }
        }

        private void BorrarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Detalles.Items.Count >= 1 && Detalles.SelectedIndex <= Detalles.Items.Count - 1)
                {
                    Prestamo.Detalles.RemoveAt(Detalles.SelectedIndex);
                    Cargar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor elegir la fila a eliminar.", "Fila no selecionada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
