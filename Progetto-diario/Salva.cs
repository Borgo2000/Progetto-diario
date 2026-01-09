using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Progetto_diario
{
    internal class Salva
    {
        public static void SalvaDiari(ListaDiari diari)
        {
            File.CreateDirectory("./Diari");
            File.WriteAllText("./Diari/InfoDiari.txt", Traduci.diariToFile(diari));
        }

        public static ListaDiari LeggiDiari()
        {
            // Implementazione della lettura dei diari
            return null;
        }

        public static void SalvaDiario(Diario diario)
        {
            // Implementazione del salvataggio di un singolo diario
            File.CreateDirectory(diario.getPercorso());
            File.WriteAllText(diario.getPercorso(), Traduci.diariToFile(diari));
        }

        public static Diario LeggiDiario()
        {
            // Implementazione della lettura di un singolo diario
            return null;
        }


        public static void SalvaPagina(Pagina pagina)
        {
            // Implementazione del salvataggio delle pagine di un diario
        }

        public static Pagina LeggiPagina()
        {
            // Implementazione della lettura delle pagine di un diario
            return null;
        }
    }
}
