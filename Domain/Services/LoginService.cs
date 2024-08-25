using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos;
using Entities.Entities;
using Helpers.Criptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class LoginService : IloginService
    {
		private readonly ILoginRepository _loginRepository;
		public LoginService(ILoginRepository loginRepository)
		{
			_loginRepository = loginRepository;
		}
        public async Task<Usuario> Autenticar(LoginDTO login)
        {
            try
            {
				login.Senha = Criptografia.GerarHash(login.Senha);
                Login loginAutenticado = await _loginRepository.Autenticar(login);
				return loginAutenticado.Usuario;
				
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
