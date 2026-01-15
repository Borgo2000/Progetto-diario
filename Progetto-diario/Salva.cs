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
        private static void verificaPercorso(string percorso, string defaultFile) {
            string dir = Path.GetDirectoryName(percorso);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                //throw new Exception("Percorso Invalido.");
            }

            if (!File.Exists(percorso))
            {
                File.WriteAllText(percorso, defaultFile);
                //throw new Exception("File Inesistente.");
            }
        }
        public static void SalvaDiari(ListaDiari diari, string percorso)
        {
            percorso += "InfoDiari.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(percorso));
            File.WriteAllText(percorso, Traduci.diariToFile(diari));
        }

        public static ListaDiari LeggiDiari(string percorso)
        {
            percorso += "InfoDiari.txt";
            verificaPercorso(percorso, "");

            string file = File.ReadAllText(percorso);
            return Traduci.fileToDiari(file);
        }

        public static void SalvaDiario(Diario diario)
        {
            Directory.CreateDirectory(diario.getPercorso());
            File.WriteAllText(diario.getPercorso() + "InfoDiario.txt", Traduci.diarioToFile(diario));
        }

        public static Diario LeggiDiario(InfoDiario infoDiario)
        {
            string percorso = infoDiario.getPercorso() + "InfoDiario.txt";
            verificaPercorso(percorso, "");

            string file = File.ReadAllText(percorso);
            return Traduci.fileToDiario(file, infoDiario);
        }

        public static void SalvaPagina(Pagina pagina)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(pagina.getPercorso()));
            File.WriteAllText(pagina.getPercorso() + "InfoPagina.txt", Traduci.paginaToFile(pagina));
        }

        public static Pagina LeggiPagina(InfoPagina infoPagina)
        {
            string percorso = infoPagina.getPercorso() + "InfoPagina.txt";
            verificaPercorso(percorso, "0");

            string file = File.ReadAllText(percorso);
            return Traduci.fileToPagina(file, infoPagina);
        }
    }
}
