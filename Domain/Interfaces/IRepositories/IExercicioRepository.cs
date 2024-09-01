using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IExercicioRepository
    {
        Task<List<Exercicio>> BuscarTodos();
        Task<Exercicio> Criar(Exercicio exercicio);
        Task<Exercicio> Editar(Exercicio exercicio);
        Task Excluir (Exercicio exercicio);
        Task<Exercicio> BuscarPorId(int id);
        Task<bool> VerificarSeExiste(int id);
    }
}
