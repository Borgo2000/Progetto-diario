using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Diario: InfoDiario
    {
        private InfoDiario infoDiario;

        private string password;
        private bool diarioVaidato;

        private List<InfoPagina> pagine;

        public Diario(InfoDiario diario, string password, List<InfoPagina> pagine): base(diario) {
            this.infoDiario = diario;

            this.pagine = pagine;
            this.password = password;
            this.diarioVaidato = password == "";
        }

        public void setNome(string nome){
            this.nome = nome;
            this.infoDiario.nome = nome;
        }

        public void aggiungiPagina(InfoPagina pagina){
            if (!isValidato()) return;

            pagine.Add(pagina);
        }

        public void rimuoviPagina(InfoPagina pagina){
            if (!isValidato()) return;

            pagine.Remove(pagina);
        }

        public void setPassword(string password, string nuovaPassword){
            if (this.password == password)
                this.password = nuovaPassword;
        }


        public List<InfoPagina> getPagine(){
            if(!isValidato()) return null;

            return pagine.AsReadOnly();
        }


        public void validaDiario(string password) {
            if (this.password == password)
                diarioVaidato = true;
        }

        public bool isValidato(){
            return diarioVaidato;
        }


    }
}
