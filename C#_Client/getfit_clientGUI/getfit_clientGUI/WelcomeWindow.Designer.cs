namespace getfit_clientGUI
{
    partial class WelcomeWindow
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.logInButton = new System.Windows.Forms.Button();
            this.subscribeButton = new System.Windows.Forms.Button();
            this.emailWelcomeLabel = new System.Windows.Forms.Label();
            this.passwordWelcomeLabel = new System.Windows.Forms.Label();
            this.emailWelcomeTextBox = new System.Windows.Forms.TextBox();
            this.passwordWelcomeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(98, 166);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(75, 23);
            this.logInButton.TabIndex = 0;
            this.logInButton.Text = "Accedi";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // subscribeButton
            // 
            this.subscribeButton.Location = new System.Drawing.Point(215, 166);
            this.subscribeButton.Name = "subscribeButton";
            this.subscribeButton.Size = new System.Drawing.Size(75, 23);
            this.subscribeButton.TabIndex = 1;
            this.subscribeButton.Text = "Iscriviti";
            this.subscribeButton.UseVisualStyleBackColor = true;
            this.subscribeButton.Click += new System.EventHandler(this.subscribeButton_Click);
            // 
            // emailWelcomeLabel
            // 
            this.emailWelcomeLabel.AutoSize = true;
            this.emailWelcomeLabel.Location = new System.Drawing.Point(38, 46);
            this.emailWelcomeLabel.Name = "emailWelcomeLabel";
            this.emailWelcomeLabel.Size = new System.Drawing.Size(35, 13);
            this.emailWelcomeLabel.TabIndex = 2;
            this.emailWelcomeLabel.Text = "Email:";
            // 
            // passwordWelcomeLabel
            // 
            this.passwordWelcomeLabel.AutoSize = true;
            this.passwordWelcomeLabel.Location = new System.Drawing.Point(38, 106);
            this.passwordWelcomeLabel.Name = "passwordWelcomeLabel";
            this.passwordWelcomeLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordWelcomeLabel.TabIndex = 3;
            this.passwordWelcomeLabel.Text = "Password:";
            // 
            // emailWelcomeTextBox
            // 
            this.emailWelcomeTextBox.Location = new System.Drawing.Point(98, 43);
            this.emailWelcomeTextBox.MaxLength = 50;
            this.emailWelcomeTextBox.Name = "emailWelcomeTextBox";
            this.emailWelcomeTextBox.Size = new System.Drawing.Size(213, 20);
            this.emailWelcomeTextBox.TabIndex = 4;
            this.emailWelcomeTextBox.TextChanged += new System.EventHandler(this.emailWelcomeTextBox_TextChanged);
            // 
            // passwordWelcomeTextBox
            // 
            this.passwordWelcomeTextBox.Location = new System.Drawing.Point(98, 103);
            this.passwordWelcomeTextBox.MaxLength = 50;
            this.passwordWelcomeTextBox.Name = "passwordWelcomeTextBox";
            this.passwordWelcomeTextBox.PasswordChar = '*';
            this.passwordWelcomeTextBox.Size = new System.Drawing.Size(213, 20);
            this.passwordWelcomeTextBox.TabIndex = 5;
            // 
            // WelcomeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 227);
            this.Controls.Add(this.passwordWelcomeTextBox);
            this.Controls.Add(this.emailWelcomeTextBox);
            this.Controls.Add(this.passwordWelcomeLabel);
            this.Controls.Add(this.emailWelcomeLabel);
            this.Controls.Add(this.subscribeButton);
            this.Controls.Add(this.logInButton);
            this.Name = "WelcomeWindow";
            this.Text = "Welcome to GetFit!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Button subscribeButton;
        private System.Windows.Forms.Label emailWelcomeLabel;
        private System.Windows.Forms.Label passwordWelcomeLabel;
        private System.Windows.Forms.TextBox emailWelcomeTextBox;
        private System.Windows.Forms.TextBox passwordWelcomeTextBox;
    }
}

