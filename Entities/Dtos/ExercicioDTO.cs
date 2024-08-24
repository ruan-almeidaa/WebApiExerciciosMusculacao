using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ExercicioDTO
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required string GrupoMuscularDescricao { get; set; } 
        public required int GrupoMuscular { get; set; }
    }
}
