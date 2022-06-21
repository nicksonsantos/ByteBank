using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        private AutenticacaoHelper autenticacaoHelper = new AutenticacaoHelper();
        public string Login { get; set; }
        public string Senha { get; set; }
        public FuncionarioAutenticavel(string nome, string cpf, double salario) : base(nome, cpf, salario)
        {
            Nome = nome;
            Cpf = cpf;
            Salario = salario;
            TotalDeFuncionarios++;
        }
        public bool Autenticar(string login, string senha)
        {
            return autenticacaoHelper.CompararLogins(Login, login) && autenticacaoHelper.CompararSenhas(Senha, senha);
        }
    }
}
