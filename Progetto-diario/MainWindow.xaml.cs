using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Progetto_diario
{
    public partial class MainWindow : Window
    {
        private Applicazione app = null;
        private Grid diarioSelezionato = null;

        public MainWindow()
        {
            InitializeComponent();

            app = new Applicazione();
            ReadOnlyCollection<InfoDiario> diari = app.getDiari();

            foreach (InfoDiario diario in diari)
            {
                string imagePath = diario.getPercorso() + "../../diario1.png";
                string labelText = diario.isPasswordAttiva() ? diario.getNome() + " 🔒" : diario.getNome();

                DiaryGrid.Children.Add(CreateDiaryCard(diario));
            }
        }







        // 🔹 CREA UNA CARD DIARIO DINAMICAMENTE
        private Grid CreateDiaryCard(string imagePath, string labelText)
        {
            Grid grid = new Grid
            {
                Width = 148,
                Height = 170
            };

            Rectangle rect = new Rectangle
            {
                Width = 148,
                Height = 134,
                Style = (Style)FindResource("DiaryCardStyle")
            };

            rect.SetValue(Panel.ZIndexProperty, 1);
            rect.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute)),
                Stretch = Stretch.Uniform
            };

            Label label = new Label
            {
                Content = labelText,
                FontWeight = FontWeights.Bold,
                FontSize = 14,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B0B3C4")),
                Background = Brushes.Transparent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 0, 12)
            };

            label.SetValue(Panel.ZIndexProperty, 999);

            Style style = new Style(typeof(Label));
            style.Setters.Add(new Setter(Label.VisibilityProperty, Visibility.Collapsed));

            DataTrigger trigger = new DataTrigger
            {
                Binding = new System.Windows.Data.Binding("IsMouseOver")
                {
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Grid), 1)
                },
                Value = true
            };

            trigger.Setters.Add(new Setter(Label.VisibilityProperty, Visibility.Visible));
            style.Triggers.Add(trigger);

            label.Style = style;

            grid.Children.Add(rect);
            grid.Children.Add(label);

            return grid;
        }







        private void button_elimina_Click(object sender, RoutedEventArgs e)

        {
            if (diarioSelezionato == null)
            {
                MessageBox.Show("Seleziona un diario da eliminare.");
                return;
            }

            Label lblNome = null;

            foreach (var child in diarioSelezionato.Children)
                if (child is Label l && l.VerticalAlignment == VerticalAlignment.Top)
                    lblNome = l;

            string nome = lblNome.Content.ToString();

            try
            {
                app.rimuoviDiario(nome);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DiaryGrid.Children.Remove(diarioSelezionato);
            diarioSelezionato = null;

            MessageBox.Show("Diario eliminato.");
        }





        // 🔹 CLICK SUL PULSANTE +
        private void img_button_aggiungi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DiaryGrid.Children.Count >= 4)
            {
                MessageBox.Show("Puoi creare al massimo 4 diari.");
                return;
            }

            InputDialog dialog = new InputDialog();
            dialog.Owner = this;

            if (dialog.ShowDialog() == true)
            {
                string nome = dialog.NomeDiario;
                bool protetto = dialog.PasswordAttiva;
                string password = dialog.Password;

                if (string.IsNullOrWhiteSpace(nome))
                {
                    MessageBox.Show("Il nome non può essere vuoto.");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(nome, @"^[A-Za-zÀ-ÖØ-öø-ÿ]+$"))
                {
                    MessageBox.Show("Il nome può contenere solo lettere.");
                    return;
                }
                if (protetto==true)
                {
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        MessageBox.Show("La password non puo essere vuota.");
                        return;
                    }
                    
                }
                try
                {

                    app.aggiungiDiario(nome, protetto, DateTime.Now);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
                InfoDiario nuovo = app.getDiari().Last();
                app.salvaListaDiari();

                DiaryGrid.Children.Add(CreateDiaryCard(nuovo));

                GestoreDiario gestore = new GestoreDiario(nuovo);
                gestore.setPassword("", password);
                gestore.salvaDiario();

                MessageBox.Show($"Diario '{nome}' creato!");
            }
        }







        private void click_apri(object sender, RoutedEventArgs e)
        {
            if (diarioSelezionato == null)
            {
                MessageBox.Show("Seleziona un diario prima di aprirlo.");
                return;
            }

            Label lblNome = null;

            foreach (var child in diarioSelezionato.Children)
                if (child is Label l && l.VerticalAlignment == VerticalAlignment.Top)
                    lblNome = l;

            if (lblNome == null)
            {
                MessageBox.Show("Errore interno: impossibile trovare il nome del diario.");
                return;
            }

            string nomeDiario = lblNome.Content.ToString();

            InfoDiario diario = app.getDiari()
                                   .FirstOrDefault(d => d.getNome() == nomeDiario);

            if (diario == null)
            {
                MessageBox.Show("Errore: diario non trovato.");
                return;
            }
            GestoreDiario gestoreDiario = new GestoreDiario(diario);
            if (diario.isPasswordAttiva())
            {
                PasswordDialog pwd = new PasswordDialog(gestoreDiario);
                pwd.Owner = this;
                
                if (pwd.ShowDialog() != true || !pwd.AccessoConsentito)
                    return;
            }

            FinestraDiario finestra = new FinestraDiario(gestoreDiario);
            finestra.ShowDialog();
        }








        // 🔵 Variabile per tenere traccia della card selezionata


        // 🔵 CREA UNA CARD DIARIO COMPLETA
        private Grid CreateDiaryCard(InfoDiario diario)
        {
            // GRID PRINCIPALE
            Grid grid = new Grid
            {
                Width = 148,
                Height = 200,
                Margin = new Thickness(10),
                Cursor = Cursors.Hand
            };

            // 🔹 EVENTO CLICK PER SELEZIONE
            grid.MouseLeftButtonUp += (s, e) =>
            {
                // Se clicchi di nuovo sulla stessa → diseleziona
                if (diarioSelezionato == grid)
                {
                    RimuoviEvidenziazione(grid);
                    diarioSelezionato = null;
                    return;
                }

                // Rimuovi evidenziazione precedente
                if (diarioSelezionato != null)
                    RimuoviEvidenziazione(diarioSelezionato);

                // Evidenzia questa
                ApplicaEvidenziazione(grid);
                diarioSelezionato = grid;
            };

            // 🔹 LABEL SUPERIORE (NOME)
            Label lblNome = new Label
            {
                Content = diario.getNome(),
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 5, 0, 0)
            };

            // 🔹 IMMAGINE
            Rectangle rect = new Rectangle
            {
                Width = 148,
                Height = 134,
                VerticalAlignment = VerticalAlignment.Center,
                Style = (Style)FindResource("DiaryCardStyle")
            };

            rect.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/diario1.png")),
                Stretch = Stretch.Uniform
            };

            // 🔹 LABEL INFERIORE (STATO)
            Label lblStato = new Label
            {
                Content = diario.isPasswordAttiva() ? "Bloccato 🔒" : "Accesso libero",
                FontWeight = FontWeights.Bold,
                FontSize = 14,
                Foreground = Brushes.LightGray,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 0, 5)
            };

            // AGGIUNTA ELEMENTI
            grid.Children.Add(lblNome);
            grid.Children.Add(rect);
            grid.Children.Add(lblStato);

            return grid;
        }







        // 🔵 APPLICA EVIDENZIAZIONE (come hover)
        private void ApplicaEvidenziazione(Grid grid)
        {
            foreach (var child in grid.Children)
            {
                if (child is Rectangle rect)
                {
                    rect.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00CFFF"));
                    rect.StrokeThickness = 3;
                    rect.Effect = new System.Windows.Media.Effects.DropShadowEffect
                    {
                        BlurRadius = 26,
                        ShadowDepth = 0,
                        Opacity = 0.9,
                        Color = (Color)ColorConverter.ConvertFromString("#8000CFFF")
                    };
                }
            }
        }





        // 🔵 RIMUOVE EVIDENZIAZIONE
        private void RimuoviEvidenziazione(Grid grid)
        {
            foreach (var child in grid.Children)
            {
                if (child is Rectangle rect)
                {
                    rect.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#33FFFFFF"));
                    rect.StrokeThickness = 1.5;
                    rect.Effect = new System.Windows.Media.Effects.DropShadowEffect
                    {
                        BlurRadius = 14,
                        ShadowDepth = 0,
                        Opacity = 0.35,
                        Color = (Color)ColorConverter.ConvertFromString("#66222A3F")
                    };
                }
            }
        }

    }
}
