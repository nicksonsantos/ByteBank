using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        public ListaDeContaCorrente(int tamanhoLista = 1)
        {
            _itens = new ContaCorrente[tamanhoLista];
            _proximaPosicao = 0;
        }

        public void Adicionar(ContaCorrente conta)
        {
            int tamanhoLista = _itens.Length;

            try
            {
                if (tamanhoEhSuficiente(tamanhoLista))
                {
                    _itens[_proximaPosicao] = conta;
                    Console.WriteLine($"Lista - Adicionando item na posicao {_proximaPosicao}");

                } else
                {
                    Console.WriteLine("Lista - Aumentando o tamanho da lista");
                    ContaCorrente[] novoItens = new ContaCorrente[tamanhoLista * 2];

                    Array.Copy(
                        sourceArray: _itens,
                        destinationArray: novoItens,
                        length: _itens.Length);

                    _itens = novoItens;
                    _itens[_proximaPosicao] = conta;
                    Console.WriteLine($"Lista - Adicionando item na posicao {_proximaPosicao}");
                }
                    
                _proximaPosicao++;                
            }
            catch
            {
                throw;
            }
        }

        private bool tamanhoEhSuficiente(int tamanhoLista)
        {
            

            if (_proximaPosicao >= tamanhoLista)
            {
                return false;
            }

            return true;
        }
    }
}
