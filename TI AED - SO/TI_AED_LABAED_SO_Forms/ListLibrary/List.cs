using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary
{
    /// <summary>
    /// Classe para uma lista duplamente encadeada, contém métodos virtuais da estrutura e pode ser herdada em uma estrutura de dados
    /// </summary>
    public class List : IStructure
    {
        private Element first, last;
        int count;

        /// <summary>
        /// Inicializa uma nova instância de lista duplamente encadeada que está vazia e tem a capacidade inicial padrão
        /// </summary>
        public List()
        {
            this.first = new Element(null); //sentinela, o primeiro elemento é nulo.
            this.last = this.first; // A lista está vazia, logo, o primeiro e o último aponta para o nulo
            count = 0; // lista vazia
        }

        public int Count { get => count; }
        protected Element First { get => first; set => first = value; }
        protected Element Last { get => last; set => last = value; }

        

        /// <summary>
        /// Adicionar um objeto no final da lista
        /// </summary>
        /// <param name="Obj">Objeto Data.</param>
        public virtual void AddEnd(Data Obj)
        {
            if (Obj != null)
            {
                this.last.next = new Element(Obj);
                this.last.next.previous = this.last;
                this.last = this.last.next;
                this.count++;
            }
            else throw new ArgumentException("O parâmetro é nulo", "Obj");

        }
        /// <summary>
        /// Adicionar um objeto na lista de modo ordenado.
        /// </summary>
        /// <param name="Obj">Objeto Data.</param>
        public virtual void AddSorted(Data Obj)
        {
            if (Obj != null)
            {
                Element _new = new Element(Obj);
                if (this.Empty())
                {
                    _new.next = this.first.next;
                    _new.previous = this.first;
                    this.first.next = _new;
                    this.last = this.first.next;
                }
                else
                {
                    Element aux = this.first.next; //auxiliar para percorrer a lista
                    while (aux != null) //enquanto o aux não é o último da lista, percorre a lista.
                    {
                        if (aux.CompareTo(_new) <= 0 )
                        {
                            _new.next = aux.next;
                            _new.previous = aux;
                            aux.next = _new;
                            if (aux == this.last)
                            {
                                this.last = aux.next;
                            }
                            break;
                        }
                        else if (aux.CompareTo(_new) > 0)
                        {
                            _new.next = aux;
                            _new.previous = aux.previous;
                            aux.previous.next = _new;
                            aux.previous = _new;
                            break;
                        }
                        aux = aux.next;
                    }
                }
                this.count++;
            }
            else throw new ArgumentException("O parâmetro é nulo", "Obj");
        }

        /// <summary>
        /// Adicionar um objeto no início da lista.
        /// </summary>
        /// <param name="Obj">Objeto Data.</param>
        public virtual void AddStart(Data Obj)
        {
            if (Obj != null)
            {
                Element _new = new Element(Obj);
                _new.next = this.first.next;
                _new.previous = this.first;
                if (this.Empty())
                {  
                    this.first.next = _new;
                    this.last = this.first.next;
                }
                else
                {
                    _new.next.previous = _new;
                    this.first.next = _new;
                }
                this.count++;
            }
            else throw new ArgumentException("O parâmetro é nulo", "Obj");
        }
        /// <summary>
        /// Remove todos os elementos da atual instância.
        /// </summary>
        public void Clear()
        {
            this.first = new Element(null); //sentinela, o primeiro elemento é nulo.
            this.last = this.first; // A lista está vazia, logo, o primeiro e o último aponta para o nulo
            count = 0; // lista vazia
        }
        /// <summary>
        /// Concatenar uma 'list' ao final da atual instância.
        /// </summary>
        /// <param name="list">Objeto List.</param>
        public virtual void Concat(List list)
        {
            if (!list.Empty())
            {
                this.last.next = list.first.next;
                this.last.next.previous = this.last;
                this.last = list.last;
                this.count += list.Count;
                list.Clear();
            }
            else
            {
                throw new ArgumentException("list está vazia");
            }
        }
        /// <summary>
        /// Copia todo os elementos 'list' para essa instância, sobrescrevendo todos os elementos atuais. 
        /// </summary>
        /// <param name="list">Objeto list</param>
        public virtual void Copy(List list)
        {
            if (!list.Empty())
            {
                Element auxList = list.first.next; //auxiliar para percorrer a lista
                while (auxList != null) //enquanto o aux não é o último da lista, percorre a lista.
                {
                    this.AddEnd(auxList.Data);
                    auxList = auxList.next;
                }
            }
            else
            {
                throw new ArgumentException("list está vazia");
            }
        }

        /// <summary>
        /// Encontrar um objeto 'Obj' na lista.
        /// </summary>
        /// <param name="Obj">Objeto Data</param>
        /// <returns>Se o 'Obj' existir, o mesmo é retonardo da atual instância; caso contrário, é retornado 'null'</returns>
        public virtual Data Find(Data Obj)
        {
            Element aux = this.first.next; //auxiliar para percorrer a lista
            while (aux != null) //enquanto o aux não é o último da lista, percorre a lista.
            {
                if (aux.Data.Equals(Obj))
                {
                    return aux.Data;
                }
                else
                {
                    aux = aux.next;
                }
            }
            return null;
        }
        /// <summary>
        /// Remover da atual instância o objeto 'Obj'
        /// </summary>
        /// <param name="Obj">Objeto Data</param>
        /// <returns>Se o objeto 'Obj' existir, o mesmo é removido da atual instância e retonardo; caso contrário, é retornado 'null'</returns>
        public virtual Data Remove(Data Obj)
        {
            Element aux = this.first.next; //auxiliar para percorrer a lista
            while (aux != null) //enquanto o aux não é o último da lista, percorre a lista.
            {
                if (aux.Data.Equals(Obj))
                {
                    aux.previous.next = aux.next;
                    if (aux != this.last)
                    {
                        aux.next.previous = aux.previous;
                    }
                    else
                    {
                        this.last = aux.previous;
                    }
                    aux.next = aux.previous = null;
                    this.count--; // atualiza a quantidade de elementos da lista
                    return aux.Data;
                }
                else
                {
                    aux = aux.next;
                }
            }
            return null;
        }
        /// <summary>
        /// Remover da atual instância o primeiro objeto
        /// </summary>
        /// <returns>Se a atual instância não estiver vázia, o primeiro objeto é removido da atual instância e retonardo; caso contrário, é retornado 'null'</returns>
        public virtual Data RemoveStart()
        {
            if (!this.Empty())
            {
                Element aux = this.first.next; //auxiliar para percorrer a lista
                
                if (aux != this.last)
                {
                    aux.previous.next = aux.next;
                    aux.next.previous = aux.previous;
                    count--; // atualiza a quantidade de elementos da lista
                }
                else
                {
                    //this.last = aux.previous;
                    this.Clear();
                    //this.first.next = null;
                    //this.last = this.first;
                }
                aux.next = aux.previous = null;
                return aux.Data;

            }
            return null;
        }
        /// <summary>
        /// Remover da atual instância o último objeto
        /// </summary>
        /// <returns>Se a atual instância não estiver vázia, o último objeto é removido da atual instância e retonardo; caso contrário, é retornado 'null'</returns>
        public virtual Data RemoveEnd()
        {
            if (!this.Empty())
            {
                Element aux = this.last; //auxiliar para percorrer a lista
                if (aux != this.first.next)
                {                    
                    aux.previous.next = null;
                    this.last = aux.previous;
                    count--; // atualiza a quantidade de elementos da lista
                }
                else
                {
                    this.Clear();                  
                }
                aux.next = aux.previous = null;
                return aux.Data;

            }
            return null;
        }
        /// <summary>
        /// Ordena os elementos em toda a lista usando o comparador padrão 'IComparable<T>' de cada elemento da lista.
        /// </summary>
        public void Sort()
        {

            if (!Empty())
            {
                int qtd = Count;
                Data[] auxVetor = new Data[qtd];
                for (int i = 0; i < qtd; i++)
                {
                    auxVetor[i] = RemoveEnd();
                }
                Array.Sort(auxVetor);
                for (int i = 0; i < qtd; i++)
                {
                    this.AddEnd(auxVetor[i]);
                }
            }

        }
        //private static void QuickSort(int low, int high)
        //{

        //}

        /// <summary>
        /// Indica se a atual instância está vazia ou não.
        /// </summary>
        /// <returns>True se a atual instância estiver vazia; caso contrário, False.</returns>
        public bool Empty()
        {
            return (this.first == this.last);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retorna uma cadeia de caracteres que representa o objeto atual</returns>
        public override string ToString()
        {
            Element aux = this.first.next;
            StringBuilder _return = new StringBuilder();
            while (aux != null)
            {
                _return.AppendFormat(aux.Data.ToString());
                aux = aux.next;
            }
            return _return.ToString();
        }


    }
}
