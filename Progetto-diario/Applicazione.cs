using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Applicazione
    {
        private ListaDiari diari;
        public Applicazione()
        {
            this.diari = null;
        }
        public List<InfoDiario> getListaDiari()
        {
            return diari.getDiari();
        }

        public void setDiario(InfoDiario diario)
        {
            
            diari.modificaDiario(diario);
        }
        public void aggiungiDiario()
        {
            diari.aggiungiDiario(new InfoDiario("", "", ""));
        }
       


    }
}
