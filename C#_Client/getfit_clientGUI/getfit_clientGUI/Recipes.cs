using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace getfit_clientGUI
{
    public partial class Recipes : Form
    {
        int loggedUserID;
        int recipeID;

        public Recipes(int loggedUserID)
        {
            this.loggedUserID = loggedUserID;
            InitializeComponent();
        }

        private void Recipes_Load(object sender, EventArgs e)
        {
            recipesListBox.DoubleClick += new EventHandler(RecipesListBox_DoubleClick);
            string message = "showAllRecipes,0";
            string response = string.Empty;
            NetworkStream stream = null;
            Client client = new Client();
            TcpClient tcpClient = client.openConnection();
            client.sendCommand(tcpClient, message, stream);
            do
            {
                response = client.getData(tcpClient, stream);
                if (response != "endOfArray")
                {
                    recipesListBox.Items.Add(response);
                    client.sendCommand(tcpClient, "ack", stream);
                }
            } while (response != "endOfArray");
            client.closeConnection(tcpClient, stream);
        }

        private void RecipesListBox_DoubleClick(object sender, EventArgs e)
        {
            if (recipesListBox.SelectedItem != null)
            {
                string[] rsp;
                RecipeDescription recipeDescription = new RecipeDescription(loggedUserID, recipeID);
                string message = String.Format("showRecipe,{0}", recipesListBox.SelectedItem.ToString());
                NetworkStream stream = null;
                String response = String.Empty;
                Client client = new Client();

                TcpClient tcpClient = client.openConnection();
                client.sendCommand(tcpClient, message, stream);

                do  // Otteniamo tutti i passi della ricetta
                {
                    response = client.getData(tcpClient, stream);
                    if (response != "endOfArray")
                    {
                        recipeDescription.recipeStepsListBox.Items.Add(response);
                        client.sendCommand(tcpClient, "ack", stream);
                    }
                } while (response != "endOfArray");

                do  // Otteniamo tutti gli ingredienti della ricetta
                {
                    response = client.getData(tcpClient, stream);
                    if (response != "endOfArray")
                    {
                        recipeDescription.recipeIngredientsListBox.Items.Add(response);
                        client.sendCommand(tcpClient, "ack", stream);
                    }
                } while (response != "endOfArray");

                // Otteniamo avgKcal e recipeID
                response = client.getData(tcpClient, stream);
                rsp = response.Split(',');  // rsp[0] = avgKcal, rsp[1] = recipeID
                recipeDescription.recipeDescriptionKcal.Text = rsp[0];
                recipeID = int.Parse(rsp[1]);

                client.closeConnection(tcpClient, stream);
                recipeDescription.recipeDescriptionName.Text = recipesListBox.SelectedItem.ToString();
                recipeDescription.setRecipeID(recipeID);
                recipeDescription.Show();
            }
        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(loggedUserID);
            addRecipeWindow.Show();
        }
    }
}
