namespace VirtualLibrary.Forms
{
    partial class BarcodeScanner
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
            this.barcodePictureBox = new System.Windows.Forms.PictureBox();
            this.pictureUploadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // barcodePictureBox
            // 
            this.barcodePictureBox.Location = new System.Drawing.Point(37, 29);
            this.barcodePictureBox.Name = "barcodePictureBox";
            this.barcodePictureBox.Size = new System.Drawing.Size(254, 199);
            this.barcodePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.barcodePictureBox.TabIndex = 0;
            this.barcodePictureBox.TabStop = false;
            // 
            // pictureUploadButton
            // 
            this.pictureUploadButton.AutoSize = true;
            this.pictureUploadButton.Location = new System.Drawing.Point(333, 113);
            this.pictureUploadButton.Name = "pictureUploadButton";
            this.pictureUploadButton.Size = new System.Drawing.Size(103, 23);
            this.pictureUploadButton.TabIndex = 1;
            this.pictureUploadButton.Text = "Upload";
            this.pictureUploadButton.UseVisualStyleBackColor = true;
            this.pictureUploadButton.Click += new System.EventHandler(this.pictureUploadButton_Click);
            // 
            // BarcodeScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 266);
            this.Controls.Add(this.pictureUploadButton);
            this.Controls.Add(this.barcodePictureBox);
            this.Name = "BarcodeScanner";
            this.Text = "BarcodeScanner";
            ((System.ComponentModel.ISupportInitialize)(this.barcodePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox barcodePictureBox;
        private System.Windows.Forms.Button pictureUploadButton;
    }
}