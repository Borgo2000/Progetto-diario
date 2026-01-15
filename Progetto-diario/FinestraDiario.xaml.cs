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
        private Border paginaSelezionata = null;
       
        internal FinestraDiario(GestoreDiario diario)
        {
            InitializeComponent();
            this.diario = diario;

            // Genera 10 pagine
            for (int i = 1; i <= 10; i++)
            {
                PagesGrid.Children.Add(CreatePageCard(i));
            }
        }







        private Border CreatePageCard(int numeroPagina)
        {
            Border card = new Border
            {
                Width = 160,
                Height = 220,
                Margin = new Thickness(10),
                Style = (Style)FindResource("DiaryCardStyle"),
                Cursor = Cursors.Hand
            };

            // CLICK → selezione
            card.MouseLeftButtonUp += (s, e) =>
            {
                // Se clicchi la stessa → deseleziona
                if (paginaSelezionata == card)
                {
                    RimuoviEvidenziazione(card);
                    paginaSelezionata = null;
                    return;
                }

                // Rimuovi evidenziazione precedente
                if (paginaSelezionata != null)
                    RimuoviEvidenziazione(paginaSelezionata);

                // Applica evidenziazione
                ApplicaEvidenziazione(card);
                paginaSelezionata = card;
            };

            StackPanel stack = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            Image img = new Image
            {
                Source = new BitmapImage(new Uri("/pagina.PNG", UriKind.Relative)),
                Stretch = Stretch.Uniform,
                Height = 160
            };

            Label lbl = new Label
            {
                Content = $"Pagina {numeroPagina}",
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            stack.Children.Add(img);
            stack.Children.Add(lbl);
            card.Child = stack;

            return card;
        }







        private void clickApri(object sender, RoutedEventArgs e)
        {
            if (paginaSelezionata == null)
            {
                MessageBox.Show("Seleziona una pagina prima di aprirla.");
                return;
            }

            // Recupero numero pagina dalla label
            Label lbl = ((paginaSelezionata.Child as StackPanel).Children[1]) as Label;
            string testo = lbl.Content.ToString(); // "Pagina X"
            int numeroPagina = int.Parse(testo.Replace("Pagina ", ""));

            // Salvo nel gestore
            diario.PaginaCorrente = numeroPagina;

            // Apro la finestra pagina
            FinestraPagina finestraPagina = new FinestraPagina();
            finestraPagina.ShowDialog();
        }















        private void AggiungiPagina_Click(object sender, MouseButtonEventArgs e)
        {
            
        
            int numero = PagesGrid.Children.Count + 1;

            // aggiungi al modello
            diario.aggiungiPagina();

            // aggiungi alla UI
            PagesGrid.Children.Add(CreatePageCard(numero));
        

        }









        private void button_elimina_Click(object sender, RoutedEventArgs e)
        {
            if (paginaSelezionata == null)
            {
                MessageBox.Show("Seleziona una pagina da eliminare.");
                return;
            }

            // Recupero numero pagina
            Label lbl = ((paginaSelezionata.Child as StackPanel).Children[1]) as Label;
            int numeroPagina = int.Parse(lbl.Content.ToString().Replace("Pagina ", ""));

            // Rimuovo dal gestore
            diario.rimuoviPagina(numeroPagina);

            // Rimuovo dalla UI
            PagesGrid.Children.Remove(paginaSelezionata);
            paginaSelezionata = null;

            MessageBox.Show("Pagina eliminata.");

        }







        private void ApplicaEvidenziazione(Border card)
        {
            card.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8A2BE2"));
            card.BorderThickness = new Thickness(3);
        }

        private void RimuoviEvidenziazione(Border card)
        {
            card.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5A3FFF"));
            card.BorderThickness = new Thickness(2);
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
