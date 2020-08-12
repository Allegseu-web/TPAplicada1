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
    /// Interaction logic for rAmigos.xaml
    /// </summary>
    public partial class rAmigos : Window
    {
        Amigos Amigo = new Amigos();
        public rAmigos()
        {
            InitializeComponent();
            DataContext = Amigo;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var amigito = AmigosBLL.Buscar(int.Parse(AmigoIdTextBox.Text));

            if(amigito != null)
            {
                Amigo = amigito;
            }
            else
            {
                Amigo = new Amigos();
            }
            DataContext = Amigo;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Refrescar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Contexto context = new Contexto();
            if (!Validar()) { return; }
            if(context.amigos.Any(p => p.Nombre == NombreTextBox.Text))
            {
                MessageBox.Show("Este Amigo ya existe.", "Persona existente", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("Si profesor pense en eso, pruebe con mas cosas.");
            }
            else
            {
                var proceso = AmigosBLL.Guardar(Amigo);

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
            if (AmigosBLL.Eliminar(int.Parse(AmigoIdTextBox.Text)))
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
            Amigo = new Amigos();
            DataContext = Amigo;
        }

        private bool Validar()
        {
            bool esOkay = true;

            if(NombreTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Nombre esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (DireccionTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Direccion esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (TelefonoTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Telefono esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (CelularTextBox.Text.Length == 0)
            {
                esOkay = false;
                MessageBox.Show("Celular esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            return esOkay;
        }
    }
}
