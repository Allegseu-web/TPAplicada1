using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using TPAplicada1.DAL;
using TPAplicada1.Entidades;

namespace TPAplicada1.BLL
{
    class AmigosBLL
    {
        public static bool Guardar(Amigos Amigo)
        {
            if (!Existe(Amigo.AmigoId)) { return Insertar(Amigo); }
            else { return Modificar(Amigo); }
        }

        public static bool Eliminar(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                var Amigo = datos.amigos.Find(Id);
                if(Amigo != null)
                {
                    datos.amigos.Remove(Amigo);
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

        private static bool Insertar(Amigos Amigo)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                if(datos.amigos.Add(Amigo) != null) { esOk = datos.SaveChanges() > 0; }
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
                esOk = datos.amigos.Any(e => e.AmigoId == Id);
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

        private static bool Modificar(Amigos Amigo)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                datos.Entry(Amigo).State = EntityState.Modified;
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

        public static Amigos Buscar(int Id)
        {
            Contexto datos = new Contexto();
            Amigos Amigo = new Amigos();

            try
            {
                Amigo = datos.amigos.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return Amigo;
        }

        public static List<Amigos> GetList(Expression<Func<Amigos, bool>> Amigo)
        {
            Contexto datos = new Contexto();
            List<Amigos> Lista = new List<Amigos>();

            try
            {
                Lista = datos.amigos.Where(Amigo).ToList();
            }
            catch(Exception)
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
