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
    class PrestamosBLL
    {
        public static bool Guardar(Prestamos Prestamo)
        {
            if (!Existe(Prestamo.PrestamoId)) { return Insertar(Prestamo); }
            else { return Modificar(Prestamo); }
        }

        public static bool Eliminar(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                var Prestamo = datos.prestamos.Find(Id);
                if(Prestamo != null)
                {
                    datos.prestamos.Remove(Prestamo);
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

        private static bool Insertar(Prestamos Prestamo)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                if (datos.prestamos.Add(Prestamo) != null) { esOk = datos.SaveChanges() > 0; }
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
                esOk = datos.prestamos.Any(e => e.PrestamoId == Id);
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

        private static bool Modificar(Prestamos Prestamo)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                datos.Database.ExecuteSqlRaw($"Delete FROM PrestamosDetalle Where PrestamoId={Prestamo.PrestamoId}");
                foreach (var item in Prestamo.Detalles)
                {
                    datos.Entry(item).State = EntityState.Added;
                }
                datos.Entry(Prestamo).State = EntityState.Modified;
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

        public static Prestamos Buscar(int Id)
        {
            Contexto datos = new Contexto();
            Prestamos Prestamo = new Prestamos();

            try
            {
                Prestamo = datos.prestamos.Include(x => x.Detalles).Where(x => x.PrestamoId == Id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return Prestamo;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> Prestamo)
        {
            Contexto datos = new Contexto();
            List<Prestamos> Lista = new List<Prestamos>();

            try
            {
                Lista = datos.prestamos.Where(Prestamo).ToList();
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
