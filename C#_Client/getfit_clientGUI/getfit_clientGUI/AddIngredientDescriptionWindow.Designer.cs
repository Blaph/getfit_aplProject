namespace getfit_clientGUI
{
    partial class AddIngredientDescriptionWindow
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
            this.kcalUpDown = new System.Windows.Forms.NumericUpDown();
            this.ingredientNameLabel = new System.Windows.Forms.Label();
            this.proteinsUpDown = new System.Windows.Forms.NumericUpDown();
            this.carbsUpDown = new System.Windows.Forms.NumericUpDown();
            this.addNewIngredientButton = new System.Windows.Forms.Button();
            this.fatsLabel = new System.Windows.Forms.Label();
            this.proteinsLabel = new System.Windows.Forms.Label();
            this.carbsLabel = new System.Windows.Forms.Label();
            this.kcalLabel = new System.Windows.Forms.Label();
            this.ingredientNameTextBox = new System.Windows.Forms.TextBox();
            this.fatsUpDown = new System.Windows.Forms.NumericUpDown();
            this.favouriteCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kcalUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proteinsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carbsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fatsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // kcalUpDown
            // 
            this.kcalUpDown.Location = new System.Drawing.Point(110, 94);
            this.kcalUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.kcalUpDown.Name = "kcalUpDown";
            this.kcalUpDown.Size = new System.Drawing.Size(48, 20);
            this.kcalUpDown.TabIndex = 22;
            this.kcalUpDown.ValueChanged += new System.EventHandler(this.kcalUpDown_ValueChanged);
            // 
            // ingredientNameLabel
            // 
            this.ingredientNameLabel.AutoSize = true;
            this.ingredientNameLabel.Location = new System.Drawing.Point(36, 38);
            this.ingredientNameLabel.Name = "ingredientNameLabel";
            this.ingredientNameLabel.Size = new System.Drawing.Size(38, 13);
            this.ingredientNameLabel.TabIndex = 21;
            this.ingredientNameLabel.Text = "Nome:";
            // 
            // proteinsUpDown
            // 
            this.proteinsUpDown.DecimalPlaces = 1;
            this.proteinsUpDown.Location = new System.Drawing.Point(110, 150);
            this.proteinsUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.proteinsUpDown.Name = "proteinsUpDown";
            this.proteinsUpDown.Size = new System.Drawing.Size(48, 20);
            this.proteinsUpDown.TabIndex = 20;
            this.proteinsUpDown.ValueChanged += new System.EventHandler(this.proteinsUpDown_ValueChanged);
            // 
            // carbsUpDown
            // 
            this.carbsUpDown.DecimalPlaces = 1;
            this.carbsUpDown.Location = new System.Drawing.Point(267, 94);
            this.carbsUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.carbsUpDown.Name = "carbsUpDown";
            this.carbsUpDown.Size = new System.Drawing.Size(48, 20);
            this.carbsUpDown.TabIndex = 19;
            this.carbsUpDown.ValueChanged += new System.EventHandler(this.carbsUpDown_ValueChanged);
            // 
            // addNewIngredientButton
            // 
            this.addNewIngredientButton.Location = new System.Drawing.Point(206, 196);
            this.addNewIngredientButton.Name = "addNewIngredientButton";
            this.addNewIngredientButton.Size = new System.Drawing.Size(109, 23);
            this.addNewIngredientButton.TabIndex = 18;
            this.addNewIngredientButton.Text = "Aggiungi alimento";
            this.addNewIngredientButton.UseVisualStyleBackColor = true;
            this.addNewIngredientButton.Click += new System.EventHandler(this.addNewIngredientButton_Click);
            // 
            // fatsLabel
            // 
            this.fatsLabel.AutoSize = true;
            this.fatsLabel.Location = new System.Drawing.Point(196, 152);
            this.fatsLabel.Name = "fatsLabel";
            this.fatsLabel.Size = new System.Drawing.Size(39, 13);
            this.fatsLabel.TabIndex = 15;
            this.fatsLabel.Text = "Grassi:";
            // 
            // proteinsLabel
            // 
            this.proteinsLabel.AutoSize = true;
            this.proteinsLabel.Location = new System.Drawing.Point(39, 152);
            this.proteinsLabel.Name = "proteinsLabel";
            this.proteinsLabel.Size = new System.Drawing.Size(49, 13);
            this.proteinsLabel.TabIndex = 14;
            this.proteinsLabel.Text = "Proteine:";
            // 
            // carbsLabel
            // 
            this.carbsLabel.AutoSize = true;
            this.carbsLabel.Location = new System.Drawing.Point(196, 96);
            this.carbsLabel.Name = "carbsLabel";
            this.carbsLabel.Size = new System.Drawing.Size(60, 13);
            this.carbsLabel.TabIndex = 13;
            this.carbsLabel.Text = "Carboidrati:";
            // 
            // kcalLabel
            // 
            this.kcalLabel.AutoSize = true;
            this.kcalLabel.Location = new System.Drawing.Point(36, 96);
            this.kcalLabel.Name = "kcalLabel";
            this.kcalLabel.Size = new System.Drawing.Size(31, 13);
            this.kcalLabel.TabIndex = 12;
            this.kcalLabel.Text = "Kcal:";
            // 
            // ingredientNameTextBox
            // 
            this.ingredientNameTextBox.Location = new System.Drawing.Point(110, 35);
            this.ingredientNameTextBox.Name = "ingredientNameTextBox";
            this.ingredientNameTextBox.Size = new System.Drawing.Size(205, 20);
            this.ingredientNameTextBox.TabIndex = 23;
            // 
            // fatsUpDown
            // 
            this.fatsUpDown.DecimalPlaces = 1;
            this.fatsUpDown.Location = new System.Drawing.Point(267, 150);
            this.fatsUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.fatsUpDown.Name = "fatsUpDown";
            this.fatsUpDown.Size = new System.Drawing.Size(48, 20);
            this.fatsUpDown.TabIndex = 24;
            this.fatsUpDown.ValueChanged += new System.EventHandler(this.fatsUpDown_ValueChanged);
            // 
            // favouriteCheckBox
            // 
            this.favouriteCheckBox.AutoSize = true;
            this.favouriteCheckBox.Location = new System.Drawing.Point(59, 202);
            this.favouriteCheckBox.Name = "favouriteCheckBox";
            this.favouriteCheckBox.Size = new System.Drawing.Size(65, 17);
            this.favouriteCheckBox.TabIndex = 26;
            this.favouriteCheckBox.Text = "Preferito";
            this.favouriteCheckBox.UseVisualStyleBackColor = true;
            this.favouriteCheckBox.CheckedChanged += new System.EventHandler(this.favouriteCheckBox_CheckedChanged);
            // 
            // AddIngredientDescriptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 253);
            this.Controls.Add(this.favouriteCheckBox);
            this.Controls.Add(this.fatsUpDown);
            this.Controls.Add(this.ingredientNameTextBox);
            this.Controls.Add(this.kcalUpDown);
            this.Controls.Add(this.ingredientNameLabel);
            this.Controls.Add(this.proteinsUpDown);
            this.Controls.Add(this.carbsUpDown);
            this.Controls.Add(this.addNewIngredientButton);
            this.Controls.Add(this.fatsLabel);
            this.Controls.Add(this.proteinsLabel);
            this.Controls.Add(this.carbsLabel);
            this.Controls.Add(this.kcalLabel);
            this.Name = "AddIngredientDescriptionWindow";
            this.Text = "Aggiungi un nuovo ingrediente";
            this.Load += new System.EventHandler(this.AddIngredientDescriptionWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kcalUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proteinsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carbsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fatsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown kcalUpDown;
        private System.Windows.Forms.Label ingredientNameLabel;
        private System.Windows.Forms.NumericUpDown proteinsUpDown;
        private System.Windows.Forms.NumericUpDown carbsUpDown;
        private System.Windows.Forms.Button addNewIngredientButton;
        private System.Windows.Forms.Label fatsLabel;
        private System.Windows.Forms.Label proteinsLabel;
        private System.Windows.Forms.Label carbsLabel;
        private System.Windows.Forms.Label kcalLabel;
        private System.Windows.Forms.TextBox ingredientNameTextBox;
        private System.Windows.Forms.NumericUpDown fatsUpDown;
        private System.Windows.Forms.CheckBox favouriteCheckBox;
    }
}