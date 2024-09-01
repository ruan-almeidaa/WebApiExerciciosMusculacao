using Domain.Interfaces.IRepositories;
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
    public class VariacaoService : IVariacaoService
    {
		private readonly IVariacaoRepository _variacaoRepository;
		public VariacaoService(IVariacaoRepository variacaoRepository)
        {
            _variacaoRepository = variacaoRepository;
        }

        public async Task<List<VariacaoExercicio>> BuscarVariacoesExercicio(ExercicioDTO exercicio)
        {
			try
			{
                return await _variacaoRepository.BuscarVariacoesExercicio(exercicio);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<VariacaoExercicio> Criar(VariacaoExercicio variacaoExercicio)
        {
			try
			{
				variacaoExercicio.Exercicio = null;
                return await _variacaoRepository.Criar(variacaoExercicio);
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
