using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Models.Validations
{
    public class VtexPromocoesValidator : AbstractValidator<Promocoes>
    {
        public VtexPromocoesValidator()
        {
            RuleFor(e => e.Status).NotEmpty();
            
        }
    }
}
