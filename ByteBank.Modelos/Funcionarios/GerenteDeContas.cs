using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public class GerenteDeContas : FuncionarioAutenticavel
    {
        public GerenteDeContas(string nome, string cpf, double salario) : base(nome, cpf, salario)
        {
            Nome = nome;
            Cpf = cpf;
            Salario = salario;
        }

        public override void AumentarSalario()
        {
            Salario = Salario * 1.05;
        }

        public override double GetBonificacao()
        {
            return Salario * 0.25;
        }

    }
}
