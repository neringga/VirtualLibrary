using VirtualLibrary.Localization;

namespace VirtualLibrary
{
    partial class LiveCamera
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
            this.continueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.continueButton.Location = new System.Drawing.Point(58, 55);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(170, 43);
            this.continueButton.TabIndex = 3;
            this.continueButton.Text = Translations.GetTranslatedString("continueButton");
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // LiveCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 154);
            this.Controls.Add(this.continueButton);
            this.Name = "LiveCamera";
            this.Text = Translations.GetTranslatedString("form2");
            this.Shown += new System.EventHandler(this.StartTakingPictures);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button continueButton;
    }
}