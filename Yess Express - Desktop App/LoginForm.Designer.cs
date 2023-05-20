
namespace Yess_Express___Desktop_App
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassCode = new System.Windows.Forms.TextBox();
            this.buttonPassCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(306, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pass Code";
            // 
            // textBoxPassCode
            // 
            this.textBoxPassCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassCode.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassCode.Location = new System.Drawing.Point(211, 153);
            this.textBoxPassCode.Name = "textBoxPassCode";
            this.textBoxPassCode.Size = new System.Drawing.Size(314, 31);
            this.textBoxPassCode.TabIndex = 1;
            // 
            // buttonPassCode
            // 
            this.buttonPassCode.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonPassCode.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPassCode.ForeColor = System.Drawing.Color.White;
            this.buttonPassCode.Location = new System.Drawing.Point(326, 202);
            this.buttonPassCode.Name = "buttonPassCode";
            this.buttonPassCode.Size = new System.Drawing.Size(75, 36);
            this.buttonPassCode.TabIndex = 2;
            this.buttonPassCode.Text = "Login";
            this.buttonPassCode.UseVisualStyleBackColor = false;
            this.buttonPassCode.Click += new System.EventHandler(this.buttonPassCode_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 571);
            this.Controls.Add(this.textBoxPassCode);
            this.Controls.Add(this.buttonPassCode);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Text = "Yes-Express";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassCode;
        private System.Windows.Forms.Button buttonPassCode;
    }
}