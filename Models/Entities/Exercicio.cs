using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Exercicio
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Musculo { get; set; }
    }
}
