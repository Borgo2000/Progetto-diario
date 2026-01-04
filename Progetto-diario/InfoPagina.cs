using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class InfoPagina
    {
        static private int maxId =  0;
    
        private string percorso;
        private int id;
        protected int numeroPagina;
        protected string dataPagina;

        public InfoPagina(InfoPagina pagina): this(pagina.percorso,  pagina.id, pagina.numeroPagina, pagina.dataPagina){}

        public InfoPagina(string percorso,int id, int numeroPagina, string dataPagina)
        {
            this.percorso = percorso;
            this.numeroPagina = numeroPagina;
            this.dataPagina = dataPagina;
            this.id = id;
            if (id>maxId)
            {
                maxId = id;
            }
            
        }
        public InfoPagina(string percorso, int numeroPagina, string dataPagina)
        {
            this.percorso = percorso;
            this.numeroPagina = numeroPagina;
            this.dataPagina = dataPagina;
            maxId++;
            this.id = maxId;
        }



        public string getPercorso()
        {
            return percorso;
        }
        public int getnumeroPagina()
        {
            return numeroPagina;
        }
        public string getDataPagina()
        {
            return dataPagina;
        }


        public void setDataPagina( string dataPagina)
        {
            this.dataPagina = dataPagina;
        }


        public string toString()
        {
            return "Pagina numero: " + numeroPagina + " Data: " + dataPagina;
        }
        
    }
}
