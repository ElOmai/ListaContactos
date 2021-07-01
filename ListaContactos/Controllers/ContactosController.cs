using ListaContactos.Data;
using ListaContactos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ListaContactos.Controllers
{
    public class ContactosController
    {
        public static bool Guardar(Contactos entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.Contactos.Any(A => A.ContactoId == entity.ContactoId))
                {
                    paso = Modificar(entity);
                }
                else
                {
                    paso = Insertar(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        private static bool Insertar(Contactos entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                db.Contactos.Add(entity);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Contactos entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int Id)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                Contactos Contacto = db.Contactos.Find(Id);
                if (Contacto != null)
                {
                    db.Entry(Contacto).State = EntityState.Deleted;
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Contactos Buscar(int Id)
        {
            Contexto db = new Contexto();
            Contactos Contacto;
            try
            {
                Contacto = db.Contactos.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Contacto;
        }

        public static List<Contactos> GetList(Expression<Func<Contactos, bool>> expression)
        {
            List<Contactos> lista = new List<Contactos>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Contactos.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
