﻿using Domain.Interfaces.IServices;
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
        private readonly ILoginService _loginService;
        public LoginController(ILoginService iloginService)
        {
            _loginService = iloginService;
        }

        [HttpPost]
        public async Task<ActionResult<String>> Autenticar(LoginDTO login)
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
