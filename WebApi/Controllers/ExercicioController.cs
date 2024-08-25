using Entities.Dtos;
using Domain.Interfaces.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioService _exercicioService;

        public ExercicioController(IExercicioService exercicioService)
        {
            _exercicioService = exercicioService;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<ExercicioDTO>>> BuscarTodos()
        {
            try
            {
                return Ok(await _exercicioService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
           
        }

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

        [HttpPut]
        public async Task<ActionResult<ExercicioDTO>> Editar(Exercicio exercicio)
        {
            try
            {
                return Ok(await _exercicioService.Editar(exercicio));
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

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
