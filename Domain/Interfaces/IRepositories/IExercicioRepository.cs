﻿using Entities.Entities;
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
        Task Criar(Exercicio exercicio);
        Task Editar(Exercicio exercicio);
        Task Excluir (Exercicio exercicio);
    }
}
