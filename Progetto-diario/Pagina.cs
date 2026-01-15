using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Pagina : InfoPagina
    {
        private string contenuto;
        private List<string> allegati;

        public Pagina(InfoPagina pagina, string contenuto, List<string> allegati) : base(pagina)
        {
            this.contenuto = contenuto;
            this.allegati = allegati;
        }
        public void setDataPagina(DateTime data)
        {
            this.dataPagina = data;
        }

        public void setContenuto(string contenuto)
        {
            this.contenuto = contenuto;
        }

        public string getContenuto()
        {
            return contenuto;
        }

        public List<string> getAllegati()
        {
            return allegati;
        }
        
    }
}
