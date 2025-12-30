using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Diario
    {
        private string nome;
        private string dataCreazione;
       

        private string password;
        private bool diarioVaidato;

        private List<Pagina> pagine;

        public Diario(string nome, string dataCreazione,string password, List<Pagina> pagine)
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
            return nome;
        }
        public string getDataCreazione()
        {
            return dataCreazione;
        }

        public void aggiungiPagina(Pagina pagina)
        {
            pagine.Add(pagina);
        }
        public List<Pagina> getPagine()
        {
            if (diarioVaidato == true)
            {
                return pagine;
            }
            else
            {
                return null;
            }
        }
        public bool verificaPassword(string passwordInserita)
        {
            
            diarioVaidato= password == passwordInserita;
            return diarioVaidato;

        }

    }
}
