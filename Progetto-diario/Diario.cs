using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Diario: InfoDiario
    {
       

        private string password;
        private bool diarioVaidato;

        private List<InfoPagina> pagine;

        public Diario(InfoDiario diario,string nome, string dataCreazione,string password, List<InfoPagina> pagine): base(diario)
        {
            this.nome = nome;
            this.dataCreazione = dataCreazione;
            this.pagine = pagine;
            this.password = password;
            if(password=="")
            {
                diarioVaidato = true;
            }
            else
            {
                diarioVaidato = false;
            }
           
        }



        public string getNome()
        {
            return this.nome;
        }
        public string getDataCreazione()
        {
            return this.dataCreazione;
        }
        public List<InfoPagina> getPagine()
        {
        if(!diarioVaidato)
        {
             return null;
        }
             return this.pagine;


        }

        
           
            


        public void aggiungiPagina(InfoPagina pagina)
        {
            if (!diarioVaidato) { return; }

            pagine.Add(pagina);
        }
        public void rimuoviPagina(InfoPagina pagina)
        {
            if (!diarioVaidato) { return; }
            pagine.Remove(pagina);
        }
      




        public void setPassword(string Password, string nuovaPassword)
        {
            if (!diarioVaidato) { return; }
            if (this.password == Password)
            {
                this.password = nuovaPassword;
            }
        }


        public bool validaDiario(string password)
        {
            
            diarioVaidato= this.password == password;
            return diarioVaidato;

        }
        public bool isValidato()
        {
            return diarioVaidato;
        }


    }
}
