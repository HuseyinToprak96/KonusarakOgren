using FluentValidation;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Service.Validations
{
    public class VisitorValidation: AbstractValidator<Visitor>
    {
        public VisitorValidation()
        {
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Not Empty");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Not Empty");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Not Empty!");
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("Not Empty!");
        }
    }
}
