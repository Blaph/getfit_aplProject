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
    public partial class YourProfile : Form
    {
        int id = 0;
        int age = 30;
        char sex = 'M';
        float height = 160.0F;
        float weight = 65.0F;
        float caloricIntake = 0;
        string breakfast;
        string lunch;
        string dinner;

        public YourProfile(string id, string age, string sex, string height, string weight, string caloricIntake)
        {
            InitializeComponent();
            yourProfileAge.Text = age;
            yourProfileSex.Text = sex;
            yourProfileHeight.Text = height;
            yourProfileWeight.Text = weight;
            yourProfileIntake.Text = caloricIntake;
            this.id = int.Parse(id);
            this.age = int.Parse(age);
            this.sex = char.Parse(sex);
            this.height = float.Parse(height);
            this.weight = float.Parse(weight);
            this.caloricIntake = int.Parse(caloricIntake);
        }

        private void YourProfile_Load(object sender, EventArgs e)
        {

        }

        private void showAllIngredientsButton_Click(object sender, EventArgs e)
        {
            Ingredients ingredients = new Ingredients(id);
            ingredients.ShowDialog();
        }

        private void showAllRecipesButton_Click(object sender, EventArgs e)
        {
            Recipes recipes = new Recipes(id);
            recipes.ShowDialog();
        }

        private void makeNewMenuButton_Click(object sender, EventArgs e)
        {
            breakfastListBox.Items.Clear();
            lunchListBox.Items.Clear();
            dinnerListBox.Items.Clear();
            string[] rsp;
            string message = String.Format("makeNewMenu,{0},{1}", id, caloricIntake);
            Client client = new Client();
            string response = client.Connect(message);
            if (response.Equals("randomizeMenuError"))
            {
                MessageBox.Show("Impossibile generare un nuovo menù.", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (response.Equals("noPreferences")){
                MessageBox.Show("Non hai degli ingredienti preferiti. Corri subito ad aggiungerne alcuni!", "Aggiungi degli ingredienti preferiti!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rsp = response.Split(',');
                breakfast = rsp[0];
                lunch = rsp[1];
                dinner = rsp[2];

                breakfastListBox.Items.Add(breakfast);
                lunchListBox.Items.Add(lunch);
                dinnerListBox.Items.Add(dinner);
            }
        }
    }
}
