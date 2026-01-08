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

        public Applicazione() {
            leggiListaDiari();
        }

        public ListaDiari getListaDiari() {
            return diari;
        }
       
        public void salvaListaDiari() {
            Salva.SalvaDiari(diari);
        }

        public void leggiListaDiari() {
            diari = Salva.LeggiDiari();
        }
    }
}
