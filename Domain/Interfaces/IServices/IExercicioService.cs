using Domain.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IExercicioService
    {
        Task<List<ExercicioDTO>> BuscarTodos();
        Task<ExercicioDTO> Criar(Exercicio exercicio);
        Task<ExercicioDTO> Editar(Exercicio exercicio);
        Task Excluir(Exercicio exercicio);
    }
}
