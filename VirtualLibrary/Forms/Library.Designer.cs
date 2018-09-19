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
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 307);
            this.Controls.Add(this.ScannerOpenButton);
            this.Name = "Library";
            this.Text = "Library";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ScannerOpenButton;
    }
}