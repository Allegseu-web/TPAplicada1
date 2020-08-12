using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TPAplicada1.Entidades;

namespace TPAplicada1.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Amigos> amigos { get; set; }
        public DbSet<Juegos> juegos { get; set; }
        public DbSet<Prestamos> prestamos { get; set; }
        public DbSet<Entradas> entradas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\BaseDatos.db");
        }
    }
}
