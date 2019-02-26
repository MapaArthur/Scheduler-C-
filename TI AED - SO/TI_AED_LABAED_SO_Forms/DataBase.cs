using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TI_AED_LABAED_SO_Forms
{
    static class DataBase
    {
        public static void CarregarDados(string nomeArquivo)
        {
            StreamReader arq = new StreamReader(nomeArquivo);
            if (File.Exists(nomeArquivo))
            {
                while (!arq.EndOfStream)
                {
                    string[] campos = arq.ReadLine().Split(';');
                    Processo processo = new Processo(Convert.ToInt16(campos[0]), campos[1], Convert.ToInt16(campos[2]), Convert.ToSingle(campos[3]), Convert.ToInt16(campos[4]));
                    Scheduler.CadastrarProcesso(processo);
                }
                //Scheduler.OrdenaProcesso();
                arq.Close();
            }
        }


    }
}
