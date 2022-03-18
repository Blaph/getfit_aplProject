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
    public partial class AddStepWindow : Form
    {
        AddRecipeWindow addRecipeWindow;
        int stepID;
        string recipeStep;

        public AddStepWindow(AddRecipeWindow addRecipeWindow, int stepID)
        {
            this.addRecipeWindow = addRecipeWindow;
            this.stepID = stepID;
            InitializeComponent();
        }

        private void addRecipeStepButton_Click(object sender, EventArgs e)
        {
            if (recipeStepTextBox.Text == String.Empty || recipeStepTextBox.Text.Contains(","))
                MessageBox.Show("Per favore, inserisci un passo da seguire:\nIl passo non deve contenere ','.", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                recipeStep = recipeStepTextBox.Text;
                addRecipeWindow.recipeStepsListBox.Items.Add(this.stepID + "," + recipeStep);
                stepID++;
            }
        }
    }
}
