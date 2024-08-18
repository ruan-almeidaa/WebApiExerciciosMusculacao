using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Validation
{
    public class ExercicioValidation : AbstractValidator<Exercicio>
    {
        public ExercicioValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty()
                .WithMessage("Campo obrigatório");

            RuleFor(e => e.GrupoMuscular)
                .NotEmpty()
                .WithMessage("Campo obrigatório");
        }
    }
}
