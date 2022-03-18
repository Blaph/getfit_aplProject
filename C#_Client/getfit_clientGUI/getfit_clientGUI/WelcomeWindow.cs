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
    public partial class WelcomeWindow : Form
    {

        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            string message = string.Format("selectUser,{0},{1}", emailWelcomeTextBox.Text, passwordWelcomeTextBox.Text);
            Client client = new Client();
            string response = client.Connect(message);
            if (response.Equals("userNotFound"))
                MessageBox.Show("Utente non trovato! Controlla che i campi inseriti siano corretti.", "Utente non trovato!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string[] rsp = response.Split(',');
                this.Hide();
                // Stiamo passando id, age, sex, height, weight, caloricIntake dell'utente che sta accadendo alla sua dashboard
                YourProfile yourProfile = new YourProfile(rsp[0], rsp[1], rsp[2], rsp[3], rsp[4], rsp[5]);
                yourProfile.ShowDialog();
                this.Close();
            }
        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpWindow signUpWindow = new SignUpWindow(emailWelcomeTextBox.Text);
            signUpWindow.ShowDialog();
            this.Close();
        }

        private void emailWelcomeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
