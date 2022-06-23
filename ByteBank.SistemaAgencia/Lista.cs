using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Lista <T>
    {
        private T[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }
        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        public Lista(int tamanhoLista = 1)
        {
            _itens = new T[tamanhoLista];
            _proximaPosicao = 0;
        }

        public void Adicionar(T item)
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
                    T[] novoItens = new T[tamanhoLista * 2];

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

        public void Remover(T item)
        {
            int indiceItem = Encontra(item);

            for (int i = indiceItem; i < (_proximaPosicao - 1); i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            //_itens[_proximaPosicao] = null;
        }

        public int Encontra(T item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                T itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            return indiceItem;
        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
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
