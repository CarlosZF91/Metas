using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.Persistenacia
{
    public class tblActividad
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Importante { get; set; }
        public bool Concluida { get; set; }
        public string MetaId { get; set; }
        public tblMetas Meta { get; set; }
    }
}
