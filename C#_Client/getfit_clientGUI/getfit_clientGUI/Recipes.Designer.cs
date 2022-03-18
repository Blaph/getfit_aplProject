namespace getfit_clientGUI
{
    partial class Recipes
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
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.recipesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.Location = new System.Drawing.Point(169, 365);
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Size = new System.Drawing.Size(119, 23);
            this.addRecipeButton.TabIndex = 3;
            this.addRecipeButton.Text = "Aggiungi ricetta";
            this.addRecipeButton.UseVisualStyleBackColor = true;
            this.addRecipeButton.Click += new System.EventHandler(this.addRecipeButton_Click);
            // 
            // recipesListBox
            // 
            this.recipesListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.recipesListBox.FormattingEnabled = true;
            this.recipesListBox.HorizontalScrollbar = true;
            this.recipesListBox.Location = new System.Drawing.Point(0, 0);
            this.recipesListBox.Name = "recipesListBox";
            this.recipesListBox.Size = new System.Drawing.Size(460, 355);
            this.recipesListBox.TabIndex = 2;
            // 
            // Recipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 400);
            this.Controls.Add(this.addRecipeButton);
            this.Controls.Add(this.recipesListBox);
            this.Name = "Recipes";
            this.Text = "Ricette";
            this.Load += new System.EventHandler(this.Recipes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addRecipeButton;
        private System.Windows.Forms.ListBox recipesListBox;
    }
}