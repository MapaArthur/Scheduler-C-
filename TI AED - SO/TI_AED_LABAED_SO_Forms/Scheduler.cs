using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_AED_LABAED_SO_Forms
{

    internal static class Scheduler
    {
        private const int quantum = 1;
        private static ListaExecucao listaExecucao = new ListaExecucao();
        private static ListaPrioridade listaPrioridade1 = new ListaPrioridade();
        private static ListaPrioridade listaPrioridade2 = new ListaPrioridade();
        private static ListaPrioridade listaPrioridade3 = new ListaPrioridade();
        private static ListaPrioridade listaPrioridade4 = new ListaPrioridade();
        private static ListaPrioridade listaPrioridade5 = new ListaPrioridade();

        internal static ListaExecucao ListaExecucao { get => listaExecucao;}
        internal static ListaPrioridade ListaPrioridade1 { get => listaPrioridade1; }
        internal static ListaPrioridade ListaPrioridade2 { get => listaPrioridade2; }
        internal static ListaPrioridade ListaPrioridade3 { get => listaPrioridade3; }
        internal static ListaPrioridade ListaPrioridade4 { get => listaPrioridade4; }
        internal static ListaPrioridade ListaPrioridade5 { get => listaPrioridade5; }

        public static void PromoveProcesso()
        {
            if (!ListaPrioridade2.Empty())
            {
                ListaPrioridade1.AddEnd(ListaPrioridade2.RemoveStart());
            }
            if (!ListaPrioridade3.Empty())
            {
                ListaPrioridade2.AddEnd(ListaPrioridade3.RemoveStart());
            }
            if (!ListaPrioridade4.Empty())
            {
                ListaPrioridade3.AddEnd(ListaPrioridade4.RemoveStart());
            }
            if (!ListaPrioridade5.Empty())
            {
                ListaPrioridade4.AddEnd(ListaPrioridade5.RemoveStart());
            }
        }

        public static void RebaixaProcesso(Processo processo)
        {
            if (processo != null)
            {
                switch (processo.Prioridade)
                {
                    case 1:
                        Scheduler.ListaPrioridade1.AddEnd(processo);
                        break;
                    case 2:
                        Scheduler.ListaPrioridade2.AddEnd(processo);
                        break;
                    case 3:
                        Scheduler.ListaPrioridade3.AddEnd(processo);
                        break;
                    case 4:
                        Scheduler.ListaPrioridade4.AddEnd(processo);
                        break;
                    case 5:
                        Scheduler.ListaPrioridade5.AddEnd(processo);
                        break;
                }
            }
        }

        public static void ExecutaListadeExecucao()
        {
            for (int i = 0; i < 3; i++)
            {
                if (!ListaPrioridade1.Empty())
                {
                    //listaExecucao.Copy(ListaPrioridade1);
                    listaExecucao.AddEnd(ListaPrioridade1.RemoveStart());
                    RebaixaProcesso(listaExecucao.ExecutarProcesso(quantum));
                    //System.Threading.Thread.Sleep(1000);
                    //PromoveProcesso();
                }
                else if (!ListaPrioridade2.Empty())
                {
                    //listaExecucao.Copy(ListaPrioridade2);
                    listaExecucao.AddEnd(ListaPrioridade2.RemoveStart());
                    RebaixaProcesso(listaExecucao.ExecutarProcesso(quantum));
                    //System.Threading.Thread.Sleep(1000);
                   //PromoveProcesso();
                }
                else if (!ListaPrioridade3.Empty())
                {
                    //listaExecucao.Copy(ListaPrioridade3);
                    listaExecucao.AddEnd(ListaPrioridade3.RemoveStart());
                    RebaixaProcesso(listaExecucao.ExecutarProcesso(quantum));
                    //System.Threading.Thread.Sleep(1000);
                    //PromoveProcesso();
                }
                else if (!ListaPrioridade4.Empty())
                {
                    //listaExecucao.Copy(ListaPrioridade4);
                    listaExecucao.AddEnd(ListaPrioridade4.RemoveStart());
                    RebaixaProcesso(listaExecucao.ExecutarProcesso(quantum));
                    //System.Threading.Thread.Sleep(1000);
                   // PromoveProcesso();
                }
                else if (!ListaPrioridade5.Empty())
                {
                    //listaExecucao.Copy(ListaPrioridade5);
                    listaExecucao.AddEnd(ListaPrioridade5.RemoveStart());
                    RebaixaProcesso(listaExecucao.ExecutarProcesso(quantum));
                    //System.Threading.Thread.Sleep(1000);
                    //PromoveProcesso();
                }
                else if (!ListaExecucao.Empty())
                {
                    RebaixaProcesso(listaExecucao.ExecutarProcesso(quantum));
                }

                else
                {
                    throw new ArgumentException("Não há processos para executar");
                }

            }
            PromoveProcesso();

        }

        public static void CadastrarProcesso(Processo processo)
        {
            switch (processo.Prioridade)
            {
                case 1:
                    Scheduler.ListaPrioridade1.AddSorted(processo);
                    break;
                case 2:
                    Scheduler.ListaPrioridade2.AddSorted(processo);
                    break;
                case 3:
                    Scheduler.ListaPrioridade3.AddSorted(processo);
                    break;
                case 4:
                    Scheduler.ListaPrioridade4.AddSorted(processo);
                    break;
                case 5:
                    Scheduler.ListaPrioridade5.AddSorted(processo);
                    break;
            }
        }

    }
}
