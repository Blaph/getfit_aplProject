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
    public partial class Ingredients : Form
    {
        int loggedUserID = 0;
        AddRecipeWindow addRecipeWindow;
        int kcal = 0;

        public Ingredients(int loggedUserID)
        {
            this.loggedUserID = loggedUserID;
            InitializeComponent();
        }

        public Ingredients(int loggedUserID, AddRecipeWindow addRecipeWindow) // Usato durante "aggiungi una nuova ricetta"
        {
            this.addRecipeWindow = addRecipeWindow;
            this.loggedUserID = loggedUserID;
            InitializeComponent();
            gQuantityLabel.Visible = true;
            gQuantityUpDown.Enabled = true;
            gQuantityUpDown.Visible = true;
            addRecipeIngredientButton.Enabled = true;
            addRecipeIngredientButton.Visible = true;
        }

        private void Ingredients_Load(object sender, EventArgs e)
        {
            ingredientsListBox.DoubleClick += new EventHandler(IngredientsListBox_DoubleClick);
            string message = "showAllIngredients,0";
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
                    ingredientsListBox.Items.Add(response);
                    client.sendCommand(tcpClient, "ack", stream);
                }
            } while (response != "endOfArray");
            client.closeConnection(tcpClient, stream);
        }

        private void IngredientsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (ingredientsListBox.SelectedItem != null)
            {
                string message = String.Format("showIngredient,{0}", ingredientsListBox.SelectedItem.ToString());
                Client client = new Client();
                string response = client.Connect(message);
                if (response.Equals("ingredientNotFound"))
                    MessageBox.Show("Ingrediente non trovato!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string[] rsp = response.Split(',');
                    // Stiamo passando ingredientID, ingredientName, kcal, carbs, proteins, fats, userID dell'ingrediente selezionato
                    IngredientDescription ingredientDescription = new IngredientDescription(rsp[0], rsp[1], rsp[2], rsp[3], rsp[4], rsp[5], rsp[6], loggedUserID);
                    ingredientDescription.ShowDialog();
                }
            }
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            AddIngredientDescriptionWindow addIngredientDescriptionWindow = new AddIngredientDescriptionWindow(loggedUserID);
            addIngredientDescriptionWindow.Show();
        }

        private void addRecipeIngredientButton_Click(object sender, EventArgs e)
        {
            string ingredientName = ingredientsListBox.SelectedItem.ToString();
            int quantity = (int)gQuantityUpDown.Value;
            addRecipeWindow.recipeIngredientsListBox.Items.Add(ingredientName + "," + quantity);
            calculateKcal(ingredientName, quantity);
        }

        private void calculateKcal(string ingredientName, int quantity)
        {
            if (ingredientsListBox.SelectedItem != null)
            {
                string message = String.Format("showIngredient,{0}", ingredientName);
                Client client = new Client();
                string response = client.Connect(message);
                if (response.Equals("ingredientNotFound"))
                    MessageBox.Show("Ingrediente non trovato!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string[] rsp = response.Split(',');
                    
                    // Stiamo passando ingredientID, ingredientName, kcal, carbs, proteins, fats, userID dell'ingrediente selezionato
                    IngredientDescription ingredientDescription = new IngredientDescription(rsp[0], rsp[1], rsp[2], rsp[3], rsp[4], rsp[5], rsp[6], loggedUserID);

                    // Calcoliamo le kcal in proporzione alla quantità dell'ingrediente
                    // Le kcal vengono determinate per 100g di prodotto (rsp[2] = kcal del prodotto)
                    // kcal : quantity = rsp[2] : 100
                    if (int.Parse(rsp[2]) != 0 && quantity != 0)
                        kcal = (int.Parse(rsp[2]) * quantity) / 100;
                    else
                        kcal = 0;
                    addRecipeWindow.setAvgKcal(kcal);
                }
            }
        }
    }
}
