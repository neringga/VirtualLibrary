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
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of books in library:";
            // 
            // bookListBox
            // 
            this.bookListBox.FormattingEnabled = true;
            this.bookListBox.Location = new System.Drawing.Point(12, 54);
            this.bookListBox.Name = "bookListBox";
            this.bookListBox.Size = new System.Drawing.Size(319, 212);
            this.bookListBox.TabIndex = 2;
            this.bookListBox.SelectedIndexChanged += new System.EventHandler(this.BookListBox_SelectedIndexChanged);
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 307);
            this.Controls.Add(this.bookListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScannerOpenButton);
            this.Name = "Library";
            this.Text = "Library";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScannerOpenButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox bookListBox;
    }
}