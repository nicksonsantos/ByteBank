using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeObject
    {
        private object[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }
        public object this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        public ListaDeObject(int tamanhoLista = 1)
        {
            _itens = new object[tamanhoLista];
            _proximaPosicao = 0;
        }

        public void Adicionar(object item)
        {
            int tamanhoLista = _itens.Length;

            try
            {
                if (tamanhoEhSuficiente(tamanhoLista))
                {
                    _itens[_proximaPosicao] = item;
                    Console.WriteLine($"Lista - Adicionando item na posicao {_proximaPosicao}");

                }
                else
                {
                    Console.WriteLine("Lista - Aumentando o tamanho da lista");
                    object[] novoItens = new object[tamanhoLista * 2];

                    Array.Copy(
                        sourceArray: _itens,
                        destinationArray: novoItens,
                        length: _itens.Length);

                    _itens = novoItens;
                    _itens[_proximaPosicao] = item;
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

        public void Remover(object item)
        {
            int indiceItem = Encontra(item);

            for (int i = indiceItem; i < (_proximaPosicao - 1); i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public int Encontra(object item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                object itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            return indiceItem;
        }

        public object GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public void AdicionarVarios(params object[] itens)
        {
            foreach (object item in itens)
            {
                Adicionar(item);
            }
        }

        public override string ToString()
        {
            string saida = "[";

            for (int i = 0; i < _proximaPosicao; i++)
            {
                saida += _itens[i];

                if (i != (_proximaPosicao - 1))
                    saida += ", ";
            }

            saida += "]";

            return saida;
        }
    }
}
