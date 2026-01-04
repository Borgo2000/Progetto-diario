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
        public Diario GetDiario()
        {
            return diario;
        }

        public void salvaDiario(Diario diario)
        {
            Salva salva = new Salva();
            salva.SalvaDiario(diario);
        }
        public void leggiDiario()
        {
            Salva salva = new Salva();
            this.diario = salva.LeggiDiario();
        }
    }
}
