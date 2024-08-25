using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;

namespace Domain.Interfaces.IServices
{
    public interface IloginService
    {
        Task<Usuario> Autenticar(LoginDTO login);
    }
}
