using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        private string argumentos { get; }
        public string URL { get; }
        public ExtratorValorDeArgumentosURL(string url)
        {
            if(String.IsNullOrEmpty(url))
                throw new ArgumentNullException("O argumento url não pode ser nulo ou vazio.", nameof(url));

            int indiceInterrogacao = url.IndexOf('?');
            argumentos = url.Substring(indiceInterrogacao + 1);

            URL = url;
        }

        // moedaOrigem=real&moedaDestino=dolar
        public string GetValor(string nomeParametro)
        {
            int indiceParametro = argumentos.IndexOf(nomeParametro);

            int indiceValor = indiceParametro + 1 + nomeParametro.Length;

            return argumentos.Substring(indiceValor);
        }

    }
}
