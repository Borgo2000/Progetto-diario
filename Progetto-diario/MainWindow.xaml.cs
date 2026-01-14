using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;
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
        //private Applicazione app = null;
        
        public MainWindow()
        {

            InitializeComponent();


            //DiaryGrid.Children.Add(CreateDiaryCard("../../diario1.png", "Bloccato"));
            //DiaryGrid.Children.Add(CreateDiaryCard("../../diario2.png", "Sbloccato"));
            //DiaryGrid.Children.Add(CreateDiaryCard("../../diario3.png", "Bloccato"));
            //DiaryGrid.Children.Add(CreateDiaryCard("../../diario7.png", "Sbloccato"));
            //app = new Applicazione();
            //ReadOnlyCollection<InfoDiario> diari =app.getDiari();
            //foreach (InfoDiario diario in diari)
            //{
            //    string imagePath = diario.getPercorso()+"diario1.png";
            //    string labelText = diario.getNome();
            //    DiaryGrid.Children.Add(CreateDiaryCard(imagePath, labelText));

            //}

            app.aggiungiDiario("Prova 2", DateTime.Now);

            ReadOnlyCollection<InfoDiario> lista = app.getDiari();

            app.salvaListaDiari();

            // -------
            GestoreDiario gestDi = new GestoreDiario(lista.ElementAt(0));

            gestDi.aggiungiPagina(DateTime.Now);

            ReadOnlyCollection<InfoPagina> lista2 = gestDi.getPagine();

            gestDi.salvaDiario();

            // -------
            GestorePagina gestPa = new GestorePagina(lista2.ElementAt(0));

            gestPa.setContenuto("Ciao mondo!!!!!\nCaisdfafdoifd\nfff");

            gestPa.salvaPagina();
        }

        private void click_apri(object sender, RoutedEventArgs e)
        {
            FinestraDiario finestraDiario = new FinestraDiario();
            finestraDiario.ShowDialog();
        }
        //private Grid CreateDiaryCard(string imagePath, string labelText)
        //{
        //    // Grid container
        //    Grid grid = new Grid
        //    {
        //        Width = 148,
        //        Height = 170
        //    };

        //    // Rectangle con immagine
        //    Rectangle rect = new Rectangle
        //    {
        //        Width = 148,
        //        Height = 134,
        //        Style = (Style)FindResource("DiaryCardStyle")
        //    };

        //    rect.SetValue(Panel.ZIndexProperty, 1);
        //    rect.Fill = new ImageBrush
        //    {
        //        ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative)),
        //        Stretch = Stretch.Uniform
        //    };

        //    // Label
        //    Label label = new Label
        //    {
        //        Content = labelText,
        //        FontWeight = FontWeights.Bold,
        //        FontSize = 14,
        //        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B0B3C4")),
        //        Background = Brushes.Transparent,
        //        HorizontalAlignment = HorizontalAlignment.Center,
        //        VerticalAlignment = VerticalAlignment.Bottom,
        //        Margin = new Thickness(0, 0, 0, 12)
        //    };

        //    label.SetValue(Panel.ZIndexProperty, 999);

        //    // Stile con trigger
        //    Style style = new Style(typeof(Label));
        //    style.Setters.Add(new Setter(Label.VisibilityProperty, Visibility.Collapsed));

        //    DataTrigger trigger = new DataTrigger
        //    {
        //        Binding = new Binding("IsMouseOver")
        //        {
        //            RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Grid), 1)
        //        },
        //        Value = true
        //    };
        //    trigger.Setters.Add(new Setter(Label.VisibilityProperty, Visibility.Visible));

        //    style.Triggers.Add(trigger);
        //    label.Style = style;

        //    // Aggiunta elementi alla grid
        //    grid.Children.Add(rect);
        //    grid.Children.Add(label);

        //    return grid;
        //}
        //private void img_button_aggiungi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    //app.aggiungiDiario("NuovoDiario", DateTime.Now);
        //    //string nomeDiario = Interaction.InputBox(
        //    //    "Inserisci il nome del nuovo diario:",
        //    //    "Nuovo Diario",
        //    //    ""
        //    //);

        //    //if (!string.IsNullOrWhiteSpace(nomeDiario))
        //    //{
        //    //    MessageBox.Show($"Hai creato il diario: {nomeDiario}");
        //    //    // qui puoi aggiungere il diario alla tua UniformGrid
        //    //}

        //}
       




        //public void apriDiario(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    string nomeDiario = btn.Content.ToString();
        //    app.apriDiario(nomeDiario);
        //}
        //private void AggiornaLabelStato()
        //{
        //    if (diarioSelezionato == null) return;
        //    if (diarioSelezionato.ProtettoDaPassword)
        //    {
        //        label_stato.Content = "🔒 Protetto da password";
        //        label_stato.Foreground = Brushes.DarkGoldenrod;
        //        label_stato.Background = Brushes.LightYellow;
        //    }
        //    else
        //    {
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
        //    }
    }
}
