
namespace Yess_Express___Desktop_App
{
    partial class SettingsForm
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
            this.labelStartForTrackingNo = new System.Windows.Forms.Label();
            this.labelEndForTrackingNo = new System.Windows.Forms.Label();
            this.textBoxStartTrackingNo = new System.Windows.Forms.TextBox();
            this.textBoxEndTrackingNo = new System.Windows.Forms.TextBox();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrivousTrakcingNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelStartForTrackingNo
            // 
            this.labelStartForTrackingNo.AutoSize = true;
            this.labelStartForTrackingNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelStartForTrackingNo.Location = new System.Drawing.Point(124, 148);
            this.labelStartForTrackingNo.Name = "labelStartForTrackingNo";
            this.labelStartForTrackingNo.Size = new System.Drawing.Size(158, 20);
            this.labelStartForTrackingNo.TabIndex = 0;
            this.labelStartForTrackingNo.Text = "Start For Tracking No";
            // 
            // labelEndForTrackingNo
            // 
            this.labelEndForTrackingNo.AutoSize = true;
            this.labelEndForTrackingNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEndForTrackingNo.Location = new System.Drawing.Point(124, 219);
            this.labelEndForTrackingNo.Name = "labelEndForTrackingNo";
            this.labelEndForTrackingNo.Size = new System.Drawing.Size(150, 20);
            this.labelEndForTrackingNo.TabIndex = 1;
            this.labelEndForTrackingNo.Text = "End For Tracking No";
            // 
            // textBoxStartTrackingNo
            // 
            this.textBoxStartTrackingNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxStartTrackingNo.Location = new System.Drawing.Point(314, 145);
            this.textBoxStartTrackingNo.Name = "textBoxStartTrackingNo";
            this.textBoxStartTrackingNo.Size = new System.Drawing.Size(292, 27);
            this.textBoxStartTrackingNo.TabIndex = 2;
            this.textBoxStartTrackingNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStartTrackingNo_KeyPress);
            // 
            // textBoxEndTrackingNo
            // 
            this.textBoxEndTrackingNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEndTrackingNo.Location = new System.Drawing.Point(314, 216);
            this.textBoxEndTrackingNo.Name = "textBoxEndTrackingNo";
            this.textBoxEndTrackingNo.Size = new System.Drawing.Size(292, 27);
            this.textBoxEndTrackingNo.TabIndex = 3;
            this.textBoxEndTrackingNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEndTrackingNo_KeyPress);
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSaveData.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSaveData.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonSaveData.Location = new System.Drawing.Point(514, 362);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(75, 35);
            this.buttonSaveData.TabIndex = 4;
            this.buttonSaveData.Text = "Save";
            this.buttonSaveData.UseVisualStyleBackColor = false;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(124, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Privous Tracking No";
            // 
            // textBoxPrivousTrakcingNo
            // 
            this.textBoxPrivousTrakcingNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPrivousTrakcingNo.Location = new System.Drawing.Point(314, 287);
            this.textBoxPrivousTrakcingNo.Name = "textBoxPrivousTrakcingNo";
            this.textBoxPrivousTrakcingNo.Size = new System.Drawing.Size(292, 27);
            this.textBoxPrivousTrakcingNo.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 747);
            this.Controls.Add(this.textBoxPrivousTrakcingNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.textBoxEndTrackingNo);
            this.Controls.Add(this.textBoxStartTrackingNo);
            this.Controls.Add(this.labelEndForTrackingNo);
            this.Controls.Add(this.labelStartForTrackingNo);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStartForTrackingNo;
        private System.Windows.Forms.Label labelEndForTrackingNo;
        private System.Windows.Forms.TextBox textBoxStartTrackingNo;
        private System.Windows.Forms.TextBox textBoxEndTrackingNo;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrivousTrakcingNo;
    }
}