using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Validation
{
    public class VariacaoExercicioDtoValidation : AbstractValidator<VariacaoExercicioDTO>
    {
        public VariacaoExercicioDtoValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage("Campo obrigatório");
            RuleFor(v => v.ExercicioId)
                .GreaterThan(0)
                .WithMessage("O IdExercicio deve ser maior que 0.");
        }
    }
}
