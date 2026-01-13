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

        public List<InfoDiario> getDiari()
        {
            return diari;
        }
    }
}
