using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IVariacaoService
    {
        Task<List<VariacaoExercicio>> BuscarVariacoesExercicio(ExercicioDTO exercicio);
        Task<VariacaoExercicio> Criar(VariacaoExercicioDTO variacaoExercicioDto);
    }
}
