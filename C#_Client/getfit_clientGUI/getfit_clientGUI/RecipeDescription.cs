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
    public partial class RecipeDescription : Form
    {
        int loggedUserID;
        int recipeID;

        public RecipeDescription(int loggedUserID, int recipeID)
        {
            this.loggedUserID = loggedUserID;
            this.recipeID = recipeID;
            InitializeComponent();
        }

        private void RecipeDescription_Load(object sender, EventArgs e)
        {
            string message = String.Format("isFavouriteRecipe,{0},{1}", loggedUserID, recipeID);
            Client client = new Client();
            string response = client.Connect(message);
            if (response.Equals("favouriteRecipeFound"))
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
            string message = String.Format("addFavouriteRecipe,{0},{1}", loggedUserID, recipeID);
            Client client = new Client();
            string response = client.Connect(message);
            if (response.Equals("favouriteRecipeError"))
            {
                MessageBox.Show("Impossibile aggiungere la ricetta ai preferiti!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string message = String.Format("removeFavouriteRecipe,{0},{1}", loggedUserID, recipeID);
            Client client = new Client();
            string response = client.Connect(message);
            if (response.Equals("removeFavouriteRecipeError"))
            {
                MessageBox.Show("Impossibile rimuovere la ricetta dai preferiti!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                removeFavouriteButton.Enabled = false;
                removeFavouriteButton.Hide();
                addFavouriteButton.Show();
                addFavouriteButton.Enabled = true;
            }
        }

        internal void setRecipeID(int recipeID)
        {
            this.recipeID = recipeID;
        }
    }
}
