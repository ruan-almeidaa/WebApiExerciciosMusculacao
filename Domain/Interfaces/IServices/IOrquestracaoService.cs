﻿using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IOrquestracaoService
    {
        Task<ExercicioDTO> BuscarExercicioPorId(int id);
        Task<List<ExercicioDTO>> BuscarTodosExercicios();
        Task<ExercicioDTO> EditarExercicio(Exercicio exercicio);
        Task<VariacaoExercicio> CriarVariacaoExercicio(VariacaoExercicioDTO variacaoExercicioDTO);
        Task<VariacaoExercicio> EditarVariacaoExercicio(VariacaoExercicioDTO variacaoExercicioDTO);
    }
}
