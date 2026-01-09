using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class ListaDiari
    {
        private List<InfoDiario> diari;

        public ListaDiari(List<InfoDiario> diari)
        {
            this.diari = diari;
        }

        public void aggiungiDiario(InfoDiario diario)
        {
            diari.Add(diario);
        }
        public void rimuoviDiario(InfoDiario diario)
        {
            diari.Remove(diario);
        }

        public List<InfoDiario> getDiari()
        {
            return diari.AsReadOnly();
        }
    }
}
