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
    public class LoginRepository : ILoginRepository
    {
        private readonly BancoContext _bancoContext;

        public LoginRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<Login> Autenticar(LoginDTO login)
        {
            try
            {
                return await _bancoContext.Logins
                    .Where(l => l.Email == login.Email && l.Senha == login.Senha)
                    .Include(l => l.Usuario)
                    .FirstOrDefaultAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
