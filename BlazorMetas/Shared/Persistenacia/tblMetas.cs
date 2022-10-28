using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.Persistenacia
{
    public class tblMetas
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { set; get; }
        public List<tblActividad> Actividades { get; set; }
    }
}
