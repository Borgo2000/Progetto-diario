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

       
        public void salvaListaDiari(ListaDiari diari)
        {
            Salva salva = new Salva();
            salva.salvaDiari(diari);
            //salva la lista diari su file
        }
        public void leggiListaDiari()
        {
            //legge la lista diari da file
        }



    }
}
