using Domain.Interfaces.IRepositories;
using Entities.Dtos;
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
    public class VariacaoRepository : IVariacaoRepository
    {
        private readonly BancoContext _bancoContext;
        public VariacaoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<List<VariacaoExercicio>> BuscarVariacoesExercicio(ExercicioDTO exercicio)
        {
            try
            {
               return await _bancoContext.VariacoesExercicios
                    .Where(v => v.Exercicio.Id == exercicio.Id)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
