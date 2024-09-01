using Domain.Interfaces.IRepositories;
using Entities.Entities;
using Infra.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly BancoContext _bancoContext;

        public ExercicioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<Exercicio> BuscarPorId(int id)
        {
            try
            {
                return await _bancoContext.Exercicios
                    .Where(e => e.Id == id)
                    .AsNoTracking()
                    .FirstAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Exercicio>> BuscarTodos()
        {
            try
            {
                return await _bancoContext.Exercicios.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Exercicio> Criar(Exercicio exercicio)
        {
            try
            {
                // Adiciona a entidade ao contexto
                await _bancoContext.Exercicios.AddAsync(exercicio);
                // Salva as mudanças no banco de dados
                await _bancoContext.SaveChangesAsync();
                // Retorna a entidade criada
                return exercicio;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Exercicio> Editar(Exercicio exercicio)
        {
            try
            {
                _bancoContext.ChangeTracker.Clear();
                _bancoContext.Exercicios.Update(exercicio);
                await _bancoContext.SaveChangesAsync();
                return exercicio;

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
                _bancoContext.Exercicios.Remove(exercicio);
                await _bancoContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VerificarSeExiste(int id)
        {
            try
            {
                return await _bancoContext.Exercicios
                        .AnyAsync(e => e.Id == id);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
