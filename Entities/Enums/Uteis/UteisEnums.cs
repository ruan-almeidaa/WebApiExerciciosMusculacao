using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Uteis
{
    public static class UteisEnums
    {
        public static string BuscaDescricao(Enum @enum)
        {
            // Obtém o campo do enum
            var campo = @enum.GetType().GetField(@enum.ToString());

            // Obtém o atributo DisplayAttribute
            var atributo = campo.GetCustomAttribute<DisplayAttribute>();

            // Retorna a descrição se o atributo existir, caso contrário, o nome do enum
            return atributo?.Name ?? @enum.ToString();
        }
    }
}
