using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class GestoreDiario
    {
        private Diario diario;

        public GestoreDiario()
        {
            leggiDiario();
        }

        public Diario getDiario()
        {
            return diario;
        }

        public void salvaDiario()
        {
            Salva.SalvaDiario(this.diario);
        }

        public void leggiDiario()
        {
            this.diario = Salva.LeggiDiario();
        }
    }
}
