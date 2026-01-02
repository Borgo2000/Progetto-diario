using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Progetto_diario
{
    internal class GestoreDiario
    {
        private Diario diario;
        

        public GestoreDiario()
        {
            this.diario = null;
        }
        public string getNome()
        {
            return diario.getNome();

        }
        public string getData()
        {
            return diario.getDataCreazione();
        }
        public List<InfoPagina> getPagine()
        {
            return diario.getPagine();
        }
        public void aggiungiPagina()
        {
            diario.aggiungiPagina(new InfoPagina("",0,""));
        }
    }
}
