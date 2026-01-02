using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class InfoDiario
    {
        static private int maxId = 0;


        private string percorso;
        private int id;
        protected string nome;
        protected string dataCreazione;
       

        public InfoDiario(string percorso, int id, string nome, string dataCreazione)
        {
            this.percorso = percorso;
            this.nome = nome;
            this.dataCreazione = dataCreazione;
            this.id = id;
            if(id>maxId)
            {
                maxId = id;
            }
        }

        public InfoDiario(InfoDiario diario):this(diario.percorso, diario.id, diario.nome, diario.dataCreazione){}

        public InfoDiario(string percorso, string nome, string dataCreazione)
        {
            this.percorso = percorso;
            this.nome = nome;
            this.dataCreazione = dataCreazione;
            maxId++;
            this.id = maxId;
        }

        public string getPercorso()
        {
            return percorso;
        }
        public int getId()
        {
            return id;
        }
        public string toString()
        {
            return "Diario: " + nome + " Data creazione: " + dataCreazione;
        }

    }
}
