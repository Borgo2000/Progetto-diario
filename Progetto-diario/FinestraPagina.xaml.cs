using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Progetto_diario
{
    public partial class FinestraPagina : Window
    {
        private MediaPlayer player = new MediaPlayer();
        private GestorePagina pagina = null;

        internal FinestraPagina(GestorePagina pagina)
        {
            InitializeComponent();

            

            


            // Placeholder iniziale
            textBox_contenuto.Document.Blocks.Clear();
            textBox_contenuto.Document.Blocks.Add(new Paragraph(new Run("Scrivi...")));
            textBox_contenuto.Foreground = Brushes.Gray;

            textBox_contenuto.GotFocus += TextBox_GotFocus;
            textBox_contenuto.LostFocus += TextBox_LostFocus;


            this.pagina = pagina;
            // Carica contenuto esistente
            string contenuto = pagina.getContenuto();
            if (!string.IsNullOrEmpty(contenuto))
            {
                textBox_contenuto.Document.Blocks.Clear();
                textBox_contenuto.Document.Blocks.Add(new Paragraph(new Run(contenuto)));
                textBox_contenuto.Foreground = Brushes.White;
            }
            dataPicker.SelectedDate = pagina.getDataPagina();


        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_contenuto.Foreground == Brushes.Gray)
            {
                textBox_contenuto.Document.Blocks.Clear();
                textBox_contenuto.Foreground = Brushes.White;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string text = new TextRange(
                textBox_contenuto.Document.ContentStart,
                textBox_contenuto.Document.ContentEnd).Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                textBox_contenuto.Document.Blocks.Clear();
                textBox_contenuto.Document.Blocks.Add(new Paragraph(new Run("Scrivi...")));
                textBox_contenuto.Foreground = Brushes.Gray;
            }
        }

        private void button_emoji_Click(object sender, RoutedEventArgs e)
        {
            emojiPanel.Visibility =
                emojiPanel.Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        private void Emoji_Click(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;

            if (img != null)
            {
                // Limite massimo: 2 emoji
                if (emojiInsertedPanel.Children.Count >= 2)
                {
                    MessageBox.Show("Puoi inserire massimo due emoji.");
                    return;
                }

                // Crea l'immagine da aggiungere nel pannello fisso
                Image newImg = new Image();
                newImg.Source = img.Source;
                newImg.Width = 32;
                newImg.Height = 32;
                newImg.Margin = new Thickness(0, 0, 8, 0);

                emojiInsertedPanel.Children.Add(newImg);

                emojiPanel.Visibility = Visibility.Collapsed;
            }
        }

        //private void combobox_musica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (combobox_musica.SelectedItem is ComboBoxItem item)
        //    {
        //        string selected = item.Content.ToString();

        //        // Se seleziona "Nessuna musica"
        //        if (selected == "Nessuna musica")
        //        {
        //            player.Stop();
        //            return;
        //        }

        //        // Percorso del file audio
        //        string relativePath = item.Tag.ToString();
        //        string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        //        //MessageBox.Show("Percorso cercato:\n" + fullPath);


        //        try
        //        {
        //            player.Open(new Uri(fullPath, UriKind.Absolute));
        //            player.Play();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Errore nel caricamento della musica: " + ex.Message);
        //        }
        //    }
        //}

        private void button_salva_Click(object sender, RoutedEventArgs e)
        {
            pagina.setContenuto(new TextRange(
                textBox_contenuto.Document.ContentStart,
                textBox_contenuto.Document.ContentEnd).Text);

            pagina.salvaPagina();
            MessageBox.Show("Pagina salvata con successo!");

        }
    }
}
