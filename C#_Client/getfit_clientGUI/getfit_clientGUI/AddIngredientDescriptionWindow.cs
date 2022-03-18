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
    public partial class AddIngredientDescriptionWindow : Form
    {
        string ingredientName = string.Empty;
        int kcal = 0;
        float carbs = 0;
        float proteins = 0;
        float fats = 0;
        int loggedUserID = 0;
        bool favourite = false;

        public AddIngredientDescriptionWindow(int loggedUserID)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            this.loggedUserID = loggedUserID;
            InitializeComponent();
        }

        private void addNewIngredientButton_Click(object sender, EventArgs e)
        {
            if (ingredientNameTextBox.Text.Equals(String.Empty) || ingredientNameTextBox.Text.Contains(","))
            {
                MessageBox.Show("Per favore, compila correttamente tutti i campi:\nIl nome dell'ingrediente non deve contenere ','.", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    ingredientName = ingredientNameTextBox.Text;
                    string message = string.Format("addNewIngredient,{0},{1},{2},{3},{4},{5},{6}", ingredientName, kcal, carbs, proteins, fats, loggedUserID, favourite);
                    Client client = new Client();
                    string response = client.Connect(message);
                    if (response.Equals("ingredientExistent"))
                        MessageBox.Show("Ingrediente già presente!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        // Se i dati sono stati inseriti correttamente, verifica che l'ingrediente non sia già presente.
                        MessageBox.Show("Dati inseriti correttamente!\nAggiorna la finestra con gli ingredienti.", "Dati inseriti!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: ", ex);
                }
            }
        }

        private void kcalUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.kcal = (int)kcalUpDown.Value;
        }

        private void carbsUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.carbs = (float)carbsUpDown.Value;
        }

        private void proteinsUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.proteins = (float)proteinsUpDown.Value;
        }

        private void fatsUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.fats = (float)fatsUpDown.Value;
        }

        private void favouriteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (favouriteCheckBox.Checked)
            {
                this.favourite = true;
            }
            else
            {
                this.favourite = false;
            }
        }

        private void AddIngredientDescriptionWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
