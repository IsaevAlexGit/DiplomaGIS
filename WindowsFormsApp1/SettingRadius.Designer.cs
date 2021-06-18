namespace OptimumPharmacy
{
    partial class SettingRadius
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingRadius));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.InputRadiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxRadius = new System.Windows.Forms.TextBox();
            this.labelMetr = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Bisque;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputRadiusToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(498, 75);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // InputRadiusToolStripMenuItem
            // 
            this.InputRadiusToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputRadiusToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconRadiusBack;
            this.InputRadiusToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InputRadiusToolStripMenuItem.Name = "InputRadiusToolStripMenuItem";
            this.InputRadiusToolStripMenuItem.Size = new System.Drawing.Size(180, 71);
            this.InputRadiusToolStripMenuItem.Text = "Задать радиус и вернуться";
            this.InputRadiusToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.InputRadiusToolStripMenuItem.Click += new System.EventHandler(this.InputRadiusToolStripMenuItem_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(10, 80);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(486, 80);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Задайте радиус поиска, и приложение будет проводить\r\nконкурентный анализ и анализ" +
    " населения в указанном диапазоне.\r\n\r\nРадиус должен быть указан в метрах в интерв" +
    "але [300,1500].";
            // 
            // textBoxRadius
            // 
            this.textBoxRadius.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRadius.Location = new System.Drawing.Point(12, 163);
            this.textBoxRadius.Name = "textBoxRadius";
            this.textBoxRadius.Size = new System.Drawing.Size(114, 29);
            this.textBoxRadius.TabIndex = 1;
            // 
            // labelMetr
            // 
            this.labelMetr.AutoSize = true;
            this.labelMetr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMetr.Location = new System.Drawing.Point(129, 171);
            this.labelMetr.Name = "labelMetr";
            this.labelMetr.Size = new System.Drawing.Size(55, 17);
            this.labelMetr.TabIndex = 2;
            this.labelMetr.Text = "метров";
            // 
            // SettingRadius
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(498, 202);
            this.Controls.Add(this.labelMetr);
            this.Controls.Add(this.textBoxRadius);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(514, 241);
            this.MinimumSize = new System.Drawing.Size(514, 241);
            this.Name = "SettingRadius";
            this.Text = "Установка радиуса поиска";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingRadius_FormClosing);
            this.Load += new System.EventHandler(this.SettingRadius_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingRadius_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem InputRadiusToolStripMenuItem;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxRadius;
        private System.Windows.Forms.Label labelMetr;
    }
}