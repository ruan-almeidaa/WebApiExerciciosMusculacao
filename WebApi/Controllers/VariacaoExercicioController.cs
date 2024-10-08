﻿using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

        [Authorize]
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
        [Authorize]
        [HttpDelete]
        public async Task<object> Excluir(VariacaoExercicioDTO variacaoExercicioDTO)
        {
            try
            {
                await _variacaoService.Excluir(variacaoExercicioDTO);
                return true;
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

    }
}
