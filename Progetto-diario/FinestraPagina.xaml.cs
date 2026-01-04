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
    /// Logica di interazione per FinestraPagina.xaml
    /// </summary>
    public partial class FinestraPagina : Window
    {
        public FinestraPagina()
        {
            InitializeComponent();
        }

        private GestorePagina gestorePagina = new GestorePagina();

    }
}
