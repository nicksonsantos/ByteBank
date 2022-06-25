using ByteBank.ImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.ImportacaoExportacao
{
    public static class ListExtensions
    {
        public static string ExibeListaContas(this List<ContaCorrente> listaContaCorrente)
        {
            string textoSaida = string.Empty;

            foreach (var conta in listaContaCorrente)
            {
                textoSaida += conta.ToString();
            }

            return textoSaida;
        }
    }
}
