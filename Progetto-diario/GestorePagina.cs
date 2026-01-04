using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class GestorePagina
    {
        InfoPagina infoPagina;
        Pagina pagina;
        public GestorePagina()
        {
            infoPagina = null;
            pagina = null;
        }
        public Pagina GetPagina()
        {
            return pagina;
        }
        public void salvaPagina(Pagina pagina)
        {
            Salva salva = new Salva();
            salva.SalvaPagina(pagina);

        }
        public void leggiPagina()
        {
           Salva salvaPagina = new Salva();
          pagina = salvaPagina.LeggiPagina();
        }
    }
}
