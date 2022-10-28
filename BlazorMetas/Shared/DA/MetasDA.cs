using BlazorMetas.Shared.IDA;
using BlazorMetas.Shared.Persistenacia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.DA
{
    public class MetasDA: IMetasDAL
    {
        public MetasDA(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public bool Crear(tblMetas meta)
        {
            try
            {
                ApplicationDbContext.Add(meta);
                 ApplicationDbContext.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Editar(tblMetas meta)
        {
            try
            {
                ApplicationDbContext.Attach(meta).State = EntityState.Modified;
                ApplicationDbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Eliminar(tblMetas meta)
        {
            try
            {
                ApplicationDbContext.Remove(meta);
                 ApplicationDbContext.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExisteNombreMeta(string nombre)
        {
            try
            {
                var contadorMismoNombre =  ApplicationDbContext.tblMetas.Where(x => x.Nombre.ToLower() == nombre.ToLower()).Count();

                return contadorMismoNombre > 0;
            }
            catch (Exception)
            {

                return true;
            }

        }

        public tblMetas ObtenerMetaPorId(string id)
        {
            try
            {
                return  ApplicationDbContext.tblMetas.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<tblMetas> ObtenerMetas()
        {
            try
            {
                return  ApplicationDbContext.tblMetas.Include("Actividades").ToList();
            }
            catch (Exception ex)
            {
                return new List<tblMetas>();
            }
        }
    }
}
