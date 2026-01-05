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
        private string nome;
        private string dataCreazione;

        public InfoDiario(string percorso, string nome, string dataCreazione){
            this.percorso = percorso;
            this.nome = nome;
            this.dataCreazione = dataCreazione;
        }

        public InfoDiario(InfoDiario diario) : this(diario.percorso, diario.nome, diario.dataCreazione){}
      
        public string getPercorso(){
            return percorso;
        }

        public string getNome(){
            return nome;
        }

        public string getDataCreazione(){
            return dataCreazione;
        }

        public void setNome(string nome){
            this.nome = nome;
        }

        public string toString(){
            return nome + " " + dataCreazione;
        }

    }
}
