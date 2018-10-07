using VirtualLibrary.Localization;

namespace VirtualLibrary
{
    partial class Registration
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.BirthLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimeBox = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.repeatPasswTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(88, 124);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(49, 17);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = Translations.GetTranslatedString("nameLabel");
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(71, 172);
            this.SurnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(69, 17);
            this.SurnameLabel.TabIndex = 1;
            this.SurnameLabel.Text = Translations.GetTranslatedString("surnameLabel");
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(88, 223);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(46, 17);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = Translations.GetTranslatedString("emailLabel");
            // 
            // BirthLabel
            // 
            this.BirthLabel.AutoSize = true;
            this.BirthLabel.Location = new System.Drawing.Point(44, 272);
            this.BirthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BirthLabel.Name = "BirthLabel";
            this.BirthLabel.Size = new System.Drawing.Size(94, 17);
            this.BirthLabel.TabIndex = 3;
            this.BirthLabel.Text = Translations.GetTranslatedString("birthLabel");
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(151, 121);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(132, 22);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(151, 169);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(132, 22);
            this.surnameTextBox.TabIndex = 5;
            this.surnameTextBox.TextChanged += new System.EventHandler(this.SurnameTextBox_TextChanged);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(151, 219);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(132, 22);
            this.emailTextBox.TabIndex = 6;
            this.emailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(561, 124);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = Translations.GetTranslatedString("takePhoto");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dateTimeBox
            // 
            this.dateTimeBox.Location = new System.Drawing.Point(151, 265);
            this.dateTimeBox.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeBox.MaxDate = new System.DateTime(2018, 10, 5, 22, 41, 43, 0);
            this.dateTimeBox.Name = "dateTimeBox";
            this.dateTimeBox.Size = new System.Drawing.Size(260, 22);
            this.dateTimeBox.TabIndex = 8;
            this.dateTimeBox.Value = new System.DateTime(2018, 10, 5, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = Translations.GetTranslatedString("newUser");
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(312, 399);
            this.registerButton.Margin = new System.Windows.Forms.Padding(4);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 28);
            this.registerButton.TabIndex = 10;
            this.registerButton.Text = Translations.GetTranslatedString("registerButton");
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 315);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = Translations.GetTranslatedString("password");
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = Translations.GetTranslatedString("repeatPassword");
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(151, 306);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(132, 22);
            this.passwordTextBox.TabIndex = 13;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // repeatPasswTextBox
            // 
            this.repeatPasswTextBox.Location = new System.Drawing.Point(151, 356);
            this.repeatPasswTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.repeatPasswTextBox.Name = "repeatPasswTextBox";
            this.repeatPasswTextBox.PasswordChar = '*';
            this.repeatPasswTextBox.Size = new System.Drawing.Size(132, 22);
            this.repeatPasswTextBox.TabIndex = 14;
            this.repeatPasswTextBox.TextChanged += new System.EventHandler(this.RepeatPasswTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = Translations.GetTranslatedString("username");
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(151, 70);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(132, 22);
            this.usernameTextBox.TabIndex = 16;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 29);
            this.button2.TabIndex = 17;
            this.button2.Text = "EN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(578, 370);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 29);
            this.button3.TabIndex = 18;
            this.button3.Text = "LT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = Translations.GetTranslatedString("chooseLanguage");
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 458);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.repeatPasswTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.BirthLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.SurnameLabel);
            this.Controls.Add(this.NameLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = Translations.GetTranslatedString("registrationButton");
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label BirthLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox repeatPasswTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
    }
}

