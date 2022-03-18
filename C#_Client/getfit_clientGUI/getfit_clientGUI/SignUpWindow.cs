using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace getfit_clientGUI
{
    public partial class SignUpWindow : Form
    {
        public SignUpWindow(string email)
        {
            InitializeComponent();
            signUpEmailTextBox.Text = email;
        }

        private void SignUpWindow_Load(object sender, EventArgs e)
        {

        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            if (signUpEmailTextBox.Text.Contains(",") || !signUpEmailTextBox.Text.Contains("@") || passwordSignUpTextBox.Text.Contains(","))
            {
                signUpEmailTextBox.Text = string.Empty;
                passwordSignUpTextBox.Text = string.Empty;
                passConfirmSignUpTextBox.Text = string.Empty;
                MessageBox.Show("Per favore, compila correttamente tutti i campi:\n-L'email deve contenere '@' e non ','.\n-La password non deve contenere ','.", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (passwordSignUpTextBox.Text.Equals(passConfirmSignUpTextBox.Text) && (!signUpEmailTextBox.Text.Equals(string.Empty) && !passwordSignUpTextBox.Text.Equals(string.Empty) && !passConfirmSignUpTextBox.Text.Equals(string.Empty)))
            {
                // se il testo delle password è uguale, allora apri la nuova finestra e richiedi i nuovi dati
                try
                {
                    MessageBox.Show("Dati inseriti correttamente!", "Dati inseriti!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    UserInfoWindow userInfoWindow = new UserInfoWindow(signUpEmailTextBox.Text, passwordSignUpTextBox.Text);
                    userInfoWindow.ShowDialog();
                    this.Close();
                } catch (Exception ex)
                {
                    Console.WriteLine("Errore: {0}", ex);
                }
            }
            else if(signUpEmailTextBox.Text.Equals(string.Empty) || passwordSignUpTextBox.Text.Equals(string.Empty) || passConfirmSignUpTextBox.Text.Equals(string.Empty))
            {
                // se uno dei campi è vuoto, allora richiedi l'immissione dei dati e mostra una finestra di errore
                passwordSignUpTextBox.Text = string.Empty;
                passConfirmSignUpTextBox.Text = string.Empty;
                MessageBox.Show("Per favore, riempi tutti i campi!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Se le password non corrispondono, allora mostra un errore
                passwordSignUpTextBox.Text = string.Empty;
                passConfirmSignUpTextBox.Text = string.Empty;
                MessageBox.Show("Le password non corrispondono!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
