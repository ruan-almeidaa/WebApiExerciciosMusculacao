using Entities.Dtos;
using Domain.Interfaces.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioService _exercicioService;
        private readonly IOrquestracaoService _orquestracaoService;

        public ExercicioController(IExercicioService exercicioService, IOrquestracaoService orquestracaoService)
        {
            _exercicioService = exercicioService;
            _orquestracaoService = orquestracaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExercicioDTO>>> BuscarTodos()
        {
            try
            {
                List<ExercicioDTO> exerciciosEncontrados = await _orquestracaoService.BuscarTodosExercicios();
                if (!exerciciosEncontrados.Any()) return NoContent();
                return Ok(exerciciosEncontrados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExercicioDTO>> BuscarPorId(int id)
        {
            try
            {
                ExercicioDTO exercicioEncontrado = await _orquestracaoService.BuscarExercicioPorId(id);

                if (exercicioEncontrado==null) return NotFound($"Exercício com o ID {id} não foi encontrado.");
                return Ok(exercicioEncontrado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ExercicioDTO>> Criar(Exercicio exercicio)
        {
            try
            {
                return Ok(await _exercicioService.Criar(exercicio));
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ExercicioDTO>> Editar(Exercicio exercicio)
        {
            try
            {
                return Ok(await _orquestracaoService.EditarExercicio(exercicio));
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<object> Excluir(Exercicio exercicio)
        {
            try
            {
                await _exercicioService.Excluir(exercicio);
                return true;
            }
            catch (Exception ex) 
            {

                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
