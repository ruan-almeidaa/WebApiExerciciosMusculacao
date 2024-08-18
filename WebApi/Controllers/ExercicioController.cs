﻿using Domain.Interfaces.IServices;
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

        [HttpPost]
        public async Task<IActionResult> Criar(Exercicio exercicio)
        {
            try
            {
                
                await _exercicioService.Criar(exercicio);
                return Ok(exercicio);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar(Exercicio exercicio)
        {
            try
            {
                await _exercicioService.Editar(exercicio);
                return Ok(exercicio);
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
