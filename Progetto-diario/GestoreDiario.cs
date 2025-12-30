using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class GestoreDiario
    {
        private List<Diario> diari;
        public GestoreDiario(List<Diario> diari)
        {
            this.diari = diari;
        }
        public void aggiungiDiari(Diario diario)
        {
            diari.Add(diario);
        }
        public List<Diario> getDiari()
        {
            return diari;
        }

    }
}
