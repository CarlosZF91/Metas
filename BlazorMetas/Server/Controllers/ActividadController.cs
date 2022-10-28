using BlazorMetas.Shared.DTO;
using BlazorMetas.Shared.IDA;
using BlazorMetas.Shared.Persistenacia;
using BlazorMetas.Shared.Validaciones;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace BlazorMetas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        public ActividadController(IActividadesDAL actividadesDAL)
        {
            ActividadesDAL = actividadesDAL;
        }

        public IActividadesDAL ActividadesDAL { get; }




        [HttpPost("Crear")]
        public RespuestaDTO Crear(ActividadDTO actividadDTO)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();


            ValidationResult result = new ActividadValidacion().Validate(actividadDTO);

            if (result.IsValid)
            {
                actividadDTO.Id = Guid.NewGuid().ToString();
                actividadDTO.FechaCreacion = DateTime.Now;
                var resultadoDeGuardar = ActividadesDAL.Crear(actividadDTO.Adapt<tblActividad>());

                if (resultadoDeGuardar)
                {
                    respuestaDTO.Tipo = Tipo.Exitoso;
                }
                else
                {
                    respuestaDTO.Tipo = Tipo.Error;
                }

            }
            else
            {
                respuestaDTO.Tipo = Tipo.Error;
            }

            return respuestaDTO;
        }

        [HttpPut("Editar")]
        public RespuestaDTO Editar(ActividadDTO actividadDTO)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();


            ValidationResult result = new ActividadValidacion().Validate(actividadDTO);

            if (result.IsValid)
            {

                var resultadoDeGuardar =  ActividadesDAL.Editar(actividadDTO.Adapt<tblActividad>());

                if (resultadoDeGuardar)
                {
                    respuestaDTO.Tipo = Tipo.Exitoso;
                }
                else
                {
                    respuestaDTO.Tipo = Tipo.Error;
                }

            }
            else
            {
                respuestaDTO.Tipo = Tipo.Error;
            }

            return respuestaDTO;
        }

        [HttpPost("Eliminar")]
        public RespuestaDTO Delete(List<string> ids)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();

            bool resultadoEliminacion =  ActividadesDAL.Eliminar(ids);

            if (resultadoEliminacion)
            {
                respuestaDTO.Tipo = Tipo.Exitoso;
            }
            else
            {
                respuestaDTO.Tipo = Tipo.Error;
            }

            return respuestaDTO;
        }

        [HttpPost("Concluir")]
        public RespuestaDTO Concluir(List<string> ids)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();
            int concluidas = 0;

            foreach (var id in ids)
            {
                var resultado =  ActividadesDAL.Concluir(id);

                if (resultado)
                {

                    concluidas++;
                }

            }


            if (concluidas > 0)
            {
                respuestaDTO.Tipo = Tipo.Exitoso;
            }
            else
            {
                respuestaDTO.Tipo = Tipo.Error;
            }

            return respuestaDTO;
        }
        [HttpGet("ObtenerActividadesPorMeta")]
        public List<ActividadDTO> ObtenerMetas(string id)
        {
            try
            {
                var resultado = ( (ActividadesDAL.ObtenerActividadesPorMeta(id))).Adapt<List<ActividadDTO>>();

                return resultado;

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("ObtenerActividad")]
        public ActividadDTO ObtenerMeta(string id)
        {
            return ( (ActividadesDAL.ObtenerActividadPorId(id))).Adapt<ActividadDTO>();
        }

        [HttpGet("Destacar")]
        public RespuestaDTO Destacar(string id)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();

            bool resultado =  ActividadesDAL.Destacar(id);

            if (resultado)
            {
                respuestaDTO.Tipo = Tipo.Exitoso;
            }
            else
            {
                respuestaDTO.Tipo = Tipo.Error;
            }

            return respuestaDTO;
        }
    }
}
