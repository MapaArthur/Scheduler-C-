using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary
{
    /// <summary>
    /// Classe abstrata que contém métodos abstratos para ser herdada em uma estrutura de dados.
    /// </summary>
    public abstract class Data : IComparable<Data>, IEquatable<Data> //Implementa o a interface IComparable para utilizar o Sort da lista, e método Equals() para comparar a igualdade valor
    {
        

        /// <summary>
        /// Compara esta instância com um objeto especificado e indica se essa instância precede, segue ou aparece na mesma posição na ordem de classificação  do objeto especificado.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com o a atual instância</param>
        /// <returns>Menor que zero, esta instância precede 'obj'; zero, esta instância ocorre na mesma posição que 'obj'; maior que zero, esta instância segue 'obj' na ordem de classificão.</returns>
        public abstract int CompareTo(Data obj);
        /// <summary>
        /// Determina se o objeto epecificado é igual ao objeto da atual instância
        /// </summary>
        /// <param name="other">O objeto a ser comparado com o a atual instância</param>
        /// <returns>True se o objeto especificado for igual ao objeto atual; caso contrário, False</returns>
        public abstract bool Equals(Data other);
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retorna uma cadeia de caracteres que representa o objeto atual.</returns>
        public abstract override string ToString();
    }
}
