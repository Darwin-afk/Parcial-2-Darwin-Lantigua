using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Parcial2_Darwin_Lantigua.Entidades;
using Parcial2_Darwin_Lantigua.DAL;
using System.Linq;

namespace Parcial2_Darwin_Lantigua.BLL
{
    public class LlamadasBLL
    {
        public static bool Guardar(Llamadas llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Llamadas.Add(llamada) != null)
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

        public static bool Modificar(Llamadas llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM LlamadasDetalle Where LlamadaId = {llamada.LlamadaId}");
                foreach(var item in llamada.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(llamada).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = LlamadasBLL.Buscar(id);
                db.Entry(eliminar).State = EntityState.Deleted;
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

        public static Llamadas Buscar(int id)
        {
            Llamadas llamada = new Llamadas();
            Contexto db = new Contexto();

            try
            {
                llamada = db.Llamadas.Include(x => x.Detalle)
                    .Where(x => x.LlamadaId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return llamada;
        }
    }
}
