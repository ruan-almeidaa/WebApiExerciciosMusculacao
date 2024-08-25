using Domain.Interfaces.IServices;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IloginService _loginService;
        public LoginController(IloginService iloginService)
        {
            _loginService = iloginService;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Autenticar(LoginDTO login)
        {
            try
            {
                return Ok(await _loginService.Autenticar(login));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
