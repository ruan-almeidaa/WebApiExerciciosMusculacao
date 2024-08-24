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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<Usuario> Autenticar(Usuario usuario)
        {
            try
            {

                return await _bancoContext.Usuarios.FirstOrDefaultAsync
                    (u => u.Email == usuario.Email && u.Senha == usuario.Senha);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
