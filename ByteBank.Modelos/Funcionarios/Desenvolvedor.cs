using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public class Desenvolvedor : Funcionario
    {
        public Desenvolvedor(string nome, string cpf, double salario) : base(nome, cpf, salario)
        {
            Nome = nome;
            Cpf = cpf;
            Salario = salario;
            TotalDeFuncionarios++;
        }

        public override void AumentarSalario()
        {
            this.Salario = this.Salario * 0.15;
        }

        public override double GetBonificacao()
        {
            return Salario * 0.2;
        }
    }
}
