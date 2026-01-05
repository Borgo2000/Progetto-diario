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
            //salva la lista diari su file
            Salva.SalvaDiari(this.diari);
        }

        public void leggiListaDiari() {
            //legge la lista diari da file
            this.diari = Salva.LeggiDiari();
        }
    }
}
