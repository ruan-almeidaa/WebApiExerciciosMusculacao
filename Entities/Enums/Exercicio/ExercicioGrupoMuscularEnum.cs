using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Exercicio
{
    public enum ExercicioGrupoMuscularEnum
    {
        [Description("Peito")]
        Peito = 1,

        [Description("Costas")]
        Costas,

        [Description("Ombros")]
        Ombros,

        [Description("Bíceps")]
        Biceps,

        [Description("Tríceps")]
        Triceps,

        [Description("Quadríceps")]
        Quadriceps,

        [Description("Posterior de Coxa")]
        PosteriorCoxa,

        [Description("Glúteos")]
        Gluteos,

        [Description("Panturrilha")]
        Panturrilha,

        [Description("Abdômen")]
        Abdomen,

        [Description("Trapézio")]
        Trapezio
    }
}
