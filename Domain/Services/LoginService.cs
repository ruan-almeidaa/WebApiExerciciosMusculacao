using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos;
using Entities.Entities;
using Shared.Criptografia;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Shared.VariaveisAmbiente;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Domain.Services
{
    public class LoginService : ILoginService
    {
		private readonly ILoginRepository _loginRepository;
		private readonly IVariaveisService _variaveisService;
		public LoginService(ILoginRepository loginRepository, IVariaveisService variaveisService)
		{
			_loginRepository = loginRepository;
			_variaveisService = variaveisService;
		}
        public async Task<String> Autenticar(LoginDTO login)
        {
            try
            {
				login.Senha = Criptografia.GerarHash(login.Senha);
                Login loginAutenticado = await _loginRepository.Autenticar(login);
				if(loginAutenticado == null) throw new InvalidOperationException("Credenciais inválidas para autenticação. Verifique emaail e senha.");
                return await GerarToken(loginAutenticado.Usuario);
				
			}
			catch (Exception)
			{

				throw;
			}
        }

		private async Task<string> GerarToken(Usuario usuario)
		{
			Variaveis variaveis = await _variaveisService.BuscarVariaveisAmbiente();

            if (variaveis == null)
            {
                throw new InvalidOperationException("Variáveis de ambiente não foram encontradas.");
            }

            string chaveToken = variaveis.ChaveToken ?? throw new ArgumentNullException(nameof(variaveis.ChaveToken), "ChaveToken não pode ser nula.");
            string issuerToken = variaveis.IssuerToken ?? throw new ArgumentNullException(nameof(variaveis.IssuerToken), "IssuerToken não pode ser nula.");
            string audienceToken = variaveis.AudienceToken ?? throw new ArgumentNullException(nameof(variaveis.AudienceToken), "AudienceToken não pode ser nula.");

            var claims = new[]
			{
				new Claim("nome", usuario.Nome),
				new Claim("id", usuario.Id.ToString())
			};


			var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveToken));
			var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: issuerToken,
				audience: audienceToken,
				claims: claims,
				expires: DateTime.Now.AddHours(100),
				signingCredentials: credencial
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
