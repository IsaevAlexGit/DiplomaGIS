namespace OptimumPharmacy
{
    partial class SettingTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingTime));
            this.labelTime = new System.Windows.Forms.Label();
            this.maskedTextBoxTime = new System.Windows.Forms.MaskedTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.InputTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelInfo = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(10, 145);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(64, 21);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "Время:";
            // 
            // maskedTextBoxTime
            // 
            this.maskedTextBoxTime.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBoxTime.Location = new System.Drawing.Point(80, 137);
            this.maskedTextBoxTime.Mask = "00:00";
            this.maskedTextBoxTime.Name = "maskedTextBoxTime";
            this.maskedTextBoxTime.Size = new System.Drawing.Size(57, 33);
            this.maskedTextBoxTime.TabIndex = 2;
            this.maskedTextBoxTime.ValidatingType = typeof(System.DateTime);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Bisque;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputTimeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(421, 75);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // InputTimeToolStripMenuItem
            // 
            this.InputTimeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputTimeToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconTimeBack;
            this.InputTimeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InputTimeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InputTimeToolStripMenuItem.Name = "InputTimeToolStripMenuItem";
            this.InputTimeToolStripMenuItem.Size = new System.Drawing.Size(177, 71);
            this.InputTimeToolStripMenuItem.Text = "Задать время и вернуться";
            this.InputTimeToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.InputTimeToolStripMenuItem.Click += new System.EventHandler(this.InputTimeToolStripMenuItem_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(10, 87);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(408, 42);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Укажите время работы, и на карте останутся аптеки,\r\nкоторые работают в указанное " +
    "время.";
            // 
            // SettingTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(421, 180);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.maskedTextBoxTime);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(437, 219);
            this.MinimumSize = new System.Drawing.Size(437, 219);
            this.Name = "SettingTime";
            this.Text = "Установка времени работы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingTime_FormClosing);
            this.Load += new System.EventHandler(this.SettingTime_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingTime_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTime;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem InputTimeToolStripMenuItem;
        private System.Windows.Forms.Label labelInfo;
    }
}