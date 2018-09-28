namespace VirtualLibrary.Forms
{
    partial class BookActions
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
            this.label1 = new System.Windows.Forms.Label();
            this.ScannedBookInfo = new System.Windows.Forms.Label();
            this.TakeBookButton = new System.Windows.Forms.Button();
            this.ReturnBookButton = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // barcodePictureBox
            // 
            this.barcodePictureBox.Location = new System.Drawing.Point(21, 64);
            this.barcodePictureBox.Name = "barcodePictureBox";
            this.barcodePictureBox.Size = new System.Drawing.Size(240, 154);
            this.barcodePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.barcodePictureBox.TabIndex = 0;
            this.barcodePictureBox.TabStop = false;
            // 
            // pictureUploadButton
            // 
            this.pictureUploadButton.AutoSize = true;
            this.pictureUploadButton.Location = new System.Drawing.Point(158, 31);
            this.pictureUploadButton.Name = "pictureUploadButton";
            this.pictureUploadButton.Size = new System.Drawing.Size(103, 23);
            this.pictureUploadButton.TabIndex = 1;
            this.pictureUploadButton.Text = "Upload";
            this.pictureUploadButton.UseVisualStyleBackColor = true;
            this.pictureUploadButton.Click += new System.EventHandler(this.PictureUploadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Upload picture of barcode";
            // 
            // ScannedBookInfo
            // 
            this.ScannedBookInfo.AutoSize = true;
            this.ScannedBookInfo.Location = new System.Drawing.Point(31, 255);
            this.ScannedBookInfo.Name = "ScannedBookInfo";
            this.ScannedBookInfo.Size = new System.Drawing.Size(93, 13);
            this.ScannedBookInfo.TabIndex = 3;
            this.ScannedBookInfo.Text = "ScannedBookInfo";
            this.ScannedBookInfo.Click += new System.EventHandler(this.ScannedBookInfo_Click);
            // 
            // TakeBookButton
            // 
            this.TakeBookButton.Location = new System.Drawing.Point(285, 232);
            this.TakeBookButton.Name = "TakeBookButton";
            this.TakeBookButton.Size = new System.Drawing.Size(113, 23);
            this.TakeBookButton.TabIndex = 4;
            this.TakeBookButton.Text = "Take this book";
            this.TakeBookButton.UseVisualStyleBackColor = true;
            this.TakeBookButton.Click += new System.EventHandler(this.TakeBookButton_Click);
            // 
            // ReturnBookButton
            // 
            this.ReturnBookButton.Location = new System.Drawing.Point(285, 270);
            this.ReturnBookButton.Name = "ReturnBookButton";
            this.ReturnBookButton.Size = new System.Drawing.Size(113, 23);
            this.ReturnBookButton.TabIndex = 5;
            this.ReturnBookButton.Text = "Return this book";
            this.ReturnBookButton.UseVisualStyleBackColor = true;
            this.ReturnBookButton.Click += new System.EventHandler(this.ReturnBookButton_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info.Location = new System.Drawing.Point(31, 237);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(93, 13);
            this.Info.TabIndex = 6;
            this.Info.Text = "Scanned book:";
            // 
            // BookActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 315);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.ReturnBookButton);
            this.Controls.Add(this.TakeBookButton);
            this.Controls.Add(this.ScannedBookInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureUploadButton);
            this.Controls.Add(this.barcodePictureBox);
            this.Name = "BookActions";
            this.Text = "BarcodeScanner";
            ((System.ComponentModel.ISupportInitialize)(this.barcodePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox barcodePictureBox;
        private System.Windows.Forms.Button pictureUploadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ScannedBookInfo;
        private System.Windows.Forms.Button TakeBookButton;
        private System.Windows.Forms.Button ReturnBookButton;
        private System.Windows.Forms.Label Info;
    }
}