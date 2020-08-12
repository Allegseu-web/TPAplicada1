using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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
using TPAplicada1.DAL;
using TPAplicada1.Entidades;

namespace TPAplicada1.UI.Registros
{
    /// <summary>
    /// Interaction logic for rJuegos.xaml
    /// </summary>
    public partial class rJuegos : Window
    {
        Juegos Juego = new Juegos();
        public rJuegos()
        {
            InitializeComponent();
            DataContext = Juego;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var jueguito = JuegosBLL.Buscar(int.Parse(JuegoIdTextBox.Text));

            if (jueguito != null)
            {
                Juego = jueguito;
            }
            else
            {
                Juego = new Juegos();
            }
            DataContext = Juego;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Refrescar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Contexto context = new Contexto();
            if (!Validar()) { return; }

            if(context.juegos.Any(p => p.Descripcion == DescripcionTextBox.Text))
            {
                MessageBox.Show("Este Juego ya existe.", "Juego existente", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("Si profesor pense en eso, pruebe con mas cosas.");
            }
            else
            {
                var proceso = JuegosBLL.Guardar(Juego);

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
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (JuegosBLL.Eliminar(int.Parse(JuegoIdTextBox.Text)))
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
            Juego = new Juegos();
            DataContext = Juego;
        }

        private bool Validar()
        {
            bool esOkay = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Nombre esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (PrecioTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Direccion esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (CantidadTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Telefono esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return esOkay;
        }
    }
}
