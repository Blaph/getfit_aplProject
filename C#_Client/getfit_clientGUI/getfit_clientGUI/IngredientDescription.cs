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
    public partial class IngredientDescription : Form
    {
        int ingredientID;
        string ingredientName;
        int kcal;
        float carbs;
        float proteins;
        float fats;
        int userID;
        int loggedUserID;

        public IngredientDescription(string ingredientID, string ingredientName, string kcal, string carbs, string proteins, string fats, string userID, int loggedUserID)
        {
            InitializeComponent();
            ingredientDescriptionID.Text = ingredientID;
            ingredientDescriptionName.Text = ingredientName;
            ingredientDescriptionKcal.Text = kcal;
            ingredientDescriptionCarbs.Text = carbs;
            ingredientDescriptionProteins.Text = proteins;
            ingredientDescriptionFats.Text = fats;
            ingredientDescriptionUserID.Text = userID;
            this.ingredientID = int.Parse(ingredientID);
            this.ingredientName = ingredientName;
            this.kcal = int.Parse(kcal);
            this.carbs = float.Parse(carbs);
            this.proteins = float.Parse(proteins);
            this.fats = float.Parse(fats);
            this.userID = int.Parse(userID);
            this.loggedUserID = loggedUserID;
        }

        private void IngredientDescription_Load(object sender, EventArgs e)
        {
            string message = String.Format("isFavouriteIngredient,{0},{1}", loggedUserID, ingredientID);
            Client client = new Client();
            string response = client.Connect(message);
            if (response.Equals("favouriteIngredientFound"))
            {
                addFavouriteButton.Enabled = false;
                addFavouriteButton.Hide();
                removeFavouriteButton.Show();
                removeFavouriteButton.Enabled = true;
            }
            else
            {
                removeFavouriteButton.Enabled = false;
                removeFavouriteButton.Hide();
                addFavouriteButton.Show();
                addFavouriteButton.Enabled = true;
            }
        }

        private void addFavouriteButton_Click(object sender, EventArgs e)
        {
            string message = String.Format("addFavouriteIngredient,{0},{1}", loggedUserID, ingredientID);
            Client client = new Client();
            string response = client.Connect(message);
            if (response.Equals("favouriteIngredientError"))
            {
                MessageBox.Show("Impossibile aggiungere l'alimento ai preferiti!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                addFavouriteButton.Enabled = false;
                addFavouriteButton.Hide();
                removeFavouriteButton.Show();
                removeFavouriteButton.Enabled = true;
            }
        }

        private void removeFavouriteButton_Click(object sender, EventArgs e)
        {
            string message = String.Format("removeFavouriteIngredient,{0},{1}", loggedUserID, ingredientID);
            Client client = new Client();
            string response = client.Connect(message);
            if (response.Equals("removeFavouriteIngredientError"))
            {
                MessageBox.Show("Impossibile rimuovere l'alimento dai preferiti!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                removeFavouriteButton.Enabled = false;
                removeFavouriteButton.Hide();
                addFavouriteButton.Show();
                addFavouriteButton.Enabled = true;
            }
        }
    }
}
