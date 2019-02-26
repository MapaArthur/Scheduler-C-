using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary
{
    interface IStructure
    {
        /// <summary>
        /// Adicionar um objeto na lista de modo ordenado.
        /// </summary>
        /// <param name="Obj">Objeto Data.</param>
        void AddSorted(Data Obj);
        /// <summary>
        /// Adicionar um objeto no início da lista.
        /// </summary>
        /// <param name="Obj">Objeto Data.</param>
        void AddStart(Data Obj);
        /// <summary>
        /// Adicionar um objeto no final da lista
        /// </summary>
        /// <param name="Obj">Objeto Data.</param>
        void AddEnd(Data Obj);
        /// <summary>
        /// Remove todos os elementos da atual instância.
        /// </summary>
        void Clear();
        /// <summary>
        /// Concatenar uma 'list' ao final da atual instância.
        /// </summary>
        /// <param name="list">Objeto list.</param>
        void Concat(List list);
        /// <summary>
        /// Copia todo os elementos 'list' para essa instância, sobrescrevendo todos os elementos atuais. 
        /// </summary>
        /// <param name="list">Objeto list</param>
        void Copy(List list);
        /// <summary>
        /// Encontrar um obejto 'Data' na lista.
        /// </summary>
        /// <param name="Obj">Objeto Data</param>
        /// <returns>Se o objeto 'Data' existir, o mesmo é retonardo da atual instância; caso contrário, é retornado 'null'</returns>
        Data Find(Data Obj);
        /// <summary>
        /// Remover da atual instância o objeto 'Data'
        /// </summary>
        /// <param name="Obj">Objeto Data</param>
        /// <returns>Se o objeto 'Data' existir, o mesmo é removido da atual instância e retonardo; caso contrário, é retornado 'null'</returns>
        Data Remove(Data Obj);
        /// <summary>
        /// Remover da atual instância o primeiro objeto
        /// </summary>
        /// <returns>Se a atual instância não estiver vázia, o primeiro objeto é removido da atual instância e retonardo; caso contrário, é retornado 'null'</returns>
        Data RemoveStart();

        /// <summary>
        /// Remover da atual instância o último objeto
        /// </summary>
        /// <returns>Se a atual instância não estiver vázia, o último objeto é removido da atual instância e retonardo; caso contrário, é retornado 'null'</returns>
        Data RemoveEnd();
        /// <summary>
        /// Ordena os elementos em toda a lista usando o comparador padrão 'IComparable<T>' de cada elemento da lista
        /// </summary>
        void Sort();
        /// <summary>
        /// Indica se a atual instância está vazia ou não.
        /// </summary>
        /// <returns>True se a atual instância estiver vazia; caso contrário, False.</returns>
        bool Empty();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retorna uma cadeia de caracteres que representa o objeto atual</returns>
        string ToString();

    }
}
