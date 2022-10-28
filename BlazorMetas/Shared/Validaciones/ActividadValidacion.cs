using BlazorMetas.Shared.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.Validaciones
{
    public class ActividadValidacion : AbstractValidator<ActividadDTO>
    {
        public ActividadValidacion()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es es requerido.");
            RuleFor(x => x.Nombre).MaximumLength(80).WithMessage("nombre limitado a 80 caracteres");
        }
    }
}
