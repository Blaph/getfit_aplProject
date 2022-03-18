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
    public partial class AddRecipeWindow : Form
    {
        int loggedUserID;
        string recipeName;
        int avgKcal = 0;
        bool breakfast;
        bool lunch;
        bool dinner;
        bool favourite;

        public AddRecipeWindow(int loggedUserID)
        {
            this.loggedUserID = loggedUserID;
            InitializeComponent();
        }

        private void AddRecipeWindow_Load(object sender, EventArgs e)
        {

        }

        private void addNewRecipeButton_Click(object sender, EventArgs e)
        {
            if (recipeNameTextBox.Text.Equals(String.Empty) || recipeNameTextBox.Text.Contains(","))
            {
                MessageBox.Show("Per favore, compila correttamente tutti i campi:\nIl nome della ricetta non deve contenere ','.", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else if (recipeIngredientsListBox.Items.Count == 0)
            {
                MessageBox.Show("Per favore, inserici almeno un ingrediente.", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (recipeStepsListBox.Items.Count == 0)
            {
                MessageBox.Show("Per favore, inserici almeno un passo da eseguire.", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    recipeName = recipeNameTextBox.Text;
                    string message = string.Format("addNewRecipe,{0},{1},{2},{3},{4},{5},{6}", recipeName, avgKcal, breakfast, lunch, dinner, loggedUserID, favourite);
                    Client client = new Client();
                    string response = client.Connect(message);
                    string[] rsp  = response.Split(',');
                    string result = rsp[0];
                    // Se i dati sono stati inseriti correttamente, verifica che la ricetta non sia già presente.
                    if (result.Equals("recipeExistent"))
                        MessageBox.Show("Ricetta già presente!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        // Aggiungere gli ingredienti della ricetta al db
                        foreach (string item in recipeIngredientsListBox.Items)
                        {
                            try
                            {
                                // Stiamo inviando recipeID,ingredientName,gQuantity (item = ingredientName,gQuantity)
                                message = string.Format("addRecipeIngredients,{0},{1}", rsp[1], item);
                                response = client.Connect(message);
                                if (response.Equals("addRecipeIngredientError") || response.Equals("ingredientNotFound"))
                                {
                                    MessageBox.Show("Impossibile aggiungere l'ingrediente!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (response.Equals("duplicateIngredient"))
                                {
                                    MessageBox.Show("Ingrediente già presente!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: ", ex);
                            }
                        }

                        // Aggiungiamo i passi della ricetta al db
                        foreach (string item in recipeStepsListBox.Items)
                        {
                            try
                            {
                                // Stiamo inviando recipeID,stepID,stepDesc (item = stepID,stepDesc)
                                message = string.Format("addRecipeSteps,{0},{1}", rsp[1], item);
                                response = client.Connect(message);
                                if (response.Equals("addRecipeStepsError"))
                                {
                                    MessageBox.Show("Impossibile aggiungere il passo!", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: ", ex);
                            }
                        }
                        if (!response.Equals("addRecipeIngredientError") && !response.Equals("ingredientNotFound") && !response.Equals("duplicateIngredient"))
                        {
                            MessageBox.Show("Dati inseriti correttamente!\nAggiorna la finestra delle ricette.", "Dati inseriti!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: ", ex);
                }
            }
        }

        private void breakfastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (breakfastCheckBox.Checked)
                breakfast = true;
            else
                breakfast = false;
        }

        private void lunchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lunchCheckBox.Checked)
                lunch = true;
            else
                lunch = false;
        }

        private void dinnerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dinnerCheckBox.Checked)
                dinner = true;
            else 
                dinner = false;
        }

        private void addRecipeIngredientButton_Click(object sender, EventArgs e)
        {
            Ingredients ingredients = new Ingredients(loggedUserID, this);
            ingredients.Show();
        }

        private void addRecipeStepButton_Click(object sender, EventArgs e)
        {
            int stepCount = recipeStepsListBox.Items.Count;
            AddStepWindow addStepWindow = new AddStepWindow(this, stepCount+1);
            addStepWindow.Show();
        }

        public void setAvgKcal(int kcal)
        {
            avgKcal += kcal;
        }

        private void favouriteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (favouriteCheckBox.Checked)
            {
                favourite = true;
            }
            else
            {
                favourite = false;
            }
        }
    }
}
