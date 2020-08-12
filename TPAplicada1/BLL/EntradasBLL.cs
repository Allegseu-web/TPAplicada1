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
    class EntradasBLL
    {
        public static bool Guardar(Entradas Entrada)
        {
            if (!Existe(Entrada.EntradaId)) { return Insertar(Entrada); }
            else { return Modificar(Entrada); }
        }

        public static bool Eliminar(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                var Entrada = datos.entradas.Find(Id);
                if (Entrada != null)
                {
                    datos.entradas.Remove(Entrada);
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

        private static bool Insertar(Entradas Entrada)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                if (datos.entradas.Add(Entrada) != null) { esOk = datos.SaveChanges() > 0; }
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
                esOk = datos.entradas.Any(e => e.EntradaId == Id);
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

        private static bool Modificar(Entradas Entrada)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                datos.Entry(Entrada).State = EntityState.Modified;
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

        public static Entradas Buscar(int Id)
        {
            Contexto datos = new Contexto();
            Entradas Entrada = new Entradas();

            try
            {
                Entrada = datos.entradas.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return Entrada;
        }

        public static List<Entradas> GetList(Expression<Func<Entradas, bool>> Entrada)
        {
            Contexto datos = new Contexto();
            List<Entradas> Lista = new List<Entradas>();

            try
            {
                Lista = datos.entradas.Where(Entrada).ToList();
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
