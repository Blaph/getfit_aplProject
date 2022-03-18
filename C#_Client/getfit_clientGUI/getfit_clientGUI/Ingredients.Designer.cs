namespace getfit_clientGUI
{
    partial class Ingredients
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
            this.ingredientsListBox = new System.Windows.Forms.ListBox();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.gQuantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.gQuantityLabel = new System.Windows.Forms.Label();
            this.addRecipeIngredientButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gQuantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ingredientsListBox
            // 
            this.ingredientsListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ingredientsListBox.FormattingEnabled = true;
            this.ingredientsListBox.HorizontalScrollbar = true;
            this.ingredientsListBox.Location = new System.Drawing.Point(0, 0);
            this.ingredientsListBox.Name = "ingredientsListBox";
            this.ingredientsListBox.Size = new System.Drawing.Size(374, 355);
            this.ingredientsListBox.TabIndex = 0;
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(243, 368);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(119, 23);
            this.addIngredientButton.TabIndex = 1;
            this.addIngredientButton.Text = "Aggiungi alimento";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // gQuantityUpDown
            // 
            this.gQuantityUpDown.Enabled = false;
            this.gQuantityUpDown.Location = new System.Drawing.Point(83, 371);
            this.gQuantityUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.gQuantityUpDown.Name = "gQuantityUpDown";
            this.gQuantityUpDown.Size = new System.Drawing.Size(36, 20);
            this.gQuantityUpDown.TabIndex = 2;
            this.gQuantityUpDown.Visible = false;
            // 
            // gQuantityLabel
            // 
            this.gQuantityLabel.AutoSize = true;
            this.gQuantityLabel.Location = new System.Drawing.Point(12, 373);
            this.gQuantityLabel.Name = "gQuantityLabel";
            this.gQuantityLabel.Size = new System.Drawing.Size(65, 13);
            this.gQuantityLabel.TabIndex = 3;
            this.gQuantityLabel.Text = "Quantità (g):";
            this.gQuantityLabel.Visible = false;
            // 
            // addRecipeIngredientButton
            // 
            this.addRecipeIngredientButton.Enabled = false;
            this.addRecipeIngredientButton.Location = new System.Drawing.Point(129, 368);
            this.addRecipeIngredientButton.Name = "addRecipeIngredientButton";
            this.addRecipeIngredientButton.Size = new System.Drawing.Size(108, 23);
            this.addRecipeIngredientButton.TabIndex = 4;
            this.addRecipeIngredientButton.Text = "Aggiungi alla ricetta";
            this.addRecipeIngredientButton.UseVisualStyleBackColor = true;
            this.addRecipeIngredientButton.Visible = false;
            this.addRecipeIngredientButton.Click += new System.EventHandler(this.addRecipeIngredientButton_Click);
            // 
            // Ingredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 407);
            this.Controls.Add(this.addRecipeIngredientButton);
            this.Controls.Add(this.gQuantityLabel);
            this.Controls.Add(this.gQuantityUpDown);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.ingredientsListBox);
            this.Name = "Ingredients";
            this.Text = "Alimenti";
            this.Load += new System.EventHandler(this.Ingredients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gQuantityUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ingredientsListBox;
        private System.Windows.Forms.Button addIngredientButton;
        private System.Windows.Forms.NumericUpDown gQuantityUpDown;
        private System.Windows.Forms.Label gQuantityLabel;
        private System.Windows.Forms.Button addRecipeIngredientButton;
    }
}