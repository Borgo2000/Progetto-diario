using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class InfoPagina
    {
        private string percorso;
        private int numeroPagina;
        protected DateTime dataPagina;

        public InfoPagina(string percorso, int numeroPagina, DateTime dataPagina)
        {
            this.percorso = percorso;
            this.numeroPagina = numeroPagina;
            this.dataPagina = dataPagina;
        }

        public InfoPagina(InfoPagina pagina) : this(pagina.percorso, pagina.numeroPagina, pagina.dataPagina) { }


        public string getPercorso()
        {
            return percorso;
        }

        public int getNumeroPagina()
        {
            return numeroPagina;
        }

        public DateTime getDataPagina()
        {
            return dataPagina;
        }

        public string toString()
        {
            return "P." + numeroPagina + " " + dataPagina;
        }

    }
}
