using BlazorMetas.Shared.Persistenacia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.IDA
{
    public interface IActividadesDAL
    {
         bool  Crear(tblActividad actividad);
         bool  Editar(tblActividad actividad);
         bool  Eliminar(List<string>  id);
         bool  Destacar(string id);
         bool  Concluir(string id);
         tblActividad  ObtenerActividadPorId(string id);
         List<tblActividad>   ObtenerActividadesPorMeta(string idMeta);
    }
}
