using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class GestorePagina
    {
        Pagina pagina;
        public GestorePagina(){
            leggiPagina();
        }
        public Pagina GetPagina()
        {
            return pagina;
        }
        public void salvaPagina()
        {
            

        }
        public void leggiPagina()
        {
            pagina = Salva.LeggiPagina();
        }
    }
}
