using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class GerenciadorDeBonificacao
    {
        private double TotalBonificacao { get; set; }

        public void Registrar(Funcionario funcionario)
        {
            this.TotalBonificacao += funcionario.GetBonificacao();
        }

        public double GetBonificao()
        {
            return this.TotalBonificacao;
        }
    }
}
