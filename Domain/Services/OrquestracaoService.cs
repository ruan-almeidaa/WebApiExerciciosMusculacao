using AutoMapper;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IMapper _mapper;
        public OrquestracaoService(IVariacaoService variacaoService, IExercicioService exercicioService, IMapper mapper)
        {
            _variacaoService = variacaoService;
            _exercicioService = exercicioService;
            _mapper = mapper;
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

        public async Task<List<ExercicioDTO>> BuscarTodosExercicios()
        {
            try
            {
                List<ExercicioDTO> exerciciosDto = await _exercicioService.BuscarTodos();
                foreach (ExercicioDTO exercicio in exerciciosDto)
                {
                    exercicio.VariacaoExercicios = await _variacaoService.BuscarVariacoesExercicio(exercicio);
                }
                return exerciciosDto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<VariacaoExercicio> CriarVariacaoExercicio(VariacaoExercicioDTO variacaoExercicioDTO)
        {
            try
            {
                //Primeiro converte o DTO na entidade
                VariacaoExercicio variacaoExercicio = _mapper.Map<VariacaoExercicio>(variacaoExercicioDTO);

                await _variacaoService.Criar(variacaoExercicio);

                //Busca o DTO do exercicio para qual a variação pertence
                ExercicioDTO exercicioDTO = await _exercicioService.BuscarPorId(variacaoExercicioDTO.ExercicioId);
                //Seta o exercicio da entidade de variacao, fazendo a conversão do DTO.
                variacaoExercicio.Exercicio = _mapper.Map<Exercicio>(exercicioDTO);
                return variacaoExercicio;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ExercicioDTO> EditarExercicio(Exercicio exercicio)
        {
            try
            {
                ExercicioDTO exercicioEditado = await _exercicioService.Editar(exercicio);
                exercicioEditado.VariacaoExercicios = await _variacaoService.BuscarVariacoesExercicio(exercicioEditado);
                return exercicioEditado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
