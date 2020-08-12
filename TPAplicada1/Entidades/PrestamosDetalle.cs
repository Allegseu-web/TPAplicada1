using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TPAplicada1.Entidades
{
    public class PrestamosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int JuegoId { get; set; }
        public string Juego_Nombre { get; set; }
        public string Amigo_Nombre { get; set; }
        public int Cantidad { get; set; }

        public PrestamosDetalle(int prestamoid, int juegoid, int cantidad, string nombreamigo, string nombrejuego)
        {
            Id = 0;
            PrestamoId = prestamoid;
            Amigo_Nombre = nombreamigo;
            Juego_Nombre = nombrejuego;
            JuegoId = juegoid;
            Cantidad = cantidad;
        }

        public PrestamosDetalle() { }
    }
}
