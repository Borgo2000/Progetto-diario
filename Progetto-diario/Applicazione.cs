using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Applicazione
    {
        private ListaDiari diari;
        private int numeroDiari = 0;

        public Applicazione()
        {
            leggiListaDiari();
        }

        public void aggiungiDiario(string nome, DateTime dataCreazione)
        {
            foreach (InfoDiario id in diari.getDiari())
                if (id.getNome() == nome)
                    throw new Exception("Errore: Nome gia' esistente.");

            numeroDiari++;
            diari.getDiari().Add(new InfoDiario("./Diari/" + nome + "/", numeroDiari, nome, dataCreazione));
        }
        public void rimuoviDiario(string nome)
        {
            if (diari.getDiari().RemoveAll(p => p.getNome() == nome) == 0)
                throw new Exception("Errore: Impossibile rimuovere l'oggetto.");
        }

        public ReadOnlyCollection<InfoDiario> getDiari()
        {
            return diari.getDiari().AsReadOnly();
        }

        public void salvaListaDiari()
        {
            Salva.SalvaDiari(diari, "./Diari/");
        }

        public void leggiListaDiari()
        {
            diari = Salva.LeggiDiari("./Diari/");

            foreach(InfoDiario id in diari.getDiari())
            {
                if(id.getNumeroDiario() > numeroDiari)
                    numeroDiari = id.getNumeroDiario();
            }
        }
    }
}
