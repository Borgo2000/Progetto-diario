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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Progetto_diario
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Applicazione app = null;
        public MainWindow()
        {
            InitializeComponent();
            app=new Applicazione();

        }

        //public void apriDiario(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    string nomeDiario = btn.Content.ToString();
        //    app.apriDiario(nomeDiario);
        //}
        //private void AggiornaLabelStato() { 
        //    if (diarioSelezionato == null) return; 
        //    if (diarioSelezionato.ProtettoDaPassword) {
        //        label_stato.Content = "🔒 Protetto da password"; 
        //        label_stato.Foreground = Brushes.DarkGoldenrod; 
        //        label_stato.Background = Brushes.LightYellow; 
        //    } else { 
        //        label_stato.Content = "🟢 Accesso libero"; 
        //        label_stato.Foreground = Brushes.Green; 
        //        label_stato.Background = Brushes.LightGreen; 
        //    } 
        //}
        //private void button_apriDiario_Click(object sender, RoutedEventArgs e)
        //{
        //    if (diarioSelezionato == null) { MessageBox.Show("Seleziona un diario prima."); return; }
        //    if (diarioSelezionato.ProtettoDaPassword)
        //    { // Chiedi password string input = Microsoft.VisualBasic.Interaction.InputBox( "Inserisci la password del diario:", "Password richiesta", "");
        //      // if (input == diarioSelezionato.Password){
        //      // MessageBox.Show("Diario aperto!"); 
        //      // Apri diario...
        //      // } else { MessageBox.Show("Password errata.");
        //      // }
        //      // } else { MessageBox.Show("Diario aperto!"); 
        //      // Apri diario...
        //      // } }
            }
}
