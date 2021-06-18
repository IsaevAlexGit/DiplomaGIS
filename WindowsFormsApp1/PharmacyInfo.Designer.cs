namespace OptimumPharmacy
{
    partial class PharmacyInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PharmacyInfo));
            this.label_SitePharmacy = new System.Windows.Forms.Label();
            this.label_TimePharmacy = new System.Windows.Forms.Label();
            this.label_NamePharmacy = new System.Windows.Forms.Label();
            this.label_CityPharmacy = new System.Windows.Forms.Label();
            this.label_AddressPharmacy = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.label_Site = new System.Windows.Forms.Label();
            this.label_Address = new System.Windows.Forms.Label();
            this.label_City = new System.Windows.Forms.Label();
            this.groupBoxWithInfo = new System.Windows.Forms.GroupBox();
            this.label_PhonePharmacy = new System.Windows.Forms.Label();
            this.label_Phone = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxWithInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_SitePharmacy
            // 
            this.label_SitePharmacy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_SitePharmacy.Location = new System.Drawing.Point(107, 115);
            this.label_SitePharmacy.Name = "label_SitePharmacy";
            this.label_SitePharmacy.Size = new System.Drawing.Size(505, 23);
            this.label_SitePharmacy.TabIndex = 7;
            this.label_SitePharmacy.Text = "https://дешеваяаптека.рф";
            this.toolTip.SetToolTip(this.label_SitePharmacy, "Щелкните дважды левой кнопкой мыши, чтобы перейти на сайт данной аптеки.");
            this.label_SitePharmacy.DoubleClick += new System.EventHandler(this.labelSite_DoubleClick);
            // 
            // label_TimePharmacy
            // 
            this.label_TimePharmacy.AutoSize = true;
            this.label_TimePharmacy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_TimePharmacy.Location = new System.Drawing.Point(141, 175);
            this.label_TimePharmacy.Name = "label_TimePharmacy";
            this.label_TimePharmacy.Size = new System.Drawing.Size(94, 21);
            this.label_TimePharmacy.TabIndex = 11;
            this.label_TimePharmacy.Text = "08:00-21:00";
            // 
            // label_NamePharmacy
            // 
            this.label_NamePharmacy.AutoSize = true;
            this.label_NamePharmacy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_NamePharmacy.Location = new System.Drawing.Point(107, 55);
            this.label_NamePharmacy.Name = "label_NamePharmacy";
            this.label_NamePharmacy.Size = new System.Drawing.Size(128, 21);
            this.label_NamePharmacy.TabIndex = 3;
            this.label_NamePharmacy.Text = "Дешёвая Аптека";
            // 
            // label_CityPharmacy
            // 
            this.label_CityPharmacy.AutoSize = true;
            this.label_CityPharmacy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CityPharmacy.Location = new System.Drawing.Point(107, 25);
            this.label_CityPharmacy.Name = "label_CityPharmacy";
            this.label_CityPharmacy.Size = new System.Drawing.Size(73, 21);
            this.label_CityPharmacy.TabIndex = 1;
            this.label_CityPharmacy.Text = "Таганрог";
            // 
            // label_AddressPharmacy
            // 
            this.label_AddressPharmacy.AutoSize = true;
            this.label_AddressPharmacy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_AddressPharmacy.Location = new System.Drawing.Point(107, 85);
            this.label_AddressPharmacy.Name = "label_AddressPharmacy";
            this.label_AddressPharmacy.Size = new System.Drawing.Size(195, 21);
            this.label_AddressPharmacy.TabIndex = 5;
            this.label_AddressPharmacy.Text = "улица Дзержинского, 154";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Name.Location = new System.Drawing.Point(15, 55);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(86, 21);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "Название:";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Time.Location = new System.Drawing.Point(15, 175);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(124, 21);
            this.label_Time.TabIndex = 10;
            this.label_Time.Text = "Время работы:";
            // 
            // label_Site
            // 
            this.label_Site.AutoSize = true;
            this.label_Site.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Site.Location = new System.Drawing.Point(15, 115);
            this.label_Site.Name = "label_Site";
            this.label_Site.Size = new System.Drawing.Size(49, 21);
            this.label_Site.TabIndex = 6;
            this.label_Site.Text = "Сайт:";
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Address.Location = new System.Drawing.Point(15, 85);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(62, 21);
            this.label_Address.TabIndex = 4;
            this.label_Address.Text = "Адрес:";
            // 
            // label_City
            // 
            this.label_City.AutoSize = true;
            this.label_City.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_City.Location = new System.Drawing.Point(15, 25);
            this.label_City.Name = "label_City";
            this.label_City.Size = new System.Drawing.Size(59, 21);
            this.label_City.TabIndex = 0;
            this.label_City.Text = "Город:";
            // 
            // groupBoxWithInfo
            // 
            this.groupBoxWithInfo.Controls.Add(this.label_PhonePharmacy);
            this.groupBoxWithInfo.Controls.Add(this.label_Phone);
            this.groupBoxWithInfo.Controls.Add(this.label_City);
            this.groupBoxWithInfo.Controls.Add(this.label_SitePharmacy);
            this.groupBoxWithInfo.Controls.Add(this.label_Address);
            this.groupBoxWithInfo.Controls.Add(this.label_TimePharmacy);
            this.groupBoxWithInfo.Controls.Add(this.label_Site);
            this.groupBoxWithInfo.Controls.Add(this.label_NamePharmacy);
            this.groupBoxWithInfo.Controls.Add(this.label_Time);
            this.groupBoxWithInfo.Controls.Add(this.label_CityPharmacy);
            this.groupBoxWithInfo.Controls.Add(this.label_Name);
            this.groupBoxWithInfo.Controls.Add(this.label_AddressPharmacy);
            this.groupBoxWithInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxWithInfo.Location = new System.Drawing.Point(10, 45);
            this.groupBoxWithInfo.Name = "groupBoxWithInfo";
            this.groupBoxWithInfo.Size = new System.Drawing.Size(670, 210);
            this.groupBoxWithInfo.TabIndex = 1;
            this.groupBoxWithInfo.TabStop = false;
            this.groupBoxWithInfo.Text = "Информация об аптеке";
            // 
            // label_PhonePharmacy
            // 
            this.label_PhonePharmacy.AutoSize = true;
            this.label_PhonePharmacy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_PhonePharmacy.Location = new System.Drawing.Point(107, 145);
            this.label_PhonePharmacy.Name = "label_PhonePharmacy";
            this.label_PhonePharmacy.Size = new System.Drawing.Size(109, 21);
            this.label_PhonePharmacy.TabIndex = 9;
            this.label_PhonePharmacy.Text = "89885231244";
            // 
            // label_Phone
            // 
            this.label_Phone.AutoSize = true;
            this.label_Phone.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Phone.Location = new System.Drawing.Point(15, 145);
            this.label_Phone.Name = "label_Phone";
            this.label_Phone.Size = new System.Drawing.Size(79, 21);
            this.label_Phone.TabIndex = 8;
            this.label_Phone.Text = "Телефон:";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(10, 14);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(675, 25);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Щёлкните дважды левой кнопкой мыши по сайту, чтобы перейти на него.";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // PharmacyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(692, 263);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.groupBoxWithInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(708, 302);
            this.MinimumSize = new System.Drawing.Size(708, 302);
            this.Name = "PharmacyInfo";
            this.Text = "Информация об аптеке";
            this.Load += new System.EventHandler(this.PharmacyInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PharmacyInfo_KeyDown);
            this.groupBoxWithInfo.ResumeLayout(false);
            this.groupBoxWithInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_SitePharmacy;
        private System.Windows.Forms.Label label_TimePharmacy;
        private System.Windows.Forms.Label label_NamePharmacy;
        private System.Windows.Forms.Label label_CityPharmacy;
        private System.Windows.Forms.Label label_AddressPharmacy;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Label label_Site;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.Label label_City;
        private System.Windows.Forms.GroupBox groupBoxWithInfo;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label label_PhonePharmacy;
        private System.Windows.Forms.Label label_Phone;
        private System.Windows.Forms.ToolTip toolTip;
    }
}