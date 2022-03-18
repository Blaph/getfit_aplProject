using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace getfit_clientGUI
{
    public partial class UserInfoWindow : Form
    {
        string email;
        string password;
        int age = 30;
        char sex = 'M';
        float height = 160.0F;
        float weight = 65.0F;
        float intensity = 1.2F;

        public UserInfoWindow(string email, string password)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            // Salvo email e password per inviarle al db una volta completata l'iscrizione
            this.email = email;
            this.password = password;
            ageSignUpUpDown.Value = 30;
            sexComboBox.SelectedIndex = 0;
            heightSignUpUpDown.Value = 160.0M;
            weightSignUpUpDown.Value = 65.0M;
            intensitySignUpComboBox.SelectedIndex = 0;
        }

        private void UserInfoWindow_Load(object sender, EventArgs e)
        {

        }

        private void ageSignUpUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.age = (int)ageSignUpUpDown.Value;
        }

        private void heightSignUpUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.height = (float)heightSignUpUpDown.Value;
        }

        private void weightSignUpUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.weight = (float)weightSignUpUpDown.Value;
        }

        private void sexComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sexComboBox.SelectedIndex == 0)
                this.sex = 'M';
            else
                this.sex = 'F';
        }

        private void intensitySignUpComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(intensitySignUpComboBox.SelectedIndex)
            {
                case 0:
                    this.intensity = 1.2F;
                    break;
                case 1:
                    this.intensity = 1.4F;
                    break;
                case 2:
                    this.intensity = 1.6F;
                    break;
                case 3:
                    this.intensity = 1.8F;
                    break;
                default:
                    MessageBox.Show("Valore non consentito!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (ageSignUpUpDown.Value < ageSignUpUpDown.Minimum || ageSignUpUpDown.Value > ageSignUpUpDown.Maximum || sexComboBox.SelectedIndex < 0 || sexComboBox.SelectedIndex > 1 || heightSignUpUpDown.Value < heightSignUpUpDown.Minimum || heightSignUpUpDown.Value > heightSignUpUpDown.Maximum || weightSignUpUpDown.Value < weightSignUpUpDown.Minimum || weightSignUpUpDown.Value > weightSignUpUpDown.Maximum || intensitySignUpComboBox.SelectedIndex < 0 || intensitySignUpComboBox.SelectedIndex > 3)
            {
                ageSignUpUpDown.Value = ageSignUpUpDown.Minimum;
                sexComboBox.SelectedIndex = 0;
                heightSignUpUpDown.Value = heightSignUpUpDown.Minimum;
                weightSignUpUpDown.Value = weightSignUpUpDown.Minimum;
                intensitySignUpComboBox.SelectedIndex = 0;
                MessageBox.Show("Riempire tutti i campi con valori consentiti!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try 
                {
                    string message = string.Format("signup,{0},{1},{2},{3},{4},{5},{6}", email, password, age, sex, height, weight, intensity);
                    Client client = new Client();
                    string response = client.Connect(message);
                    if (response.Equals("error"))
                        MessageBox.Show("Errore durante l'inserimento dei dati!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        // Se i dati sono stati inseriti correttamente, porta l'utente alla sua dashboard.
                        MessageBox.Show("Dati inseriti correttamente!", "Dati inseriti!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            message = string.Format("selectUser,{0},{1}", email, password);
                            client = new Client();
                            response = client.Connect(message);
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
                        catch (Exception ex)
                        {
                            Console.WriteLine("Errore: {0}", ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: ", ex);
                }
            }
        }
    }
}
