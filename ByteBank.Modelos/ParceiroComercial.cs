using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class ParceiroComercial : IAutenticavel
    {
        private AutenticacaoHelper autenticacaoHelper = new AutenticacaoHelper();
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Autenticar(string login, string senha)
        {
            return autenticacaoHelper.CompararLogins(Login, login) && autenticacaoHelper.CompararSenhas(Senha, senha); 
        }

    }
}
