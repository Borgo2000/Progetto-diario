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
    public partial class PasswordDialog : Window
    {
        private GestoreDiario diario;

        public bool AccessoConsentito { get; private set; } = false;

        internal PasswordDialog(GestoreDiario diario)
        {
            InitializeComponent();
            this.diario = diario;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            diario.validaDiario(txtPassword.Password);
            if (diario.isValidato())
            {

                AccessoConsentito = true;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Password errata");
                AccessoConsentito = false;
            }
        }
    }
}
