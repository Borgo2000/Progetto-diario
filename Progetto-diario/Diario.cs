using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Diario : InfoDiario
    {
        private string password;
        private bool diarioVaidato;

        private List<InfoPagina> pagine;

        public Diario(InfoDiario diario, string password, List<InfoPagina> pagine) : base(diario)
        {
            this.pagine = pagine;
            this.password = password;
            this.diarioVaidato = (password == "");
        }

        private void checkValidita()
        {
            if (!isValidato())
                throw new Exception("Errore: Diario non validato");
        }

        public void setNome(string nome)
        {
            checkValidita();
            this.nome = nome;
        }

        public void setPassword(string password, string nuovaPassword)
        {
            if (this.password == password)
                this.password = nuovaPassword;
        }


        public List<InfoPagina> getPagine()
        {
            checkValidita();
            return pagine;
        }

        public string getPassword()
        {
            checkValidita();
            return password;
        }

        public void validaDiario(string password)
        {
            if (this.password == password)
                diarioVaidato = true;
            else
                diarioVaidato = false;
        }

        public bool isValidato()
        {
            return diarioVaidato;
        }
    }
}
