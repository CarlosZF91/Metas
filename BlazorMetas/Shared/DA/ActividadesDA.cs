using BlazorMetas.Shared.IDA;
using BlazorMetas.Shared.Persistenacia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlazorMetas.Shared.DA
{
    public class ActividadesDA: IActividadesDAL
    {
        public ActividadesDA(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }
        public  bool Concluir(string id)
        {
            try
            {
                tblActividad actividad = new tblActividad { Id = id, Concluida = true };
                ApplicationDbContext.tblActividad.Attach(actividad);

                ApplicationDbContext.Entry(actividad).Property(x => x.Concluida).IsModified = true;
                  ApplicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  bool Crear(tblActividad actividad)
        {
            try
            {
                ApplicationDbContext.tblActividad.Add(actividad);
                ApplicationDbContext.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

            //try
            //{

            //    string sql = "INSERT INTO tblActividad (Id,Nombre,FechaCreacion,Importante,Concluida,MetaId) VALUES(@Id,@Nombre,@FechaCreacion,@Importante,@Concluida,@MetaId)";

            //    var Parametros = new DynamicParameters(
            //    new
            //    {
            //        Id= actividad.Id,
            //        Nombre= actividad.Nombre,
            //        FechaCreacion= actividad.FechaCreacion,
            //        Importante= actividad.Importante,
            //        Concluida= actividad.Concluida,
            //        MetaId= actividad.MetaId
            //    });


            //    using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=baseMetas.mdf;Integrated Security=True"))
            //    {
            //        var clientes = ApplicationDbContext.(sql, Parametros);
            //        return true;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    return false;
            //}
        }

        public  bool Destacar(string id)
        {
            try
            {
                tblActividad actividad = ApplicationDbContext.tblActividad.FirstOrDefault(x => x.Id == id);

                actividad.Importante = !actividad.Importante;
                ApplicationDbContext.tblActividad.Attach(actividad);

                ApplicationDbContext.Entry(actividad).Property(x => x.Importante).IsModified = true;
                  ApplicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  bool Editar(tblActividad actividad)
        {
            try
            {
                ApplicationDbContext.Attach(actividad).State = EntityState.Modified;
                  ApplicationDbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  bool Eliminar(List<string> ids)
        {
            try
            {
                var eliminar = ApplicationDbContext.tblActividad.Where(x => ids.Contains(x.Id));

                ApplicationDbContext.RemoveRange(eliminar);
                  ApplicationDbContext.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public  List<tblActividad> ObtenerActividadesPorMeta(string idMeta)
        {

            try
            {
                return   ApplicationDbContext.tblActividad.Where(x => x.MetaId == idMeta).ToList();
            }
            catch (Exception ex)
            {
                return new List<tblActividad>();
            }
        }

        public  tblActividad ObtenerActividadPorId(string id)
        {
            try
            {
                return   ApplicationDbContext.tblActividad.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
