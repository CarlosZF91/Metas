using BlazorMetas.Shared.DTO;
using BlazorMetas.Shared.IDA;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMetas.Shared.Validaciones
{
    public class MetaValidacion:AbstractValidator<MetaDTO>
    {
        public MetaValidacion(/*IMetasDAL metasDAL*/)
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es es requerido.");
            RuleFor(x => x.Nombre).MaximumLength(80).WithMessage("nombre limitado a 80 caracteres");
            //RuleFor(x => x).Must(x => !IsDuplicate(x.Nombre));

        }

        //private bool IsDuplicate(string r)
        //{
        //    var business = ApplicationDbContext.tblMetas.Where(X=>X.Nombre==r).Any();
        //    return business;
        //}
    }
}
