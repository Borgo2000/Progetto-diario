using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_diario
{
    internal class Traduci
    {
        public static string diariToFile(ListaDiari diari)
        {
            List<InfoDiario> infoDiari = diari.getDiari();
            string file = "";

            foreach (InfoDiario i in infoDiari)
            {
                file += $"{i.getPercorso()};{i.getNumeroDiario()};{i.getDataCreazione()};{i.getNome()};\n";
            }

            return file;
        }
        public static ListaDiari fileToDiari(string file)
        {
            string[] lines = file.Split('\n');

            List<InfoDiario> infoDiari = new List<InfoDiario>();

            foreach (string line in lines) {
                string[] param = line.Split(';');

                string percorso = param[0];
                int numeroDiario = int.Parse(param[1]);
                string nome = param[2];
                DateTime dataDiario = DateTime.Parse(param[3]);

                InfoDiario diario = new InfoDiario(percorso, numeroDiario, nome, dataDiario);

                infoDiari.Add(diario);
            }

            return new ListaDiari(infoDiari);
        }
        public static string diarioToFile(Diario diario){

            return "";
        }
        public static Diario fileToDiario(string file, InfoDiario infoDiario)
        {
            return new Diario(infoDiario, "", null);
        }
        public static string paginaToFile(Pagina pagina)
        {
            return "";
        }
        public static Pagina fileToPagina(string file)
        {
            return null;
        }

    }
}
