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
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(66, 101);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(53, 140);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(52, 13);
            this.SurnameLabel.TabIndex = 1;
            this.SurnameLabel.Text = "Surname:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(66, 181);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = "Email:";
            // 
            // BirthLabel
            // 
            this.BirthLabel.AutoSize = true;
            this.BirthLabel.Location = new System.Drawing.Point(33, 221);
            this.BirthLabel.Name = "BirthLabel";
            this.BirthLabel.Size = new System.Drawing.Size(71, 13);
            this.BirthLabel.TabIndex = 3;
            this.BirthLabel.Text = "Date Of Birth:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(113, 98);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(113, 137);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.surnameTextBox.TabIndex = 5;
            this.surnameTextBox.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(113, 178);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(100, 20);
            this.emailTextBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Take photo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dateTimeBox
            // 
            this.dateTimeBox.Location = new System.Drawing.Point(113, 215);
            this.dateTimeBox.Name = "dateTimeBox";
            this.dateTimeBox.Size = new System.Drawing.Size(196, 20);
            this.dateTimeBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "New User Registration";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(234, 324);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 10;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Repeat password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(113, 249);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 13;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // repeatPasswTextBox
            // 
            this.repeatPasswTextBox.Location = new System.Drawing.Point(113, 289);
            this.repeatPasswTextBox.Name = "repeatPasswTextBox";
            this.repeatPasswTextBox.PasswordChar = '*';
            this.repeatPasswTextBox.Size = new System.Drawing.Size(100, 20);
            this.repeatPasswTextBox.TabIndex = 14;
            this.repeatPasswTextBox.TextChanged += new System.EventHandler(this.RepeatPasswTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Username:";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(113, 57);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.UserNameTextBox.TabIndex = 16;
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 372);
            this.Controls.Add(this.UserNameTextBox);
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
            this.Name = "Registration";
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
        private System.Windows.Forms.TextBox UserNameTextBox;
    }
}

