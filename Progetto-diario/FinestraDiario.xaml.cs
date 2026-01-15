using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Progetto_diario
{
    /// <summary>
    /// Logica di interazione per FinestraDiario.xaml
    /// </summary>
    public partial class FinestraDiario : Window
    {
        private GestoreDiario diario = null;
        internal FinestraDiario(GestoreDiario diario)
        {
            InitializeComponent();
            this.diario = diario;
        }

        private void clickApri(object sender, RoutedEventArgs e)
        {
            FinestraPagina finestraPagina = new FinestraPagina();
            finestraPagina.ShowDialog();
        }
        //private GestoreDiario gestoreDiario = new GestoreDiario();
        //public void apriPagina(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    string nomePagina = btn.Content.ToString();
        //    gestoreDiario.GetDiario().apriPagina(nomePagina);
        //}
    }
}
