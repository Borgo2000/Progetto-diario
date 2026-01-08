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

        public Pagina getPagina(){
            return pagina;
        }

        public void salvaPagina(){  
            Salva.SalvaPagina(pagina);
        }

        public void leggiPagina(){
            pagina = Salva.LeggiPagina();
        }
    }
}
