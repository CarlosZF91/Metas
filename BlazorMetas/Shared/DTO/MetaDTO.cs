using BlazorMetas.Shared.Persistenacia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.DTO
{
    public class MetaDTO 
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { set; get; }
        public double porcentajeAvance { get; set; }
        public int actividadesConcluidas { get; set; }
        public int totalActividades { get; set; }
    }
}
