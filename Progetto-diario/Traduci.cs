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
            string file = "";

            List<InfoDiario> infoDiari = diari.getDiari();

            foreach (InfoDiario i in infoDiari)
            {
                file += $"{i.getPercorso()};{i.getNumeroDiario()};{i.getNome()};{i.isPasswordAttiva()};{i.getDataCreazione()};\n";
            }

            return file;
        }
        public static ListaDiari fileToDiari(string file)
        {
            string[] lines = file.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);

            List<InfoDiario> infoDiari = new List<InfoDiario>();

            foreach (string line in lines)
            {
                string[] param = line.Split(';');

                string percorso = param[0];
                int numeroDiario = int.Parse(param[1]);
                string nome = param[2];
                bool passwordAttiva = bool.Parse(param[3]);
                DateTime dataDiario = DateTime.Parse(param[4]);

                InfoDiario diario = new InfoDiario(percorso, numeroDiario, nome, passwordAttiva, dataDiario);

                infoDiari.Add(diario);
            }

            return new ListaDiari(infoDiari);
        }
        public static string diarioToFile(Diario diario){
            string file = "";

            file += $"{diario.getPassword()}\n";

            List<InfoPagina> infoPagine = diario.getPagine();

            foreach (InfoPagina i in infoPagine)
            {
                file += $"{i.getPercorso()};{i.getNumeroPagina()};{i.getDataPagina()};\n";
            }

            return file;
        }
        public static Diario fileToDiario(string file, InfoDiario infoDiario)
        {
            string[] lines = file.Split('\n');

            string password = lines[0];

            List<InfoPagina> infoPagine = new List<InfoPagina>();

            string line;
            for (int i = 1; i < lines.Length; i++)
            {
                line = lines[i];

                string[] param = line.Split(';');

                string percorso = param[0];
                int numeroPagina = int.Parse(param[1]);
                DateTime dataPagina = DateTime.Parse(param[2]);

                InfoPagina pagina = new InfoPagina(percorso, numeroPagina, dataPagina);

                infoPagine.Add(pagina);
            }

            return new Diario(infoDiario, password, infoPagine);
        }
        public static string paginaToFile(Pagina pagina)
        {
            string file = "";

            List<string> allegati = pagina.getAllegati();

            file += allegati.Count + "\n";

            foreach (string all in allegati)
            {
                file += all + "\n";
            }

            file += pagina.getContenuto();

            return file;
        }
        public static Pagina fileToPagina(string file, InfoPagina infoPagina)
        {
            string[] lines = file.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            int len = int.Parse(lines[0]);

            List<string> allegati = new List<string>();
            string contenuto = "";

            for(int i = 1; i < lines.Length; i++)
            {
                if(i < len)
                {
                    allegati.Add(lines[i]);
                }
                else
                {
                    contenuto += lines[i];
                }
            }

            return new Pagina(infoPagina, contenuto, allegati);
        }

    }
}
