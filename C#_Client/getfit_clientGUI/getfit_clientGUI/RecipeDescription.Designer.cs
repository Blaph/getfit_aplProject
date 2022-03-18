namespace getfit_clientGUI
{
    partial class RecipeDescription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ingredientDescriptionUserID = new System.Windows.Forms.Label();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.ingredientDescriptionID = new System.Windows.Forms.Label();
            this.recipeIDLabel = new System.Windows.Forms.Label();
            this.removeFavouriteButton = new System.Windows.Forms.Button();
            this.addFavouriteButton = new System.Windows.Forms.Button();
            this.recipeDescriptionKcal = new System.Windows.Forms.Label();
            this.kcalLabel = new System.Windows.Forms.Label();
            this.recipeDescriptionName = new System.Windows.Forms.Label();
            this.recipeStepsGroup = new System.Windows.Forms.GroupBox();
            this.recipeStepsListBox = new System.Windows.Forms.ListBox();
            this.recipeIngredientsGroup = new System.Windows.Forms.GroupBox();
            this.recipeIngredientsListBox = new System.Windows.Forms.ListBox();
            this.recipeStepsGroup.SuspendLayout();
            this.recipeIngredientsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ingredientDescriptionUserID
            // 
            this.ingredientDescriptionUserID.AutoSize = true;
            this.ingredientDescriptionUserID.Location = new System.Drawing.Point(104, 173);
            this.ingredientDescriptionUserID.Name = "ingredientDescriptionUserID";
            this.ingredientDescriptionUserID.Size = new System.Drawing.Size(23, 13);
            this.ingredientDescriptionUserID.TabIndex = 29;
            this.ingredientDescriptionUserID.Text = "null";
            this.ingredientDescriptionUserID.Visible = false;
            // 
            // userIDLabel
            // 
            this.userIDLabel.AutoSize = true;
            this.userIDLabel.Location = new System.Drawing.Point(26, 173);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(54, 13);
            this.userIDLabel.TabIndex = 28;
            this.userIDLabel.Text = "ID utente:";
            this.userIDLabel.Visible = false;
            // 
            // ingredientDescriptionID
            // 
            this.ingredientDescriptionID.AutoSize = true;
            this.ingredientDescriptionID.Location = new System.Drawing.Point(104, 142);
            this.ingredientDescriptionID.Name = "ingredientDescriptionID";
            this.ingredientDescriptionID.Size = new System.Drawing.Size(23, 13);
            this.ingredientDescriptionID.TabIndex = 27;
            this.ingredientDescriptionID.Text = "null";
            this.ingredientDescriptionID.Visible = false;
            // 
            // recipeIDLabel
            // 
            this.recipeIDLabel.AutoSize = true;
            this.recipeIDLabel.Location = new System.Drawing.Point(27, 142);
            this.recipeIDLabel.Name = "recipeIDLabel";
            this.recipeIDLabel.Size = new System.Drawing.Size(53, 13);
            this.recipeIDLabel.TabIndex = 26;
            this.recipeIDLabel.Text = "ID ricetta:";
            this.recipeIDLabel.Visible = false;
            // 
            // removeFavouriteButton
            // 
            this.removeFavouriteButton.Location = new System.Drawing.Point(12, 220);
            this.removeFavouriteButton.Name = "removeFavouriteButton";
            this.removeFavouriteButton.Size = new System.Drawing.Size(142, 23);
            this.removeFavouriteButton.TabIndex = 25;
            this.removeFavouriteButton.Text = "Rimuovi preferito";
            this.removeFavouriteButton.UseVisualStyleBackColor = true;
            this.removeFavouriteButton.Click += new System.EventHandler(this.removeFavouriteButton_Click);
            // 
            // addFavouriteButton
            // 
            this.addFavouriteButton.Location = new System.Drawing.Point(12, 220);
            this.addFavouriteButton.Name = "addFavouriteButton";
            this.addFavouriteButton.Size = new System.Drawing.Size(142, 23);
            this.addFavouriteButton.TabIndex = 24;
            this.addFavouriteButton.Text = "Aggiungi preferito";
            this.addFavouriteButton.UseVisualStyleBackColor = true;
            this.addFavouriteButton.Click += new System.EventHandler(this.addFavouriteButton_Click);
            // 
            // recipeDescriptionKcal
            // 
            this.recipeDescriptionKcal.AutoSize = true;
            this.recipeDescriptionKcal.Location = new System.Drawing.Point(27, 95);
            this.recipeDescriptionKcal.Name = "recipeDescriptionKcal";
            this.recipeDescriptionKcal.Size = new System.Drawing.Size(23, 13);
            this.recipeDescriptionKcal.TabIndex = 20;
            this.recipeDescriptionKcal.Text = "null";
            // 
            // kcalLabel
            // 
            this.kcalLabel.AutoSize = true;
            this.kcalLabel.Location = new System.Drawing.Point(27, 66);
            this.kcalLabel.Name = "kcalLabel";
            this.kcalLabel.Size = new System.Drawing.Size(31, 13);
            this.kcalLabel.TabIndex = 16;
            this.kcalLabel.Text = "Kcal:";
            // 
            // recipeDescriptionName
            // 
            this.recipeDescriptionName.AutoSize = true;
            this.recipeDescriptionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeDescriptionName.Location = new System.Drawing.Point(27, 9);
            this.recipeDescriptionName.Name = "recipeDescriptionName";
            this.recipeDescriptionName.Size = new System.Drawing.Size(53, 18);
            this.recipeDescriptionName.TabIndex = 15;
            this.recipeDescriptionName.Text = "Nome";
            // 
            // recipeStepsGroup
            // 
            this.recipeStepsGroup.Controls.Add(this.recipeStepsListBox);
            this.recipeStepsGroup.Location = new System.Drawing.Point(379, 32);
            this.recipeStepsGroup.Name = "recipeStepsGroup";
            this.recipeStepsGroup.Size = new System.Drawing.Size(552, 211);
            this.recipeStepsGroup.TabIndex = 31;
            this.recipeStepsGroup.TabStop = false;
            this.recipeStepsGroup.Text = "Passi";
            // 
            // recipeStepsListBox
            // 
            this.recipeStepsListBox.FormattingEnabled = true;
            this.recipeStepsListBox.HorizontalScrollbar = true;
            this.recipeStepsListBox.Location = new System.Drawing.Point(7, 20);
            this.recipeStepsListBox.Name = "recipeStepsListBox";
            this.recipeStepsListBox.Size = new System.Drawing.Size(539, 173);
            this.recipeStepsListBox.TabIndex = 0;
            // 
            // recipeIngredientsGroup
            // 
            this.recipeIngredientsGroup.Controls.Add(this.recipeIngredientsListBox);
            this.recipeIngredientsGroup.Location = new System.Drawing.Point(173, 32);
            this.recipeIngredientsGroup.Name = "recipeIngredientsGroup";
            this.recipeIngredientsGroup.Size = new System.Drawing.Size(180, 211);
            this.recipeIngredientsGroup.TabIndex = 30;
            this.recipeIngredientsGroup.TabStop = false;
            this.recipeIngredientsGroup.Text = "Ingredienti";
            // 
            // recipeIngredientsListBox
            // 
            this.recipeIngredientsListBox.FormattingEnabled = true;
            this.recipeIngredientsListBox.HorizontalScrollbar = true;
            this.recipeIngredientsListBox.Location = new System.Drawing.Point(15, 20);
            this.recipeIngredientsListBox.Name = "recipeIngredientsListBox";
            this.recipeIngredientsListBox.Size = new System.Drawing.Size(149, 173);
            this.recipeIngredientsListBox.TabIndex = 1;
            // 
            // RecipeDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 262);
            this.Controls.Add(this.recipeStepsGroup);
            this.Controls.Add(this.recipeIngredientsGroup);
            this.Controls.Add(this.ingredientDescriptionUserID);
            this.Controls.Add(this.userIDLabel);
            this.Controls.Add(this.ingredientDescriptionID);
            this.Controls.Add(this.recipeIDLabel);
            this.Controls.Add(this.removeFavouriteButton);
            this.Controls.Add(this.addFavouriteButton);
            this.Controls.Add(this.recipeDescriptionKcal);
            this.Controls.Add(this.kcalLabel);
            this.Controls.Add(this.recipeDescriptionName);
            this.Name = "RecipeDescription";
            this.Text = "RecipeDescription";
            this.Load += new System.EventHandler(this.RecipeDescription_Load);
            this.recipeStepsGroup.ResumeLayout(false);
            this.recipeIngredientsGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ingredientDescriptionUserID;
        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.Label ingredientDescriptionID;
        private System.Windows.Forms.Label recipeIDLabel;
        private System.Windows.Forms.Button removeFavouriteButton;
        private System.Windows.Forms.Button addFavouriteButton;
        private System.Windows.Forms.Label kcalLabel;
        private System.Windows.Forms.GroupBox recipeStepsGroup;
        internal System.Windows.Forms.ListBox recipeStepsListBox;
        private System.Windows.Forms.GroupBox recipeIngredientsGroup;
        internal System.Windows.Forms.Label recipeDescriptionName;
        internal System.Windows.Forms.ListBox recipeIngredientsListBox;
        internal System.Windows.Forms.Label recipeDescriptionKcal;
    }
}