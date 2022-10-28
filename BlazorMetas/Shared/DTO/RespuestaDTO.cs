using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.DTO
{
    public class RespuestaDTO
    {
        public string Mensaje { get; set; }
        public string Titulo { get; set; }
        public Tipo Tipo { get; set; }
    }
    public enum Tipo
    {  //
       // Resumen:
       //     Notificar al usuario que ocurrio un problema con la acción ejecutada.
        Error,
        //
        // Resumen:
        //     Notificar al usuario cualquier información o indicación posterior a la acción ejectuda.
        Informativo,
        //
        // Resumen:
        //      Notificar al usuario que la acción se realizó correctamente.
        Exitoso,
        //
        // Resumen:
        //    Mostrar un mensaje de advertencia derivado de una acción.
        Advertencia
    }
}
