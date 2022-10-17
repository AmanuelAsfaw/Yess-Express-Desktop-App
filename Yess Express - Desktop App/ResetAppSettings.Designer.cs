
namespace Yess_Express___Desktop_App
{
    partial class ResetAppSettings
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
            this.labelCreatedDB = new System.Windows.Forms.Label();
            this.labelProviousIs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCreatedDB
            // 
            this.labelCreatedDB.AutoSize = true;
            this.labelCreatedDB.Location = new System.Drawing.Point(134, 79);
            this.labelCreatedDB.Name = "labelCreatedDB";
            this.labelCreatedDB.Size = new System.Drawing.Size(38, 15);
            this.labelCreatedDB.TabIndex = 0;
            this.labelCreatedDB.Text = "label1";
            // 
            // labelProviousIs
            // 
            this.labelProviousIs.AutoSize = true;
            this.labelProviousIs.Location = new System.Drawing.Point(382, 78);
            this.labelProviousIs.Name = "labelProviousIs";
            this.labelProviousIs.Size = new System.Drawing.Size(38, 15);
            this.labelProviousIs.TabIndex = 1;
            this.labelProviousIs.Text = "label1";
            // 
            // ResetAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelProviousIs);
            this.Controls.Add(this.labelCreatedDB);
            this.Name = "ResetAppSettings";
            this.Text = "ResetAppSettings";
            this.Load += new System.EventHandler(this.ResetAppSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCreatedDB;
        private System.Windows.Forms.Label labelProviousIs;
    }
}