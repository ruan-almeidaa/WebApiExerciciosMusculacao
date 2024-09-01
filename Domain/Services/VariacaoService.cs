using AutoMapper;
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
        private readonly IMapper _mapper;
        public VariacaoService(IVariacaoRepository variacaoRepository, IMapper mapper)
        {
            _variacaoRepository = variacaoRepository;
            _mapper = mapper;
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

        public async Task<VariacaoExercicio> Criar(VariacaoExercicioDTO variacaoExercicioDto)
        {
			try
			{
                //Converte o DTO que foi recebido, na entidade
                VariacaoExercicio variacaoExercicio = _mapper.Map<VariacaoExercicio>(variacaoExercicioDto);
                return await _variacaoRepository.Criar(variacaoExercicio);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<VariacaoExercicio> Editar(VariacaoExercicioDTO variacaoExercicioDTO)
        {
            try
            {
                VariacaoExercicio variacaoExercicio = _mapper.Map<VariacaoExercicio>(variacaoExercicioDTO);
                return await _variacaoRepository.Editar(variacaoExercicio);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
