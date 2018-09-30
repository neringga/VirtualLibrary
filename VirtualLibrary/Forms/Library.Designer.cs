namespace VirtualLibrary.Forms
{
    partial class Library
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
            this.ScannerOpenButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bookListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScannerOpenButton
            // 
            this.ScannerOpenButton.Location = new System.Drawing.Point(425, 260);
            this.ScannerOpenButton.Name = "ScannerOpenButton";
            this.ScannerOpenButton.Size = new System.Drawing.Size(138, 23);
            this.ScannerOpenButton.TabIndex = 0;
            this.ScannerOpenButton.Text = "Scan book";
            this.ScannerOpenButton.UseVisualStyleBackColor = true;
            this.ScannerOpenButton.Click += new System.EventHandler(this.ScannerOpenButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of books in library:";
            // 
            // bookListBox
            // 
            this.bookListBox.FormattingEnabled = true;
            this.bookListBox.ItemHeight = 16;
            this.bookListBox.Location = new System.Drawing.Point(16, 66);
            this.bookListBox.Margin = new System.Windows.Forms.Padding(4);
            this.bookListBox.Name = "bookListBox";
            this.bookListBox.Size = new System.Drawing.Size(374, 228);
            this.bookListBox.TabIndex = 2;
            this.bookListBox.SelectedIndexChanged += new System.EventHandler(this.BookListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 309);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "For taking or returning book:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "List of taken books:";
            // 
            // takenBookListBox
            // 
            this.takenBookListBox.FormattingEnabled = true;
            this.takenBookListBox.ItemHeight = 16;
            this.takenBookListBox.Items.AddRange(new object[] {
            "as"});
            this.takenBookListBox.Location = new System.Drawing.Point(409, 66);
            this.takenBookListBox.Name = "takenBookListBox";
            this.takenBookListBox.Size = new System.Drawing.Size(344, 228);
            this.takenBookListBox.TabIndex = 5;
            this.takenBookListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 378);
            this.Controls.Add(this.takenBookListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bookListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScannerOpenButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Library";
            this.Text = "Library";
            this.Load += new System.EventHandler(this.Library_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScannerOpenButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox bookListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox takenBookListBox;
    }
}