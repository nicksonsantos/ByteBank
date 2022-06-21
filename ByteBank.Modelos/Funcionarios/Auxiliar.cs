using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public class Auxiliar : Funcionario
    {
        public Auxiliar(string nome, string cpf, double salario) : base(nome, cpf, salario)
        {
            Nome = nome;
            Cpf = cpf;
            Salario = salario;
        }

        public override void AumentarSalario()
        {
            Salario = Salario * 1.10;
        }

        public override double GetBonificacao()
        {
            return Salario * 0.2;
        }
    }
}
