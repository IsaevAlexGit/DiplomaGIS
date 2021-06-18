namespace OptimumPharmacy
{
    partial class SettingOptions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingOptions));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.SaveAllParamВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxPharma = new System.Windows.Forms.GroupBox();
            this.labelMaxForPharma = new System.Windows.Forms.Label();
            this.labelCountColorPharma = new System.Windows.Forms.Label();
            this.textBoxMaxPharma = new System.Windows.Forms.TextBox();
            this.textBoxColorPharma = new System.Windows.Forms.TextBox();
            this.labelMaxPharma = new System.Windows.Forms.Label();
            this.labelMinPharma = new System.Windows.Forms.Label();
            this.groupBoxResidents = new System.Windows.Forms.GroupBox();
            this.labelMaxForResidents = new System.Windows.Forms.Label();
            this.labelCountColorResidents = new System.Windows.Forms.Label();
            this.textBoxMaxResidents = new System.Windows.Forms.TextBox();
            this.textBoxColorResidents = new System.Windows.Forms.TextBox();
            this.labelMaxResidents = new System.Windows.Forms.Label();
            this.labelMinResidents = new System.Windows.Forms.Label();
            this.groupBoxRetired = new System.Windows.Forms.GroupBox();
            this.labelMaxForRetired = new System.Windows.Forms.Label();
            this.labelCountColorRetired = new System.Windows.Forms.Label();
            this.textBoxMaxRetired = new System.Windows.Forms.TextBox();
            this.textBoxColorRetired = new System.Windows.Forms.TextBox();
            this.labelMaxRetired = new System.Windows.Forms.Label();
            this.labelMinRetired = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.groupBoxPharma.SuspendLayout();
            this.groupBoxResidents.SuspendLayout();
            this.groupBoxRetired.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Bisque;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAllParamВсеToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(839, 73);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // SaveAllParamВсеToolStripMenuItem
            // 
            this.SaveAllParamВсеToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconSaveAllParam;
            this.SaveAllParamВсеToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SaveAllParamВсеToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveAllParamВсеToolStripMenuItem.Name = "SaveAllParamВсеToolStripMenuItem";
            this.SaveAllParamВсеToolStripMenuItem.Size = new System.Drawing.Size(314, 69);
            this.SaveAllParamВсеToolStripMenuItem.Text = "Сохранить все параметры для раскраски и вернуться";
            this.SaveAllParamВсеToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveAllParamВсеToolStripMenuItem.Click += new System.EventHandler(this.SaveAllParamВсеToolStripMenuItem_Click);
            // 
            // groupBoxPharma
            // 
            this.groupBoxPharma.Controls.Add(this.labelMaxForPharma);
            this.groupBoxPharma.Controls.Add(this.labelCountColorPharma);
            this.groupBoxPharma.Controls.Add(this.textBoxMaxPharma);
            this.groupBoxPharma.Controls.Add(this.textBoxColorPharma);
            this.groupBoxPharma.Controls.Add(this.labelMaxPharma);
            this.groupBoxPharma.Controls.Add(this.labelMinPharma);
            this.groupBoxPharma.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPharma.Location = new System.Drawing.Point(12, 79);
            this.groupBoxPharma.Name = "groupBoxPharma";
            this.groupBoxPharma.Size = new System.Drawing.Size(246, 162);
            this.groupBoxPharma.TabIndex = 0;
            this.groupBoxPharma.TabStop = false;
            this.groupBoxPharma.Text = "Параметры для аптек";
            // 
            // labelMaxForPharma
            // 
            this.labelMaxForPharma.AutoSize = true;
            this.labelMaxForPharma.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxForPharma.Location = new System.Drawing.Point(181, 70);
            this.labelMaxForPharma.Name = "labelMaxForPharma";
            this.labelMaxForPharma.Size = new System.Drawing.Size(63, 25);
            this.labelMaxForPharma.TabIndex = 3;
            this.labelMaxForPharma.Text = " <=50";
            // 
            // labelCountColorPharma
            // 
            this.labelCountColorPharma.AutoSize = true;
            this.labelCountColorPharma.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountColorPharma.Location = new System.Drawing.Point(10, 116);
            this.labelCountColorPharma.Name = "labelCountColorPharma";
            this.labelCountColorPharma.Size = new System.Drawing.Size(117, 34);
            this.labelCountColorPharma.TabIndex = 4;
            this.labelCountColorPharma.Text = "Количество\r\nградаций цветов:";
            this.toolTip.SetToolTip(this.labelCountColorPharma, "Количество оттенков должно быть в пределах от 2 до 10");
            // 
            // textBoxMaxPharma
            // 
            this.textBoxMaxPharma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMaxPharma.Location = new System.Drawing.Point(90, 71);
            this.textBoxMaxPharma.Name = "textBoxMaxPharma";
            this.textBoxMaxPharma.Size = new System.Drawing.Size(85, 29);
            this.textBoxMaxPharma.TabIndex = 2;
            // 
            // textBoxColorPharma
            // 
            this.textBoxColorPharma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxColorPharma.Location = new System.Drawing.Point(133, 121);
            this.textBoxColorPharma.Name = "textBoxColorPharma";
            this.textBoxColorPharma.Size = new System.Drawing.Size(100, 29);
            this.textBoxColorPharma.TabIndex = 5;
            // 
            // labelMaxPharma
            // 
            this.labelMaxPharma.AutoSize = true;
            this.labelMaxPharma.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxPharma.Location = new System.Drawing.Point(10, 76);
            this.labelMaxPharma.Name = "labelMaxPharma";
            this.labelMaxPharma.Size = new System.Drawing.Size(78, 17);
            this.labelMaxPharma.TabIndex = 1;
            this.labelMaxPharma.Text = "Максимум:";
            this.toolTip.SetToolTip(this.labelMaxPharma, "Максимум должен быть целым положительными числом в интервале [2,50].");
            // 
            // labelMinPharma
            // 
            this.labelMinPharma.AutoSize = true;
            this.labelMinPharma.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinPharma.Location = new System.Drawing.Point(10, 36);
            this.labelMinPharma.Name = "labelMinPharma";
            this.labelMinPharma.Size = new System.Drawing.Size(85, 17);
            this.labelMinPharma.TabIndex = 0;
            this.labelMinPharma.Text = "Минимум: 0";
            // 
            // groupBoxResidents
            // 
            this.groupBoxResidents.Controls.Add(this.labelMaxForResidents);
            this.groupBoxResidents.Controls.Add(this.labelCountColorResidents);
            this.groupBoxResidents.Controls.Add(this.textBoxMaxResidents);
            this.groupBoxResidents.Controls.Add(this.textBoxColorResidents);
            this.groupBoxResidents.Controls.Add(this.labelMaxResidents);
            this.groupBoxResidents.Controls.Add(this.labelMinResidents);
            this.groupBoxResidents.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxResidents.Location = new System.Drawing.Point(264, 79);
            this.groupBoxResidents.Name = "groupBoxResidents";
            this.groupBoxResidents.Size = new System.Drawing.Size(278, 162);
            this.groupBoxResidents.TabIndex = 2;
            this.groupBoxResidents.TabStop = false;
            this.groupBoxResidents.Text = "Параметры для жителей";
            // 
            // labelMaxForResidents
            // 
            this.labelMaxForResidents.AutoSize = true;
            this.labelMaxForResidents.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxForResidents.Location = new System.Drawing.Point(180, 70);
            this.labelMaxForResidents.Name = "labelMaxForResidents";
            this.labelMaxForResidents.Size = new System.Drawing.Size(93, 25);
            this.labelMaxForResidents.TabIndex = 3;
            this.labelMaxForResidents.Text = " <=10000";
            // 
            // labelCountColorResidents
            // 
            this.labelCountColorResidents.AutoSize = true;
            this.labelCountColorResidents.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountColorResidents.Location = new System.Drawing.Point(10, 116);
            this.labelCountColorResidents.Name = "labelCountColorResidents";
            this.labelCountColorResidents.Size = new System.Drawing.Size(117, 34);
            this.labelCountColorResidents.TabIndex = 4;
            this.labelCountColorResidents.Text = "Количество\r\nградаций цветов:";
            this.toolTip.SetToolTip(this.labelCountColorResidents, "Количество оттенков должно быть в пределах от 2 до 10");
            // 
            // textBoxMaxResidents
            // 
            this.textBoxMaxResidents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMaxResidents.Location = new System.Drawing.Point(90, 71);
            this.textBoxMaxResidents.Name = "textBoxMaxResidents";
            this.textBoxMaxResidents.Size = new System.Drawing.Size(84, 29);
            this.textBoxMaxResidents.TabIndex = 2;
            // 
            // textBoxColorResidents
            // 
            this.textBoxColorResidents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxColorResidents.Location = new System.Drawing.Point(133, 121);
            this.textBoxColorResidents.Name = "textBoxColorResidents";
            this.textBoxColorResidents.Size = new System.Drawing.Size(100, 29);
            this.textBoxColorResidents.TabIndex = 5;
            // 
            // labelMaxResidents
            // 
            this.labelMaxResidents.AutoSize = true;
            this.labelMaxResidents.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxResidents.Location = new System.Drawing.Point(10, 76);
            this.labelMaxResidents.Name = "labelMaxResidents";
            this.labelMaxResidents.Size = new System.Drawing.Size(78, 17);
            this.labelMaxResidents.TabIndex = 1;
            this.labelMaxResidents.Text = "Максимум:";
            this.toolTip.SetToolTip(this.labelMaxResidents, "Максимум должен быть целым положительными числом в интервале [1,10000].");
            // 
            // labelMinResidents
            // 
            this.labelMinResidents.AutoSize = true;
            this.labelMinResidents.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinResidents.Location = new System.Drawing.Point(10, 36);
            this.labelMinResidents.Name = "labelMinResidents";
            this.labelMinResidents.Size = new System.Drawing.Size(85, 17);
            this.labelMinResidents.TabIndex = 0;
            this.labelMinResidents.Text = "Минимум: 0";
            // 
            // groupBoxRetired
            // 
            this.groupBoxRetired.Controls.Add(this.labelMaxForRetired);
            this.groupBoxRetired.Controls.Add(this.labelCountColorRetired);
            this.groupBoxRetired.Controls.Add(this.textBoxMaxRetired);
            this.groupBoxRetired.Controls.Add(this.textBoxColorRetired);
            this.groupBoxRetired.Controls.Add(this.labelMaxRetired);
            this.groupBoxRetired.Controls.Add(this.labelMinRetired);
            this.groupBoxRetired.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxRetired.Location = new System.Drawing.Point(548, 79);
            this.groupBoxRetired.Name = "groupBoxRetired";
            this.groupBoxRetired.Size = new System.Drawing.Size(278, 162);
            this.groupBoxRetired.TabIndex = 3;
            this.groupBoxRetired.TabStop = false;
            this.groupBoxRetired.Text = "Параметры для пенсионеров";
            // 
            // labelMaxForRetired
            // 
            this.labelMaxForRetired.AutoSize = true;
            this.labelMaxForRetired.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxForRetired.Location = new System.Drawing.Point(190, 70);
            this.labelMaxForRetired.Name = "labelMaxForRetired";
            this.labelMaxForRetired.Size = new System.Drawing.Size(83, 25);
            this.labelMaxForRetired.TabIndex = 3;
            this.labelMaxForRetired.Text = " <=3000";
            // 
            // labelCountColorRetired
            // 
            this.labelCountColorRetired.AutoSize = true;
            this.labelCountColorRetired.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountColorRetired.Location = new System.Drawing.Point(10, 116);
            this.labelCountColorRetired.Name = "labelCountColorRetired";
            this.labelCountColorRetired.Size = new System.Drawing.Size(117, 34);
            this.labelCountColorRetired.TabIndex = 4;
            this.labelCountColorRetired.Text = "Количество\r\nградаций цветов:";
            this.toolTip.SetToolTip(this.labelCountColorRetired, "Количество оттенков должно быть в пределах от 2 до 10");
            // 
            // textBoxMaxRetired
            // 
            this.textBoxMaxRetired.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMaxRetired.Location = new System.Drawing.Point(90, 71);
            this.textBoxMaxRetired.Name = "textBoxMaxRetired";
            this.textBoxMaxRetired.Size = new System.Drawing.Size(100, 29);
            this.textBoxMaxRetired.TabIndex = 2;
            // 
            // textBoxColorRetired
            // 
            this.textBoxColorRetired.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxColorRetired.Location = new System.Drawing.Point(133, 121);
            this.textBoxColorRetired.Name = "textBoxColorRetired";
            this.textBoxColorRetired.Size = new System.Drawing.Size(100, 29);
            this.textBoxColorRetired.TabIndex = 5;
            // 
            // labelMaxRetired
            // 
            this.labelMaxRetired.AutoSize = true;
            this.labelMaxRetired.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxRetired.Location = new System.Drawing.Point(10, 76);
            this.labelMaxRetired.Name = "labelMaxRetired";
            this.labelMaxRetired.Size = new System.Drawing.Size(78, 17);
            this.labelMaxRetired.TabIndex = 1;
            this.labelMaxRetired.Text = "Максимум:";
            this.toolTip.SetToolTip(this.labelMaxRetired, "Максимум должен быть целым положительными числом в интервале [1,3000].");
            // 
            // labelMinRetired
            // 
            this.labelMinRetired.AutoSize = true;
            this.labelMinRetired.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinRetired.Location = new System.Drawing.Point(10, 36);
            this.labelMinRetired.Name = "labelMinRetired";
            this.labelMinRetired.Size = new System.Drawing.Size(85, 17);
            this.labelMinRetired.TabIndex = 0;
            this.labelMinRetired.Text = "Минимум: 0";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // SettingOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(839, 254);
            this.Controls.Add(this.groupBoxRetired);
            this.Controls.Add(this.groupBoxResidents);
            this.Controls.Add(this.groupBoxPharma);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(855, 293);
            this.MinimumSize = new System.Drawing.Size(855, 293);
            this.Name = "SettingOptions";
            this.Text = "Установка параметров для раскраски";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingOptions_FormClosing);
            this.Load += new System.EventHandler(this.SettingOptions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingOptions_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxPharma.ResumeLayout(false);
            this.groupBoxPharma.PerformLayout();
            this.groupBoxResidents.ResumeLayout(false);
            this.groupBoxResidents.PerformLayout();
            this.groupBoxRetired.ResumeLayout(false);
            this.groupBoxRetired.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.GroupBox groupBoxPharma;
        private System.Windows.Forms.Label labelCountColorPharma;
        private System.Windows.Forms.TextBox textBoxMaxPharma;
        private System.Windows.Forms.TextBox textBoxColorPharma;
        private System.Windows.Forms.Label labelMaxPharma;
        private System.Windows.Forms.GroupBox groupBoxResidents;
        private System.Windows.Forms.Label labelCountColorResidents;
        private System.Windows.Forms.TextBox textBoxMaxResidents;
        private System.Windows.Forms.TextBox textBoxColorResidents;
        private System.Windows.Forms.Label labelMaxResidents;
        private System.Windows.Forms.Label labelMinResidents;
        private System.Windows.Forms.GroupBox groupBoxRetired;
        private System.Windows.Forms.Label labelCountColorRetired;
        private System.Windows.Forms.TextBox textBoxMaxRetired;
        private System.Windows.Forms.TextBox textBoxColorRetired;
        private System.Windows.Forms.Label labelMaxRetired;
        private System.Windows.Forms.Label labelMinRetired;
        private System.Windows.Forms.Label labelMinPharma;
        private System.Windows.Forms.Label labelMaxForPharma;
        private System.Windows.Forms.Label labelMaxForResidents;
        private System.Windows.Forms.Label labelMaxForRetired;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem SaveAllParamВсеToolStripMenuItem;
    }
}