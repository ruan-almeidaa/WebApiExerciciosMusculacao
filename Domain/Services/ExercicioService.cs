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
        public ExercicioService(IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
        }
        public async Task<List<Exercicio>> BuscarTodos()
        {
            try
            {
                return await _exercicioRepository.BuscarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Criar(Exercicio exercicio)
        {
            try
            {
               await _exercicioRepository.Criar(exercicio);
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
