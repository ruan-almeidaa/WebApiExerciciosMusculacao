using Domain.Interfaces.IServices;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrquestracaoService : IOrquestracaoService
    {
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoService _variacaoService;
        public OrquestracaoService(IVariacaoService variacaoService, IExercicioService exercicioService)
        {
            _variacaoService = variacaoService;
            _exercicioService = exercicioService;
        }

        public async Task<ExercicioDTO> BuscarExercicioPorId(int id)
        {
            try
            {
                ExercicioDTO exercicio = await _exercicioService.BuscarPorId(id);
                exercicio.VariacaoExercicios = await _variacaoService.BuscarVariacoesExercicio(exercicio);
                return exercicio;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
