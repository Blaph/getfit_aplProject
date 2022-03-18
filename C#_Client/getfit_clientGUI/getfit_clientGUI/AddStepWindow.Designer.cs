namespace getfit_clientGUI
{
    partial class AddStepWindow
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
            this.recipeStepTextBox = new System.Windows.Forms.TextBox();
            this.recipeStepLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addRecipeStepButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recipeStepTextBox
            // 
            this.recipeStepTextBox.Location = new System.Drawing.Point(48, 3);
            this.recipeStepTextBox.Name = "recipeStepTextBox";
            this.recipeStepTextBox.Size = new System.Drawing.Size(498, 20);
            this.recipeStepTextBox.TabIndex = 0;
            // 
            // recipeStepLabel
            // 
            this.recipeStepLabel.AutoSize = true;
            this.recipeStepLabel.Location = new System.Drawing.Point(3, 0);
            this.recipeStepLabel.Name = "recipeStepLabel";
            this.recipeStepLabel.Size = new System.Drawing.Size(39, 13);
            this.recipeStepLabel.TabIndex = 1;
            this.recipeStepLabel.Text = "Passo:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.recipeStepLabel);
            this.flowLayoutPanel1.Controls.Add(this.recipeStepTextBox);
            this.flowLayoutPanel1.Controls.Add(this.addRecipeStepButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(690, 47);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // addRecipeStepButton
            // 
            this.addRecipeStepButton.Location = new System.Drawing.Point(552, 3);
            this.addRecipeStepButton.Name = "addRecipeStepButton";
            this.addRecipeStepButton.Size = new System.Drawing.Size(122, 23);
            this.addRecipeStepButton.TabIndex = 2;
            this.addRecipeStepButton.Text = "Aggiungi passo";
            this.addRecipeStepButton.UseVisualStyleBackColor = true;
            this.addRecipeStepButton.Click += new System.EventHandler(this.addRecipeStepButton_Click);
            // 
            // AddStepWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 47);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AddStepWindow";
            this.Text = "AddStepWindow";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox recipeStepTextBox;
        private System.Windows.Forms.Label recipeStepLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addRecipeStepButton;
    }
}