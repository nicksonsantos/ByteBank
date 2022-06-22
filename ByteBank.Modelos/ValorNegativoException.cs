using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class ValorNegativoException : OperacaoFinanceiraException
    {
        public ValorNegativoException()
        {

        }

        public ValorNegativoException(string mensagem):base(mensagem)
        {

        }
    }
}
