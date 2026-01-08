using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class InfoDiario
    {
        private string percorso;
        private int numeroDiario
        private string dataCreazione;

        protected string nome;

        public InfoDiario(string percorso, int numeroDiaio, string nome, string dataCreazione){
            this.percorso = percorso;
            this.nome = nome;
            this.dataCreazione = dataCreazione;
        }

        public InfoDiario(InfoDiario diario) : this(diario.percorso, diario.numeroDiario, diario.nome, diario.dataCreazione){}
      
        public string getPercorso(){
            return percorso;
        }

        public int getNumeroDiario(){
            return numeroDiario;
        }

        public string getDataCreazione(){
            return dataCreazione;
        }

        public string getNome(){
            return nome;
        }


        public string toString(){
            return nome + " " + dataCreazione;
        }

    }
}