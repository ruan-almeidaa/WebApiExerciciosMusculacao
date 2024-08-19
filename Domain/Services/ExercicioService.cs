using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ExercicioService : IExercicioService
    {
        private readonly IExercicioRepository _exercicioRepository;
        private readonly IMapper _mapper;
        public ExercicioService(IExercicioRepository exercicioRepository, IMapper mapper)
        {
            _exercicioRepository = exercicioRepository;
            _mapper = mapper;
        }
        public async Task<List<ExercicioDTO>> BuscarTodos()
        {
            try
            {
                // Busca a lista de exercícios do repositório
                List<Exercicio> exercicios = await _exercicioRepository.BuscarTodos();

                // Mapeia cada Exercicio para ExercicioDTO usando AutoMapper
                List<ExercicioDTO> exercicioDTOs = _mapper.Map<List<ExercicioDTO>>(exercicios);

                // Retorna a lista de ExercicioDTOs
                return exercicioDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ExercicioDTO> Criar(Exercicio exercicio)
        {
            try
            {
                Exercicio exercicioCriado = await _exercicioRepository.Criar(exercicio);
                ExercicioDTO exercicioDto = _mapper.Map<ExercicioDTO>(exercicioCriado);
                return exercicioDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Editar(Exercicio exercicio)
        {
            try
            {
                await _exercicioRepository.Editar(exercicio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Excluir(Exercicio exercicio)
        {
            try
            {
                await _exercicioRepository.Excluir(exercicio);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
