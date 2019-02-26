using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListLibrary;
using System.Threading;
namespace TI_AED_LABAED_SO_Forms
{
    class ListaExecucao : List
    {
        public ListaExecucao() : base() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantum"></param>
        /// <returns></returns>
        public Processo ExecutarProcesso(int quantum)
        {
            Processo aux = (Processo)this.First.Next.Data;
            if (!this.Empty())
            {
                
                if (aux.Tempo <= quantum)
                {
                    aux.Ciclos -= 1 * quantum;
                    Thread.Sleep(Convert.ToInt32(aux.Tempo * (1000*quantum)));
                }
                if (aux.Ciclos <= 0)
                {
                    this.RemoveStart();
                    return null;
                }
                
                return (Processo)this.RemoveStart();
            }
            return null;
        }

    }
}
