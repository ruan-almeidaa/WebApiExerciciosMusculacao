using Domain.Interfaces.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioService _exercicioService;

        public ExercicioController(IExercicioService exercicioService)
        {
            _exercicioService = exercicioService;
            
        }

        [HttpGet("buscarTodos")]
        public async Task<ActionResult<List<Exercicio>>> BuscarTodos()
        {
            try
            {
                List<Exercicio> exercicios = await _exercicioService.BuscarTodos();
                return Ok(exercicios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
           
        }
    }
}
