namespace getfit_clientGUI
{
    partial class SignUpWindow
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
            this.passwordSignUpTextBox = new System.Windows.Forms.TextBox();
            this.signUpEmailTextBox = new System.Windows.Forms.TextBox();
            this.passwordWelcomeLabel = new System.Windows.Forms.Label();
            this.emailWelcomeLabel = new System.Windows.Forms.Label();
            this.subscribeButton = new System.Windows.Forms.Button();
            this.passConfirmSignUpTextBox = new System.Windows.Forms.TextBox();
            this.subscribeWindow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passwordSignUpTextBox
            // 
            this.passwordSignUpTextBox.Location = new System.Drawing.Point(145, 100);
            this.passwordSignUpTextBox.MaxLength = 50;
            this.passwordSignUpTextBox.Name = "passwordSignUpTextBox";
            this.passwordSignUpTextBox.PasswordChar = '*';
            this.passwordSignUpTextBox.Size = new System.Drawing.Size(213, 20);
            this.passwordSignUpTextBox.TabIndex = 11;
            // 
            // signUpEmailTextBox
            // 
            this.signUpEmailTextBox.Location = new System.Drawing.Point(145, 40);
            this.signUpEmailTextBox.MaxLength = 50;
            this.signUpEmailTextBox.Name = "signUpEmailTextBox";
            this.signUpEmailTextBox.Size = new System.Drawing.Size(213, 20);
            this.signUpEmailTextBox.TabIndex = 10;
            // 
            // passwordWelcomeLabel
            // 
            this.passwordWelcomeLabel.AutoSize = true;
            this.passwordWelcomeLabel.Location = new System.Drawing.Point(30, 103);
            this.passwordWelcomeLabel.Name = "passwordWelcomeLabel";
            this.passwordWelcomeLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordWelcomeLabel.TabIndex = 9;
            this.passwordWelcomeLabel.Text = "Password:";
            // 
            // emailWelcomeLabel
            // 
            this.emailWelcomeLabel.AutoSize = true;
            this.emailWelcomeLabel.Location = new System.Drawing.Point(30, 43);
            this.emailWelcomeLabel.Name = "emailWelcomeLabel";
            this.emailWelcomeLabel.Size = new System.Drawing.Size(35, 13);
            this.emailWelcomeLabel.TabIndex = 8;
            this.emailWelcomeLabel.Text = "Email:";
            // 
            // subscribeButton
            // 
            this.subscribeButton.Location = new System.Drawing.Point(170, 229);
            this.subscribeButton.Name = "subscribeButton";
            this.subscribeButton.Size = new System.Drawing.Size(75, 23);
            this.subscribeButton.TabIndex = 7;
            this.subscribeButton.Text = "Iscriviti";
            this.subscribeButton.UseVisualStyleBackColor = true;
            this.subscribeButton.Click += new System.EventHandler(this.subscribeButton_Click);
            // 
            // passConfirmSignUpTextBox
            // 
            this.passConfirmSignUpTextBox.Location = new System.Drawing.Point(145, 162);
            this.passConfirmSignUpTextBox.MaxLength = 50;
            this.passConfirmSignUpTextBox.Name = "passConfirmSignUpTextBox";
            this.passConfirmSignUpTextBox.PasswordChar = '*';
            this.passConfirmSignUpTextBox.Size = new System.Drawing.Size(213, 20);
            this.passConfirmSignUpTextBox.TabIndex = 12;
            // 
            // subscribeWindow
            // 
            this.subscribeWindow.AutoSize = true;
            this.subscribeWindow.Location = new System.Drawing.Point(30, 165);
            this.subscribeWindow.Name = "subscribeWindow";
            this.subscribeWindow.Size = new System.Drawing.Size(103, 13);
            this.subscribeWindow.TabIndex = 13;
            this.subscribeWindow.Text = "Conferma password:";
            // 
            // SignUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 291);
            this.Controls.Add(this.subscribeWindow);
            this.Controls.Add(this.passConfirmSignUpTextBox);
            this.Controls.Add(this.passwordSignUpTextBox);
            this.Controls.Add(this.signUpEmailTextBox);
            this.Controls.Add(this.passwordWelcomeLabel);
            this.Controls.Add(this.emailWelcomeLabel);
            this.Controls.Add(this.subscribeButton);
            this.Name = "SignUpWindow";
            this.Text = "Iscriviti!";
            this.Load += new System.EventHandler(this.SignUpWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordSignUpTextBox;
        private System.Windows.Forms.TextBox signUpEmailTextBox;
        private System.Windows.Forms.Label passwordWelcomeLabel;
        private System.Windows.Forms.Label emailWelcomeLabel;
        private System.Windows.Forms.Button subscribeButton;
        private System.Windows.Forms.TextBox passConfirmSignUpTextBox;
        private System.Windows.Forms.Label subscribeWindow;
    }
}