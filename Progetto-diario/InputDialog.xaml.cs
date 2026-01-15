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
    public partial class InputDialog : Window
    {
        public string NomeDiario { get; private set; }
        public bool PasswordAttiva { get; private set; }
        public string Password { get; private set; }

        public InputDialog()
        {
            InitializeComponent();
        }

        private void chkPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPassword.Visibility = Visibility.Visible;
        }

        private void chkPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPassword.Visibility = Visibility.Collapsed;
            txtPassword.Password = "";
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            NomeDiario = txtInput.Text;
            PasswordAttiva = chkPassword.IsChecked == true;
            Password = PasswordAttiva ? txtPassword.Password : "";

            DialogResult = true;
            Close();
        }
    }
}

