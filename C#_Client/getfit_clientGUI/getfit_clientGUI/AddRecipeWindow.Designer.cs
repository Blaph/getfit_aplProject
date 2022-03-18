namespace getfit_clientGUI
{
    partial class AddRecipeWindow
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
            this.recipeNameLabel = new System.Windows.Forms.Label();
            this.recipeNameTextBox = new System.Windows.Forms.TextBox();
            this.addNewRecipeButton = new System.Windows.Forms.Button();
            this.recipeIngredientsGroup = new System.Windows.Forms.GroupBox();
            this.addRecipeIngredientButton = new System.Windows.Forms.Button();
            this.recipeIngredientsListBox = new System.Windows.Forms.ListBox();
            this.recipeStepsGroup = new System.Windows.Forms.GroupBox();
            this.addRecipeStepButton = new System.Windows.Forms.Button();
            this.recipeStepsListBox = new System.Windows.Forms.ListBox();
            this.breakfastCheckBox = new System.Windows.Forms.CheckBox();
            this.lunchCheckBox = new System.Windows.Forms.CheckBox();
            this.dinnerCheckBox = new System.Windows.Forms.CheckBox();
            this.favouriteCheckBox = new System.Windows.Forms.CheckBox();
            this.recipeIngredientsGroup.SuspendLayout();
            this.recipeStepsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // recipeNameLabel
            // 
            this.recipeNameLabel.AutoSize = true;
            this.recipeNameLabel.Location = new System.Drawing.Point(28, 27);
            this.recipeNameLabel.Name = "recipeNameLabel";
            this.recipeNameLabel.Size = new System.Drawing.Size(38, 13);
            this.recipeNameLabel.TabIndex = 0;
            this.recipeNameLabel.Text = "Nome:";
            // 
            // recipeNameTextBox
            // 
            this.recipeNameTextBox.Location = new System.Drawing.Point(72, 24);
            this.recipeNameTextBox.Name = "recipeNameTextBox";
            this.recipeNameTextBox.Size = new System.Drawing.Size(559, 20);
            this.recipeNameTextBox.TabIndex = 1;
            // 
            // addNewRecipeButton
            // 
            this.addNewRecipeButton.Location = new System.Drawing.Point(335, 328);
            this.addNewRecipeButton.Name = "addNewRecipeButton";
            this.addNewRecipeButton.Size = new System.Drawing.Size(149, 23);
            this.addNewRecipeButton.TabIndex = 3;
            this.addNewRecipeButton.Text = "Aggiungi ricetta";
            this.addNewRecipeButton.UseVisualStyleBackColor = true;
            this.addNewRecipeButton.Click += new System.EventHandler(this.addNewRecipeButton_Click);
            // 
            // recipeIngredientsGroup
            // 
            this.recipeIngredientsGroup.Controls.Add(this.addRecipeIngredientButton);
            this.recipeIngredientsGroup.Controls.Add(this.recipeIngredientsListBox);
            this.recipeIngredientsGroup.Location = new System.Drawing.Point(31, 70);
            this.recipeIngredientsGroup.Name = "recipeIngredientsGroup";
            this.recipeIngredientsGroup.Size = new System.Drawing.Size(180, 243);
            this.recipeIngredientsGroup.TabIndex = 4;
            this.recipeIngredientsGroup.TabStop = false;
            this.recipeIngredientsGroup.Text = "Ingredienti";
            // 
            // addRecipeIngredientButton
            // 
            this.addRecipeIngredientButton.Location = new System.Drawing.Point(15, 211);
            this.addRecipeIngredientButton.Name = "addRecipeIngredientButton";
            this.addRecipeIngredientButton.Size = new System.Drawing.Size(149, 23);
            this.addRecipeIngredientButton.TabIndex = 1;
            this.addRecipeIngredientButton.Text = "Aggiungi ingrediente";
            this.addRecipeIngredientButton.UseVisualStyleBackColor = true;
            this.addRecipeIngredientButton.Click += new System.EventHandler(this.addRecipeIngredientButton_Click);
            // 
            // recipeIngredientsListBox
            // 
            this.recipeIngredientsListBox.FormattingEnabled = true;
            this.recipeIngredientsListBox.HorizontalScrollbar = true;
            this.recipeIngredientsListBox.Location = new System.Drawing.Point(15, 19);
            this.recipeIngredientsListBox.Name = "recipeIngredientsListBox";
            this.recipeIngredientsListBox.Size = new System.Drawing.Size(149, 186);
            this.recipeIngredientsListBox.TabIndex = 0;
            // 
            // recipeStepsGroup
            // 
            this.recipeStepsGroup.Controls.Add(this.addRecipeStepButton);
            this.recipeStepsGroup.Controls.Add(this.recipeStepsListBox);
            this.recipeStepsGroup.Location = new System.Drawing.Point(237, 70);
            this.recipeStepsGroup.Name = "recipeStepsGroup";
            this.recipeStepsGroup.Size = new System.Drawing.Size(400, 243);
            this.recipeStepsGroup.TabIndex = 5;
            this.recipeStepsGroup.TabStop = false;
            this.recipeStepsGroup.Text = "Passi";
            // 
            // addRecipeStepButton
            // 
            this.addRecipeStepButton.Location = new System.Drawing.Point(129, 212);
            this.addRecipeStepButton.Name = "addRecipeStepButton";
            this.addRecipeStepButton.Size = new System.Drawing.Size(149, 23);
            this.addRecipeStepButton.TabIndex = 1;
            this.addRecipeStepButton.Text = "Aggiungi passo";
            this.addRecipeStepButton.UseVisualStyleBackColor = true;
            this.addRecipeStepButton.Click += new System.EventHandler(this.addRecipeStepButton_Click);
            // 
            // recipeStepsListBox
            // 
            this.recipeStepsListBox.FormattingEnabled = true;
            this.recipeStepsListBox.HorizontalScrollbar = true;
            this.recipeStepsListBox.Location = new System.Drawing.Point(7, 20);
            this.recipeStepsListBox.Name = "recipeStepsListBox";
            this.recipeStepsListBox.Size = new System.Drawing.Size(387, 186);
            this.recipeStepsListBox.TabIndex = 0;
            // 
            // breakfastCheckBox
            // 
            this.breakfastCheckBox.AutoSize = true;
            this.breakfastCheckBox.Location = new System.Drawing.Point(29, 332);
            this.breakfastCheckBox.Name = "breakfastCheckBox";
            this.breakfastCheckBox.Size = new System.Drawing.Size(72, 17);
            this.breakfastCheckBox.TabIndex = 6;
            this.breakfastCheckBox.Text = "Colazione";
            this.breakfastCheckBox.UseVisualStyleBackColor = true;
            this.breakfastCheckBox.CheckedChanged += new System.EventHandler(this.breakfastCheckBox_CheckedChanged);
            // 
            // lunchCheckBox
            // 
            this.lunchCheckBox.AutoSize = true;
            this.lunchCheckBox.Location = new System.Drawing.Point(134, 332);
            this.lunchCheckBox.Name = "lunchCheckBox";
            this.lunchCheckBox.Size = new System.Drawing.Size(59, 17);
            this.lunchCheckBox.TabIndex = 7;
            this.lunchCheckBox.Text = "Pranzo";
            this.lunchCheckBox.UseVisualStyleBackColor = true;
            this.lunchCheckBox.CheckedChanged += new System.EventHandler(this.lunchCheckBox_CheckedChanged);
            // 
            // dinnerCheckBox
            // 
            this.dinnerCheckBox.AutoSize = true;
            this.dinnerCheckBox.Location = new System.Drawing.Point(230, 332);
            this.dinnerCheckBox.Name = "dinnerCheckBox";
            this.dinnerCheckBox.Size = new System.Drawing.Size(51, 17);
            this.dinnerCheckBox.TabIndex = 8;
            this.dinnerCheckBox.Text = "Cena";
            this.dinnerCheckBox.UseVisualStyleBackColor = true;
            this.dinnerCheckBox.CheckedChanged += new System.EventHandler(this.dinnerCheckBox_CheckedChanged);
            // 
            // favouriteCheckBox
            // 
            this.favouriteCheckBox.AutoSize = true;
            this.favouriteCheckBox.Location = new System.Drawing.Point(531, 332);
            this.favouriteCheckBox.Name = "favouriteCheckBox";
            this.favouriteCheckBox.Size = new System.Drawing.Size(65, 17);
            this.favouriteCheckBox.TabIndex = 27;
            this.favouriteCheckBox.Text = "Preferito";
            this.favouriteCheckBox.UseVisualStyleBackColor = true;
            this.favouriteCheckBox.CheckedChanged += new System.EventHandler(this.favouriteCheckBox_CheckedChanged);
            // 
            // AddRecipeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 379);
            this.Controls.Add(this.favouriteCheckBox);
            this.Controls.Add(this.dinnerCheckBox);
            this.Controls.Add(this.lunchCheckBox);
            this.Controls.Add(this.breakfastCheckBox);
            this.Controls.Add(this.recipeStepsGroup);
            this.Controls.Add(this.recipeIngredientsGroup);
            this.Controls.Add(this.addNewRecipeButton);
            this.Controls.Add(this.recipeNameTextBox);
            this.Controls.Add(this.recipeNameLabel);
            this.Name = "AddRecipeWindow";
            this.Text = "Aggiungi una ricetta";
            this.Load += new System.EventHandler(this.AddRecipeWindow_Load);
            this.recipeIngredientsGroup.ResumeLayout(false);
            this.recipeStepsGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recipeNameLabel;
        private System.Windows.Forms.TextBox recipeNameTextBox;
        private System.Windows.Forms.Button addNewRecipeButton;
        private System.Windows.Forms.GroupBox recipeIngredientsGroup;
        private System.Windows.Forms.Button addRecipeIngredientButton;
        private System.Windows.Forms.GroupBox recipeStepsGroup;
        private System.Windows.Forms.Button addRecipeStepButton;
        private System.Windows.Forms.CheckBox breakfastCheckBox;
        private System.Windows.Forms.CheckBox lunchCheckBox;
        private System.Windows.Forms.CheckBox dinnerCheckBox;
        internal System.Windows.Forms.ListBox recipeIngredientsListBox;
        internal System.Windows.Forms.ListBox recipeStepsListBox;
        private System.Windows.Forms.CheckBox favouriteCheckBox;
    }
}