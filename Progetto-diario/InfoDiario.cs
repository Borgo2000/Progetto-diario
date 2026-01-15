using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class InfoDiario
    {
        private string percorso;
        private int numeroDiario;
        private bool passwordAttiva;
        private DateTime dataCreazione;

        protected string nome;

        public InfoDiario(string percorso, int numeroDiario, string nome, bool passwordAttiva, DateTime dataCreazione)
        {
            this.percorso = percorso;
            this.numeroDiario = numeroDiario;
            this.nome = nome;
            this.passwordAttiva = passwordAttiva;
            this.dataCreazione = dataCreazione;
        }

        public InfoDiario(InfoDiario diario) : this(diario.percorso, diario.numeroDiario, diario.nome, diario.passwordAttiva, diario.dataCreazione) { }

        public string getPercorso()
        {
            return percorso;
        }

        public int getNumeroDiario()
        {
            return numeroDiario;
        }

        public DateTime getDataCreazione()
        {
            return dataCreazione;
        }

        public string getNome()
        {
            return nome;
        }

        public bool isPasswordAttiva()
        {
            return passwordAttiva;
        }
    }
}