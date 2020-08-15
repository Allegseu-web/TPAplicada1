using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TPAplicada1.DAL;
using TPAplicada1.Entidades;

namespace TPAplicada1.BLL
{
    class JuegosBLL
    {
        public static bool Guardar(Juegos Juego)
        {
            if (!Existe(Juego.JuegoId)) { return Insertar(Juego); }
            else { return Modificar(Juego); }
        }

        public static bool Eliminar(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                var Juego = datos.juegos.Find(Id);
                if(Juego != null)
                {
                    datos.juegos.Remove(Juego);
                    esOk = datos.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        private static bool Insertar(Juegos Juego)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                if (datos.juegos.Add(Juego) != null) { esOk = datos.SaveChanges() > 0; }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        public static bool Existe(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                esOk = datos.juegos.Any(e => e.JuegoId == Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        private static bool Modificar(Juegos Juego)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                datos.Entry(Juego).State = EntityState.Modified;
                esOk = datos.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        public static bool Entrada(Juegos Juego, int cantidad)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                Juego.Existencias += cantidad;
                datos.Entry(Juego).State = EntityState.Modified;
                esOk = datos.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        public static bool Salida(Juegos Juego, int cantidad)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                Juego.Existencias -= cantidad;
                datos.Entry(Juego).State = EntityState.Modified;
                esOk = datos.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        public static Juegos Buscar(int Id)
        {
            Contexto datos = new Contexto();
            Juegos Juego = new Juegos();

            try
            {
                Juego = datos.juegos.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return Juego;
        }

        public static List<Juegos> GetList(Expression<Func<Juegos, bool>> Juego)
        {
            Contexto datos = new Contexto();
            List<Juegos> Lista = new List<Juegos>();

            try
            {
                Lista = datos.juegos.Where(Juego).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return Lista;
        }
    }
}
