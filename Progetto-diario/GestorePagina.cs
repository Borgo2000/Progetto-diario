using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class GestorePagina
    {
        private InfoPagina infoPagina;
        private Pagina pagina;

        public GestorePagina(InfoPagina infoPagina)
        {
            this.infoPagina = infoPagina;

            leggiPagina();
        }

        public void aggiungiAllegati(string allegato)
        {
            foreach (string all in pagina.getAllegati())
                if (all == allegato)
                    throw new Exception("Errore: Allegato gia' esistente.");

            pagina.getAllegati().Add(allegato);
        }

        public void rimuoviAllegati(string allegato)
        {
            if(!pagina.getAllegati().Remove(allegato))
                throw new Exception("Errore: Allegato inesistente.");
        }

        public void salvaPagina()
        {
            Salva.SalvaPagina(pagina);
        }

        public void leggiPagina()
        {
            pagina = Salva.LeggiPagina(infoPagina);
        }
    }
}
