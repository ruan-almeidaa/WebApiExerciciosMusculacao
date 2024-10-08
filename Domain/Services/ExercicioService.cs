﻿using AutoMapper;
using Entities.Dtos;
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

        public async Task<ExercicioDTO> BuscarPorId(int id)
        {
            try
            {
                Exercicio exercicio = await _exercicioRepository.BuscarPorId(id);
                return _mapper.Map<ExercicioDTO>(exercicio);
            }
            catch (Exception)
            {

                throw;
            }
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
                return _mapper.Map<ExercicioDTO>(exercicioCriado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ExercicioDTO> Editar(Exercicio exercicio)
        {
            try
            {
                Exercicio exercicioEditado =  await _exercicioRepository.Editar(exercicio);
                return _mapper.Map<ExercicioDTO>(exercicioEditado);
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

        public Task<bool> VerificarSeExiste(int id)
        {
            try
            {
                return _exercicioRepository.VerificarSeExiste(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
