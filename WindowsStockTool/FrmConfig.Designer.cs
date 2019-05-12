namespace WindowsStockTool
{
    partial class FrmConfig
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxRunWithSystem = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(161, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存(%S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxRunWithSystem
            // 
            this.cbxRunWithSystem.AutoSize = true;
            this.cbxRunWithSystem.Location = new System.Drawing.Point(37, 12);
            this.cbxRunWithSystem.Name = "cbxRunWithSystem";
            this.cbxRunWithSystem.Size = new System.Drawing.Size(96, 16);
            this.cbxRunWithSystem.TabIndex = 3;
            this.cbxRunWithSystem.Text = "开机自动启动";
            this.cbxRunWithSystem.UseVisualStyleBackColor = true;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 179);
            this.Controls.Add(this.cbxRunWithSystem);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmConfig";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbxRunWithSystem;
    }
}