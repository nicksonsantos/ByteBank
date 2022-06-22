using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        private string _argumentos { get; }
        public string URL { get; }
        public ExtratorValorDeArgumentosURL(string url)
        {
            if(String.IsNullOrEmpty(url))
                throw new ArgumentNullException("O argumento url não pode ser nulo ou vazio.", nameof(url));

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            URL = url;
        }

        public string GetValor(string nomeParametro)
        {
            nomeParametro = nomeParametro.ToUpper();
            string argumentoEmCaixaAlta = _argumentos.ToUpper();

            string termo = nomeParametro + "=";
            int indiceParametro = argumentoEmCaixaAlta.IndexOf(termo);

            int indiceValor = indiceParametro + termo.Length;            
            string resultado = _argumentos.Substring(indiceValor);
            int indiceEComercial = resultado.IndexOf('&');

            if (indiceEComercial == -1)
                return resultado;

            return resultado.Remove(indiceEComercial);
        }

    }
}
