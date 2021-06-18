namespace OptimumPharmacy
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.labelAboutProgram = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.buttonProceed = new System.Windows.Forms.Button();
            this.labelNameProgram = new System.Windows.Forms.Label();
            this.labelLanguageMap = new System.Windows.Forms.Label();
            this.buttonPDF = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAboutProgram
            // 
            this.labelAboutProgram.AutoSize = true;
            this.labelAboutProgram.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAboutProgram.Location = new System.Drawing.Point(41, 168);
            this.labelAboutProgram.Name = "labelAboutProgram";
            this.labelAboutProgram.Size = new System.Drawing.Size(693, 21);
            this.labelAboutProgram.TabIndex = 4;
            this.labelAboutProgram.Text = "Картографический сервис поможет вам выгодно разместить на карте города аптечный б" +
    "изнес";
            this.labelAboutProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "Русский",
            "Английский"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(321, 214);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(162, 29);
            this.comboBoxLanguage.TabIndex = 0;
            // 
            // buttonProceed
            // 
            this.buttonProceed.BackColor = System.Drawing.Color.Bisque;
            this.buttonProceed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonProceed.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonProceed.Location = new System.Drawing.Point(321, 319);
            this.buttonProceed.Name = "buttonProceed";
            this.buttonProceed.Size = new System.Drawing.Size(162, 55);
            this.buttonProceed.TabIndex = 1;
            this.buttonProceed.Text = "Продолжить";
            this.toolTip.SetToolTip(this.buttonProceed, "Выберите язык для работы с картой и приступайте к работе в приложении.");
            this.buttonProceed.UseVisualStyleBackColor = false;
            this.buttonProceed.Click += new System.EventHandler(this.buttonProceed_Click);
            // 
            // labelNameProgram
            // 
            this.labelNameProgram.AutoSize = true;
            this.labelNameProgram.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameProgram.Location = new System.Drawing.Point(316, 143);
            this.labelNameProgram.Name = "labelNameProgram";
            this.labelNameProgram.Size = new System.Drawing.Size(167, 25);
            this.labelNameProgram.TabIndex = 3;
            this.labelNameProgram.Text = "Оптимум. Аптеки";
            // 
            // labelLanguageMap
            // 
            this.labelLanguageMap.AutoSize = true;
            this.labelLanguageMap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLanguageMap.Location = new System.Drawing.Point(307, 194);
            this.labelLanguageMap.Name = "labelLanguageMap";
            this.labelLanguageMap.Size = new System.Drawing.Size(192, 17);
            this.labelLanguageMap.TabIndex = 5;
            this.labelLanguageMap.Text = "Выберите локализацию карты:";
            // 
            // buttonPDF
            // 
            this.buttonPDF.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonPDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPDF.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPDF.Image = global::OptimumPharmacy.Properties.Resources.iconPDF;
            this.buttonPDF.Location = new System.Drawing.Point(665, 283);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(116, 91);
            this.buttonPDF.TabIndex = 2;
            this.buttonPDF.Text = "Руководство пользователя";
            this.buttonPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.buttonPDF, "Ознакомиться с руководством пользователя.");
            this.buttonPDF.UseVisualStyleBackColor = false;
            this.buttonPDF.Click += new System.EventHandler(this.buttonPDF_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox.Image = global::OptimumPharmacy.Properties.Resources.iconApplication;
            this.pictureBox.Location = new System.Drawing.Point(332, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(128, 128);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(794, 389);
            this.Controls.Add(this.labelLanguageMap);
            this.Controls.Add(this.buttonPDF);
            this.Controls.Add(this.labelNameProgram);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonProceed);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.labelAboutProgram);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(810, 428);
            this.MinimumSize = new System.Drawing.Size(810, 428);
            this.Name = "StartForm";
            this.Text = "Вход";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAboutProgram;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Button buttonProceed;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelNameProgram;
        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.Label labelLanguageMap;
        private System.Windows.Forms.ToolTip toolTip;
    }
}