using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Pagina
    {
        private int  numeroPagina;
        private string dataPagina;

        private string contenuto;
        public Pagina(int numeroPagina, string dataPagina, string contenuto)
        {
            this.numeroPagina = numeroPagina;
            this.dataPagina = dataPagina;
            this.contenuto = contenuto;
        }

        public int getNumeroPagina()
        {
            return numeroPagina;
        }
        public string getDataPagina()
        {
            return dataPagina;
        }
        public string getContenuto()
        {
            return contenuto;
        }


    }
}
