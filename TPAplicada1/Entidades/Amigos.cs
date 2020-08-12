using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TPAplicada1.Entidades
{
    public class Amigos
    {
        [Key]
        public int AmigoId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    }
}
