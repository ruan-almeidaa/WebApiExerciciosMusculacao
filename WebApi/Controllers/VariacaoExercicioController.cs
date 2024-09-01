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
    public class VariacaoExercicioController : ControllerBase
    {
        private readonly IVariacaoService _variacaoService;
        private readonly IOrquestracaoService _orquestracaoService;

        public VariacaoExercicioController(IVariacaoService variacaoService, IOrquestracaoService orquestracaoService)
        {
            _variacaoService = variacaoService;
            _orquestracaoService = orquestracaoService;
        }

        [HttpPost]
        public async Task<ActionResult<VariacaoExercicio>> Criar(VariacaoExercicioDTO variacaoExercicioDTO)
        {
            try
            {
                return Ok(await _orquestracaoService.CriarVariacaoExercicio(variacaoExercicioDTO));
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<VariacaoExercicio>> Editar(VariacaoExercicioDTO variacaoExercicioDTO)
        {
            try
            {
                return Ok(await _orquestracaoService.EditarVariacaoExercicio(variacaoExercicioDTO));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
