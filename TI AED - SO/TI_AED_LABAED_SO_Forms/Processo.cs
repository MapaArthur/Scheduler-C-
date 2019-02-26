using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListLibrary;

namespace TI_AED_LABAED_SO_Forms
{
    class Processo : Data
    {
        private int nId;
        private string nDesc;
        private int nPrioridade;
        private float nTempo;
        private int nCiclos;

        public int Id { get => nId; set => nId = value; }
        public string Desc { get => nDesc; set => nDesc = value; }
        public int Prioridade { get => nPrioridade; set => nPrioridade = value; }
        public float Tempo { get => nTempo; set => nTempo = value; }
        public int Ciclos { get => nCiclos; set => nCiclos = value; }

        public Processo(int id, string desc, int prio, float tempo, int ciclos)
        {
            this.Id = id;
            this.Desc = desc;
            this.Prioridade = prio;
            this.Tempo = tempo;
            this.Ciclos = ciclos;
        }

        /// <summary>
        /// Compara esta instância com um processo especificado e indica se essa instância precede, segue ou aparece na mesma posição na ordem de classificação  do processo especificado.
        /// </summary>
        /// <param name="other">O processo a ser comparado com o a atual instância</param>
        /// <returns>Menor que zero, esta instância precede 'other'; zero, esta instância ocorre na mesma posição que 'other'; maior que zero, esta instância segue 'other' na ordem de classificão.</returns>
        public override int CompareTo(Data other)
        {
            if((this.nTempo*this.nCiclos) < ((Processo)other).Tempo * ((Processo)other).Ciclos)
            {
                return -1;
            }
            if(this.nTempo * this.nCiclos > ((Processo)other).Tempo * ((Processo)other).Ciclos)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Determina se o peocesso epecificado é igual ao processo da atual instância
        /// </summary>
        /// <param name="other">O processo a ser comparado com o a atual instância</param>
        /// <returns>True se o processo especificado for igual ao processo atual; caso contrário, False</returns>
        public override bool Equals(Data other)
        {
            if (this.Id == ((Processo)other).Id)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};", this.Id.ToString(),this.Desc.ToString(), this.Prioridade.ToString(),this.Tempo.ToString(),this.Ciclos.ToString());

        }
    }
}
