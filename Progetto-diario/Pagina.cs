using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Pagina: InfoPagina
    {
        

        private string contenuto;
        private  List<string> allegati;
        public Pagina(InfoPagina pagina, string contenuto, List<string> allegati) : base(pagina)
        {
           
            this.contenuto = contenuto;
            this.allegati = allegati;
        }
        

        public List<string> getAllegati()
        {
            return allegati;
        }
        public string getContenuto()
        {
            return contenuto;
        }
        public int getNumeroPagina()
        {
            return this.numeroPagina;
        }
        public string getDataPagina()
        {
            return this.dataPagina;
        }

        public void setContenuto(string nuovoContenuto)
        {
            this.contenuto = nuovoContenuto;
        }
        public void setData(string data)
        {
            this.dataPagina= data;
        }

        public void rimuoviAllegati(string allegato)
        {
            allegati.Remove(allegato);
        }
        public void aggiungiAllegati(string allegato)
        {
            allegati.Add(allegato);
        }

    }
}
