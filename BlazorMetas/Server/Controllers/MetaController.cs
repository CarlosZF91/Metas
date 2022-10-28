using Autofac.Features.Metadata;
using BlazorMetas.Shared.DA;
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
    public class MetaController : ControllerBase
    {
        public MetaController(IMetasDAL metasDAL)
        {
            MetasDAL = metasDAL;
        }

        public IMetasDAL MetasDAL { get; }

       
        [HttpPost("Crear")]
        public  RespuestaDTO Crear(MetaDTO metaDTO)
        {

            RespuestaDTO respuestaDTO = new RespuestaDTO();

            ValidationResult result = new MetaValidacion().Validate(metaDTO);

            if (result.IsValid)
            {
                metaDTO.Id = Guid.NewGuid().ToString();
                metaDTO.FechaCreacion = DateTime.Now;
                var resultadoDeGuardar =  MetasDAL.Crear(metaDTO.Adapt<tblMetas>());

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
        public RespuestaDTO Editar(MetaDTO metaDTO)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();

            ValidationResult result = new MetaValidacion().Validate(metaDTO);

            if (result.IsValid)
            {
                var resultadoActualizacion = MetasDAL.Editar(metaDTO.Adapt<tblMetas>());

                if (resultadoActualizacion)
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

        [HttpDelete("Eliminar")]
        public RespuestaDTO Delete(string id)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();

            bool resultadoEliminacion = MetasDAL.Eliminar(new tblMetas { Id = id });

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


        //#region HttpGet
        //[HttpGet("ExisteNombreMeta")]
        //public async Task<ActionResult<bool>> ExisteNombreMeta(string nombre)
        //{
        //    return  MetaCore.ExisteNombreMeta(nombre);
        //}

        [HttpGet("GetMetas")]
        public  List<MetaDTO> GetMetas()
        {
            
            List<MetaDTO> detalles = new List<MetaDTO>();
            try
            {
                var metas = MetasDAL.ObtenerMetas();

                foreach (var meta in metas.OrderByDescending(x => x.FechaCreacion))
                {
                    var actividadesConcluidas = meta.Actividades.Where(x => x.Concluida == true).Count();
                    var totalActividades = meta.Actividades.Count();

                    var porcentaje = totalActividades > 0 ? (100 / totalActividades) * actividadesConcluidas : 0;



                    detalles.Add(
                            new MetaDTO
                            {
                                Id = meta.Id,
                                Nombre = meta.Nombre,
                                FechaCreacion = meta.FechaCreacion,
                                porcentajeAvance = porcentaje,
                                actividadesConcluidas = actividadesConcluidas,
                                totalActividades = totalActividades,

                            }

                        );

                }



            }
            catch (Exception)
            {

                throw;
            }
            return detalles;
        }
        [HttpGet("ObtenerMeta")]
        public MetaDTO ObtenerMeta(string id)
        {
            return  MetasDAL.ObtenerMetaPorId(id).Adapt<MetaDTO>();
        }
    }
}
