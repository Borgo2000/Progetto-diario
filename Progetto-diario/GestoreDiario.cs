using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Progetto_diario
{
    internal class GestoreDiario
    {
        private InfoDiario infoDiario;
        private Diario diario;

        private int numeroPagine = 0;

        public GestoreDiario(InfoDiario infoDiario)
        {
            this.infoDiario = infoDiario;

            leggiDiario();
        }

        private void setupNumeroPagine()
        {
            if (diario.isValidato())
                foreach (InfoPagina ip in diario.getPagine())
                {
                    if (ip.getNumeroPagina() > numeroPagine)
                        numeroPagine = ip.getNumeroPagina();
                }
        }

        public void setNome(string nome)
        {
            diario.setNome(nome);
        }

        public void aggiungiPagina(DateTime dataCreazione)
        {
            numeroPagine++;
            diario.getPagine().Add(new InfoPagina(infoDiario.getPercorso() + "Pagina_" + numeroPagine + "/", numeroPagine, dataCreazione));
        }

        public void rimuoviPagina(int numeroPagina)
        {
            InfoPagina pagina = diario.getPagine().FirstOrDefault(p => p.getNumeroPagina() == numeroPagina);

            if (pagina == null)
                throw new Exception("Errore: Impossibile rimuovere l'oggetto.");

            Salva.EliminaPagina(pagina);

            diario.getPagine().RemoveAll(p => p.getNumeroPagina() == numeroPagina);

            setupNumeroPagine();
        }

        public void setPassword(string password, string nuovaPassword)
        {
            diario.setPassword(password, nuovaPassword);
        }

        public void validaDiario(string password)
        {
            diario.validaDiario(password);
            setupNumeroPagine();
        }

        public bool isValidato()
        {
            return diario.isValidato();
        }

        public ReadOnlyCollection<InfoPagina> getPagine()
        {
            return diario.getPagine().AsReadOnly();
        }

        public void salvaDiario()
        {
            Salva.SalvaDiario(diario);
        }

        public void leggiDiario()
        {
            diario = Salva.LeggiDiario(infoDiario);

            setupNumeroPagine();
        }
    }
}
