using BlazorMetas.Shared.DTO;
using BlazorMetas.Shared.Persistenacia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.IDA
{
    public interface IMetasDAL
    {
        public List<tblMetas> ObtenerMetas();
        public bool Crear(tblMetas meta);
        public bool Editar(tblMetas meta);
        public tblMetas ObtenerMetaPorId(string id);
        public bool Eliminar(tblMetas meta);
        bool ExisteNombreMeta(string nombre);
    }
}
