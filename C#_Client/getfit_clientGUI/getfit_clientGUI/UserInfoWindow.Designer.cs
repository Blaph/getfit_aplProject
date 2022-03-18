namespace getfit_clientGUI
{
    partial class UserInfoWindow
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
            this.sexLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.trainingIntensityLabel = new System.Windows.Forms.Label();
            this.sexComboBox = new System.Windows.Forms.ComboBox();
            this.intensitySignUpComboBox = new System.Windows.Forms.ComboBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.heightSignUpUpDown = new System.Windows.Forms.NumericUpDown();
            this.weightSignUpUpDown = new System.Windows.Forms.NumericUpDown();
            this.ageSignUpUpDown = new System.Windows.Forms.NumericUpDown();
            this.ageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.heightSignUpUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightSignUpUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageSignUpUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(42, 101);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(68, 13);
            this.sexLabel.TabIndex = 0;
            this.sexLabel.Text = "Sesso (M/F):";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(45, 159);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(67, 13);
            this.heightLabel.TabIndex = 1;
            this.heightLabel.Text = "Altezza (cm):";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(45, 216);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(55, 13);
            this.weightLabel.TabIndex = 2;
            this.weightLabel.Text = "Peso (kg):";
            // 
            // trainingIntensityLabel
            // 
            this.trainingIntensityLabel.AutoSize = true;
            this.trainingIntensityLabel.Location = new System.Drawing.Point(45, 275);
            this.trainingIntensityLabel.Name = "trainingIntensityLabel";
            this.trainingIntensityLabel.Size = new System.Drawing.Size(50, 13);
            this.trainingIntensityLabel.TabIndex = 3;
            this.trainingIntensityLabel.Text = "Intensità:";
            // 
            // sexComboBox
            // 
            this.sexComboBox.FormattingEnabled = true;
            this.sexComboBox.Items.AddRange(new object[] {
            "M",
            "F"});
            this.sexComboBox.Location = new System.Drawing.Point(116, 98);
            this.sexComboBox.MaxDropDownItems = 2;
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(33, 21);
            this.sexComboBox.TabIndex = 5;
            this.sexComboBox.SelectedIndexChanged += new System.EventHandler(this.sexComboBox_SelectedIndexChanged);
            // 
            // intensitySignUpComboBox
            // 
            this.intensitySignUpComboBox.FormattingEnabled = true;
            this.intensitySignUpComboBox.Items.AddRange(new object[] {
            "Nulla (Sedentario)",
            "Bassa (2 ore a settimana)",
            "Moderata (da 3 a 5 ore a settimana)",
            "Alta (più di 5 ore a settimana)"});
            this.intensitySignUpComboBox.Location = new System.Drawing.Point(116, 272);
            this.intensitySignUpComboBox.MaxDropDownItems = 4;
            this.intensitySignUpComboBox.Name = "intensitySignUpComboBox";
            this.intensitySignUpComboBox.Size = new System.Drawing.Size(195, 21);
            this.intensitySignUpComboBox.TabIndex = 6;
            this.intensitySignUpComboBox.SelectedIndexChanged += new System.EventHandler(this.intensitySignUpComboBox_SelectedIndexChanged);
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(153, 334);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(75, 23);
            this.signUpButton.TabIndex = 7;
            this.signUpButton.Text = "Iscriviti";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // heightSignUpUpDown
            // 
            this.heightSignUpUpDown.DecimalPlaces = 1;
            this.heightSignUpUpDown.Location = new System.Drawing.Point(116, 157);
            this.heightSignUpUpDown.Maximum = new decimal(new int[] {
            230,
            0,
            0,
            0});
            this.heightSignUpUpDown.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.heightSignUpUpDown.Name = "heightSignUpUpDown";
            this.heightSignUpUpDown.Size = new System.Drawing.Size(48, 20);
            this.heightSignUpUpDown.TabIndex = 8;
            this.heightSignUpUpDown.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.heightSignUpUpDown.ValueChanged += new System.EventHandler(this.heightSignUpUpDown_ValueChanged);
            // 
            // weightSignUpUpDown
            // 
            this.weightSignUpUpDown.DecimalPlaces = 1;
            this.weightSignUpUpDown.Location = new System.Drawing.Point(116, 214);
            this.weightSignUpUpDown.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.weightSignUpUpDown.Minimum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.weightSignUpUpDown.Name = "weightSignUpUpDown";
            this.weightSignUpUpDown.Size = new System.Drawing.Size(48, 20);
            this.weightSignUpUpDown.TabIndex = 9;
            this.weightSignUpUpDown.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.weightSignUpUpDown.ValueChanged += new System.EventHandler(this.weightSignUpUpDown_ValueChanged);
            // 
            // ageSignUpUpDown
            // 
            this.ageSignUpUpDown.Location = new System.Drawing.Point(113, 41);
            this.ageSignUpUpDown.Maximum = new decimal(new int[] {
            130,
            0,
            0,
            0});
            this.ageSignUpUpDown.Name = "ageSignUpUpDown";
            this.ageSignUpUpDown.Size = new System.Drawing.Size(48, 20);
            this.ageSignUpUpDown.TabIndex = 11;
            this.ageSignUpUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.ageSignUpUpDown.ValueChanged += new System.EventHandler(this.ageSignUpUpDown_ValueChanged);
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(42, 43);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(26, 13);
            this.ageLabel.TabIndex = 10;
            this.ageLabel.Text = "Età:";
            // 
            // UserInfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 395);
            this.Controls.Add(this.ageSignUpUpDown);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.weightSignUpUpDown);
            this.Controls.Add(this.heightSignUpUpDown);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.intensitySignUpComboBox);
            this.Controls.Add(this.sexComboBox);
            this.Controls.Add(this.trainingIntensityLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.sexLabel);
            this.Name = "UserInfoWindow";
            this.Text = "Iscriviti!";
            this.Load += new System.EventHandler(this.UserInfoWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.heightSignUpUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightSignUpUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageSignUpUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label trainingIntensityLabel;
        private System.Windows.Forms.ComboBox sexComboBox;
        private System.Windows.Forms.ComboBox intensitySignUpComboBox;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.NumericUpDown heightSignUpUpDown;
        private System.Windows.Forms.NumericUpDown weightSignUpUpDown;
        private System.Windows.Forms.NumericUpDown ageSignUpUpDown;
        private System.Windows.Forms.Label ageLabel;
    }
}