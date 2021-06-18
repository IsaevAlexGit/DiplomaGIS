namespace OptimumPharmacy
{
    partial class MainMap
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMap));
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.radioButtonCity = new System.Windows.Forms.RadioButton();
            this.radioButtonDistrict = new System.Windows.Forms.RadioButton();
            this.radioButtonClearVisual = new System.Windows.Forms.RadioButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.LoadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IconPharmacyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPharmacyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadQuartetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputRadiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchOptimumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeaveOptimumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveOptimumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtonQuartetRetired = new System.Windows.Forms.RadioButton();
            this.radioButtonQuartetResidents = new System.Windows.Forms.RadioButton();
            this.radioButtonQuartetPharmacy = new System.Windows.Forms.RadioButton();
            this.radioButtonQuartetClear = new System.Windows.Forms.RadioButton();
            this.radioButtonIconClear = new System.Windows.Forms.RadioButton();
            this.radioButtonIconPharmacy = new System.Windows.Forms.RadioButton();
            this.radioButtonIconRetired = new System.Windows.Forms.RadioButton();
            this.radioButtonIconResidents = new System.Windows.Forms.RadioButton();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directorySearcher2 = new System.DirectoryServices.DirectorySearcher();
            this.groupBoxVisualCity = new System.Windows.Forms.GroupBox();
            this.groupBoxColoringParameters = new System.Windows.Forms.GroupBox();
            this.groupBoxColoringIcons = new System.Windows.Forms.GroupBox();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.timerForDateTime = new System.Windows.Forms.Timer(this.components);
            this.groupBoxPharmacyInfo = new System.Windows.Forms.GroupBox();
            this.radioButtonOnlyTimePharmacy = new System.Windows.Forms.RadioButton();
            this.radioButtonClearInfo = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyNamePharmacy = new System.Windows.Forms.RadioButton();
            this.radioButtonAllDataPharmacy = new System.Windows.Forms.RadioButton();
            this.groupBoxPharmacy = new System.Windows.Forms.GroupBox();
            this.radioButtonClearPharmacy = new System.Windows.Forms.RadioButton();
            this.radioButtonLoadTime = new System.Windows.Forms.RadioButton();
            this.radioButtonWorkNow = new System.Windows.Forms.RadioButton();
            this.radioButtonAllPharmacy = new System.Windows.Forms.RadioButton();
            this.panelLegendMap = new System.Windows.Forms.Panel();
            this.groupBoxPanel = new System.Windows.Forms.GroupBox();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.labelFew = new System.Windows.Forms.Label();
            this.labelMiddle = new System.Windows.Forms.Label();
            this.labelLot = new System.Windows.Forms.Label();
            this.labelUserMarker = new System.Windows.Forms.Label();
            this.labelPharmacy = new System.Windows.Forms.Label();
            this.labelLegendForMap = new System.Windows.Forms.Label();
            this.pictureBoxPharmacy = new System.Windows.Forms.PictureBox();
            this.pictureBoxFew = new System.Windows.Forms.PictureBox();
            this.pictureBoxMarker = new System.Windows.Forms.PictureBox();
            this.pictureBoxMiddle = new System.Windows.Forms.PictureBox();
            this.pictureBoxLot = new System.Windows.Forms.PictureBox();
            this.trackBarIntensity = new System.Windows.Forms.TrackBar();
            this.trackBarTransparent = new System.Windows.Forms.TrackBar();
            this.label_Transparent = new System.Windows.Forms.Label();
            this.label_Intensity = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.groupBoxVisualCity.SuspendLayout();
            this.groupBoxColoringParameters.SuspendLayout();
            this.groupBoxColoringIcons.SuspendLayout();
            this.groupBoxPharmacyInfo.SuspendLayout();
            this.groupBoxPharmacy.SuspendLayout();
            this.groupBoxPanel.SuspendLayout();
            this.panelLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPharmacy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMarker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparent)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(197, 85);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1151, 510);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.gmap.Load += new System.EventHandler(this.gMapControl_Load);
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // radioButtonCity
            // 
            this.radioButtonCity.AutoSize = true;
            this.radioButtonCity.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonCity.Location = new System.Drawing.Point(6, 19);
            this.radioButtonCity.Name = "radioButtonCity";
            this.radioButtonCity.Size = new System.Drawing.Size(69, 24);
            this.radioButtonCity.TabIndex = 0;
            this.radioButtonCity.Text = "Город";
            this.toolTip.SetToolTip(this.radioButtonCity, "На карте будет выделен весь город.");
            this.radioButtonCity.UseVisualStyleBackColor = true;
            this.radioButtonCity.Click += new System.EventHandler(this.radioButtonCity_Click);
            // 
            // radioButtonDistrict
            // 
            this.radioButtonDistrict.AutoSize = true;
            this.radioButtonDistrict.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonDistrict.Location = new System.Drawing.Point(6, 44);
            this.radioButtonDistrict.Name = "radioButtonDistrict";
            this.radioButtonDistrict.Size = new System.Drawing.Size(81, 24);
            this.radioButtonDistrict.TabIndex = 1;
            this.radioButtonDistrict.Text = "Районы";
            this.toolTip.SetToolTip(this.radioButtonDistrict, "На карте будет выделен весь город, разбитый на районы.");
            this.radioButtonDistrict.UseVisualStyleBackColor = true;
            this.radioButtonDistrict.Click += new System.EventHandler(this.radioButtonDistrict_Click);
            // 
            // radioButtonClearVisual
            // 
            this.radioButtonClearVisual.AutoSize = true;
            this.radioButtonClearVisual.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonClearVisual.Location = new System.Drawing.Point(6, 69);
            this.radioButtonClearVisual.Name = "radioButtonClearVisual";
            this.radioButtonClearVisual.Size = new System.Drawing.Size(91, 24);
            this.radioButtonClearVisual.TabIndex = 2;
            this.radioButtonClearVisual.Text = "Очистить";
            this.toolTip.SetToolTip(this.radioButtonClearVisual, "Убрать с карты отображение города.");
            this.radioButtonClearVisual.UseVisualStyleBackColor = true;
            this.radioButtonClearVisual.Click += new System.EventHandler(this.radioButtonClearVisual_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Bisque;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFileToolStripMenuItem,
            this.InputTimeToolStripMenuItem,
            this.InputOptionsToolStripMenuItem,
            this.InputRadiusToolStripMenuItem,
            this.SearchOptimumToolStripMenuItem,
            this.LeaveOptimumToolStripMenuItem,
            this.SaveOptimumToolStripMenuItem,
            this.SaveMapToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1358, 75);
            this.menuStrip.TabIndex = 60;
            this.menuStrip.Text = "menuStrip1";
            // 
            // LoadFileToolStripMenuItem
            // 
            this.LoadFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IconPharmacyToolStripMenuItem,
            this.LoadPharmacyToolStripMenuItem,
            this.LoadQuartetToolStripMenuItem});
            this.LoadFileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadFileToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconInputData;
            this.LoadFileToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LoadFileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadFileToolStripMenuItem.Name = "LoadFileToolStripMenuItem";
            this.LoadFileToolStripMenuItem.Size = new System.Drawing.Size(78, 71);
            this.LoadFileToolStripMenuItem.Text = "Загрузить";
            this.LoadFileToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // IconPharmacyToolStripMenuItem
            // 
            this.IconPharmacyToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconLoadDataIconUser;
            this.IconPharmacyToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.IconPharmacyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IconPharmacyToolStripMenuItem.Name = "IconPharmacyToolStripMenuItem";
            this.IconPharmacyToolStripMenuItem.Size = new System.Drawing.Size(294, 42);
            this.IconPharmacyToolStripMenuItem.Text = "Значок аптеки";
            this.IconPharmacyToolStripMenuItem.Click += new System.EventHandler(this.IconPharmacyToolStripMenuItem_Click);
            // 
            // LoadPharmacyToolStripMenuItem
            // 
            this.LoadPharmacyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadPharmacyToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconLoadDataPharmacy;
            this.LoadPharmacyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadPharmacyToolStripMenuItem.Name = "LoadPharmacyToolStripMenuItem";
            this.LoadPharmacyToolStripMenuItem.Size = new System.Drawing.Size(294, 42);
            this.LoadPharmacyToolStripMenuItem.Text = "Данные об аптеках";
            this.LoadPharmacyToolStripMenuItem.Click += new System.EventHandler(this.LoadPharmacyToolStripMenuItem_Click);
            // 
            // LoadQuartetToolStripMenuItem
            // 
            this.LoadQuartetToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconLoadDataArea;
            this.LoadQuartetToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadQuartetToolStripMenuItem.Name = "LoadQuartetToolStripMenuItem";
            this.LoadQuartetToolStripMenuItem.Size = new System.Drawing.Size(294, 42);
            this.LoadQuartetToolStripMenuItem.Text = "Данные о кварталах и населении";
            this.LoadQuartetToolStripMenuItem.Click += new System.EventHandler(this.LoadQuartetToolStripMenuItem_Click);
            // 
            // InputTimeToolStripMenuItem
            // 
            this.InputTimeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputTimeToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconInputTime;
            this.InputTimeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InputTimeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InputTimeToolStripMenuItem.Name = "InputTimeToolStripMenuItem";
            this.InputTimeToolStripMenuItem.Size = new System.Drawing.Size(102, 71);
            this.InputTimeToolStripMenuItem.Text = "Задать время";
            this.InputTimeToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.InputTimeToolStripMenuItem.Click += new System.EventHandler(this.InputTimeToolStripMenuItem_Click);
            // 
            // InputOptionsToolStripMenuItem
            // 
            this.InputOptionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputOptionsToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconInputParametrs;
            this.InputOptionsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InputOptionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InputOptionsToolStripMenuItem.Name = "InputOptionsToolStripMenuItem";
            this.InputOptionsToolStripMenuItem.Size = new System.Drawing.Size(131, 71);
            this.InputOptionsToolStripMenuItem.Text = "Задать параметры";
            this.InputOptionsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.InputOptionsToolStripMenuItem.Click += new System.EventHandler(this.InputOptionsToolStripMenuItem_Click);
            // 
            // InputRadiusToolStripMenuItem
            // 
            this.InputRadiusToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputRadiusToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconLoadRadius;
            this.InputRadiusToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InputRadiusToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InputRadiusToolStripMenuItem.Name = "InputRadiusToolStripMenuItem";
            this.InputRadiusToolStripMenuItem.Size = new System.Drawing.Size(105, 71);
            this.InputRadiusToolStripMenuItem.Text = "Задать радиус";
            this.InputRadiusToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.InputRadiusToolStripMenuItem.Click += new System.EventHandler(this.InputRadiusToolStripMenuItem_Click);
            // 
            // SearchOptimumToolStripMenuItem
            // 
            this.SearchOptimumToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchOptimumToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconSearchOptimal;
            this.SearchOptimumToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SearchOptimumToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SearchOptimumToolStripMenuItem.Name = "SearchOptimumToolStripMenuItem";
            this.SearchOptimumToolStripMenuItem.Size = new System.Drawing.Size(118, 71);
            this.SearchOptimumToolStripMenuItem.Text = "Поиск оптимума";
            this.SearchOptimumToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SearchOptimumToolStripMenuItem.Click += new System.EventHandler(this.SearchOptimumToolStripMenuItem_Click);
            // 
            // LeaveOptimumToolStripMenuItem
            // 
            this.LeaveOptimumToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeaveOptimumToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconViewOptimal;
            this.LeaveOptimumToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LeaveOptimumToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LeaveOptimumToolStripMenuItem.Name = "LeaveOptimumToolStripMenuItem";
            this.LeaveOptimumToolStripMenuItem.Size = new System.Drawing.Size(134, 71);
            this.LeaveOptimumToolStripMenuItem.Text = "Убрать кандидатов";
            this.LeaveOptimumToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LeaveOptimumToolStripMenuItem.Click += new System.EventHandler(this.LeaveOptimumToolStripMenuItem_Click);
            // 
            // SaveOptimumToolStripMenuItem
            // 
            this.SaveOptimumToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconSaveOptimum;
            this.SaveOptimumToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveOptimumToolStripMenuItem.Name = "SaveOptimumToolStripMenuItem";
            this.SaveOptimumToolStripMenuItem.Size = new System.Drawing.Size(131, 71);
            this.SaveOptimumToolStripMenuItem.Text = "Сохранить оптимум";
            this.SaveOptimumToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveOptimumToolStripMenuItem.Click += new System.EventHandler(this.SaveOptimumToolStripMenuItem_Click);
            // 
            // SaveMapToolStripMenuItem
            // 
            this.SaveMapToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveMapToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconSaveMap;
            this.SaveMapToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SaveMapToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveMapToolStripMenuItem.Name = "SaveMapToolStripMenuItem";
            this.SaveMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMapToolStripMenuItem.Size = new System.Drawing.Size(119, 71);
            this.SaveMapToolStripMenuItem.Text = "Сохранить карту";
            this.SaveMapToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveMapToolStripMenuItem.Click += new System.EventHandler(this.SaveMapToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.HelpToolStripMenuItem.Image = global::OptimumPharmacy.Properties.Resources.iconPDF_v2;
            this.HelpToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.HelpToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(182, 71);
            this.HelpToolStripMenuItem.Text = "Руководство пользователя";
            this.HelpToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // radioButtonQuartetRetired
            // 
            this.radioButtonQuartetRetired.AutoSize = true;
            this.radioButtonQuartetRetired.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonQuartetRetired.Location = new System.Drawing.Point(6, 75);
            this.radioButtonQuartetRetired.Name = "radioButtonQuartetRetired";
            this.radioButtonQuartetRetired.Size = new System.Drawing.Size(117, 24);
            this.radioButtonQuartetRetired.TabIndex = 2;
            this.radioButtonQuartetRetired.Text = "Пенсионеры";
            this.toolTip.SetToolTip(this.radioButtonQuartetRetired, "Каждый квартал города будет визуализирован в определённый цвет в зависимости от к" +
        "оличества пенсионеров, проживающих в нём.\r\n");
            this.radioButtonQuartetRetired.UseVisualStyleBackColor = true;
            this.radioButtonQuartetRetired.CheckedChanged += new System.EventHandler(this.radioButtonQuartetRetired_CheckedChanged);
            this.radioButtonQuartetRetired.Click += new System.EventHandler(this.radioButtonQuartetRetired_Click);
            // 
            // radioButtonQuartetResidents
            // 
            this.radioButtonQuartetResidents.AutoSize = true;
            this.radioButtonQuartetResidents.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonQuartetResidents.Location = new System.Drawing.Point(6, 50);
            this.radioButtonQuartetResidents.Name = "radioButtonQuartetResidents";
            this.radioButtonQuartetResidents.Size = new System.Drawing.Size(80, 24);
            this.radioButtonQuartetResidents.TabIndex = 1;
            this.radioButtonQuartetResidents.Text = "Жители";
            this.toolTip.SetToolTip(this.radioButtonQuartetResidents, "Каждый квартал города будет визуализирован в определённый цвет в зависимости от к" +
        "оличества жителей, проживающих в нём.");
            this.radioButtonQuartetResidents.UseVisualStyleBackColor = true;
            this.radioButtonQuartetResidents.CheckedChanged += new System.EventHandler(this.radioButtonQuartetResidents_CheckedChanged);
            this.radioButtonQuartetResidents.Click += new System.EventHandler(this.radioButtonQuartetResidents_Click);
            // 
            // radioButtonQuartetPharmacy
            // 
            this.radioButtonQuartetPharmacy.AutoSize = true;
            this.radioButtonQuartetPharmacy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonQuartetPharmacy.Location = new System.Drawing.Point(6, 25);
            this.radioButtonQuartetPharmacy.Name = "radioButtonQuartetPharmacy";
            this.radioButtonQuartetPharmacy.Size = new System.Drawing.Size(76, 24);
            this.radioButtonQuartetPharmacy.TabIndex = 0;
            this.radioButtonQuartetPharmacy.Text = "Аптеки";
            this.toolTip.SetToolTip(this.radioButtonQuartetPharmacy, "Каждый квартал города будет визуализирован в определённый цвет в зависимости от к" +
        "оличества аптек, находящихся в нём.");
            this.radioButtonQuartetPharmacy.UseVisualStyleBackColor = true;
            this.radioButtonQuartetPharmacy.CheckedChanged += new System.EventHandler(this.radioButtonQuartetPharmacy_CheckedChanged);
            this.radioButtonQuartetPharmacy.Click += new System.EventHandler(this.radioButtonQuartetPharmacy_Click);
            // 
            // radioButtonQuartetClear
            // 
            this.radioButtonQuartetClear.AutoSize = true;
            this.radioButtonQuartetClear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonQuartetClear.Location = new System.Drawing.Point(6, 100);
            this.radioButtonQuartetClear.Name = "radioButtonQuartetClear";
            this.radioButtonQuartetClear.Size = new System.Drawing.Size(91, 24);
            this.radioButtonQuartetClear.TabIndex = 3;
            this.radioButtonQuartetClear.Text = "Очистить";
            this.toolTip.SetToolTip(this.radioButtonQuartetClear, "Убрать с карты визуализированные кварталы и скрыть легенду карты.");
            this.radioButtonQuartetClear.UseVisualStyleBackColor = true;
            this.radioButtonQuartetClear.Click += new System.EventHandler(this.radioButtonQuartetClear_Click);
            // 
            // radioButtonIconClear
            // 
            this.radioButtonIconClear.AutoSize = true;
            this.radioButtonIconClear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonIconClear.Location = new System.Drawing.Point(6, 100);
            this.radioButtonIconClear.Name = "radioButtonIconClear";
            this.radioButtonIconClear.Size = new System.Drawing.Size(91, 24);
            this.radioButtonIconClear.TabIndex = 3;
            this.radioButtonIconClear.Text = "Очистить";
            this.toolTip.SetToolTip(this.radioButtonIconClear, "Убрать с карты визуализацию кварталов при помощи значков.");
            this.radioButtonIconClear.UseVisualStyleBackColor = true;
            this.radioButtonIconClear.Click += new System.EventHandler(this.radioButtonIconClear_Click);
            // 
            // radioButtonIconPharmacy
            // 
            this.radioButtonIconPharmacy.AutoSize = true;
            this.radioButtonIconPharmacy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonIconPharmacy.Location = new System.Drawing.Point(6, 25);
            this.radioButtonIconPharmacy.Name = "radioButtonIconPharmacy";
            this.radioButtonIconPharmacy.Size = new System.Drawing.Size(76, 24);
            this.radioButtonIconPharmacy.TabIndex = 0;
            this.radioButtonIconPharmacy.Text = "Аптеки";
            this.toolTip.SetToolTip(this.radioButtonIconPharmacy, "Каждый квартал города получит значок определённого цвета в зависимости от количес" +
        "тва аптек, находящихся в нём.");
            this.radioButtonIconPharmacy.UseVisualStyleBackColor = true;
            this.radioButtonIconPharmacy.Click += new System.EventHandler(this.radioButtonIconPharmacy_Click);
            // 
            // radioButtonIconRetired
            // 
            this.radioButtonIconRetired.AutoSize = true;
            this.radioButtonIconRetired.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonIconRetired.Location = new System.Drawing.Point(6, 75);
            this.radioButtonIconRetired.Name = "radioButtonIconRetired";
            this.radioButtonIconRetired.Size = new System.Drawing.Size(117, 24);
            this.radioButtonIconRetired.TabIndex = 2;
            this.radioButtonIconRetired.Text = "Пенсионеры";
            this.toolTip.SetToolTip(this.radioButtonIconRetired, "Каждый квартал города получит значок определённого цвета в зависимости от количес" +
        "тва пенсионеров, проживающих в нём.\r\n");
            this.radioButtonIconRetired.UseVisualStyleBackColor = true;
            this.radioButtonIconRetired.Click += new System.EventHandler(this.radioButtonIconRetired_Click);
            // 
            // radioButtonIconResidents
            // 
            this.radioButtonIconResidents.AutoSize = true;
            this.radioButtonIconResidents.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonIconResidents.Location = new System.Drawing.Point(6, 50);
            this.radioButtonIconResidents.Name = "radioButtonIconResidents";
            this.radioButtonIconResidents.Size = new System.Drawing.Size(80, 24);
            this.radioButtonIconResidents.TabIndex = 1;
            this.radioButtonIconResidents.Text = "Жители";
            this.toolTip.SetToolTip(this.radioButtonIconResidents, "Каждый квартал города получит значок определённого цвета в зависимости от количес" +
        "тва жителей, проживающих в нём.");
            this.radioButtonIconResidents.UseVisualStyleBackColor = true;
            this.radioButtonIconResidents.Click += new System.EventHandler(this.radioButtonIconResidents_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // directorySearcher2
            // 
            this.directorySearcher2.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher2.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher2.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // groupBoxVisualCity
            // 
            this.groupBoxVisualCity.Controls.Add(this.radioButtonClearVisual);
            this.groupBoxVisualCity.Controls.Add(this.radioButtonCity);
            this.groupBoxVisualCity.Controls.Add(this.radioButtonDistrict);
            this.groupBoxVisualCity.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxVisualCity.Location = new System.Drawing.Point(12, 334);
            this.groupBoxVisualCity.Name = "groupBoxVisualCity";
            this.groupBoxVisualCity.Size = new System.Drawing.Size(179, 95);
            this.groupBoxVisualCity.TabIndex = 3;
            this.groupBoxVisualCity.TabStop = false;
            this.groupBoxVisualCity.Text = "Визуализация";
            // 
            // groupBoxColoringParameters
            // 
            this.groupBoxColoringParameters.Controls.Add(this.radioButtonQuartetRetired);
            this.groupBoxColoringParameters.Controls.Add(this.radioButtonQuartetResidents);
            this.groupBoxColoringParameters.Controls.Add(this.radioButtonQuartetPharmacy);
            this.groupBoxColoringParameters.Controls.Add(this.radioButtonQuartetClear);
            this.groupBoxColoringParameters.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxColoringParameters.Location = new System.Drawing.Point(12, 435);
            this.groupBoxColoringParameters.Name = "groupBoxColoringParameters";
            this.groupBoxColoringParameters.Size = new System.Drawing.Size(179, 133);
            this.groupBoxColoringParameters.TabIndex = 4;
            this.groupBoxColoringParameters.TabStop = false;
            this.groupBoxColoringParameters.Text = "Кварталы по параметру";
            // 
            // groupBoxColoringIcons
            // 
            this.groupBoxColoringIcons.Controls.Add(this.radioButtonIconClear);
            this.groupBoxColoringIcons.Controls.Add(this.radioButtonIconResidents);
            this.groupBoxColoringIcons.Controls.Add(this.radioButtonIconRetired);
            this.groupBoxColoringIcons.Controls.Add(this.radioButtonIconPharmacy);
            this.groupBoxColoringIcons.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxColoringIcons.Location = new System.Drawing.Point(12, 569);
            this.groupBoxColoringIcons.Name = "groupBoxColoringIcons";
            this.groupBoxColoringIcons.Size = new System.Drawing.Size(179, 130);
            this.groupBoxColoringIcons.TabIndex = 5;
            this.groupBoxColoringIcons.TabStop = false;
            this.groupBoxColoringIcons.Text = "Иконки по параметру";
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.BackColor = System.Drawing.Color.PeachPuff;
            this.labelDateTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateTime.Location = new System.Drawing.Point(986, 683);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(107, 20);
            this.labelDateTime.TabIndex = 11;
            this.labelDateTime.Text = "labelDateTime";
            // 
            // timerForDateTime
            // 
            this.timerForDateTime.Tick += new System.EventHandler(this.timerForDateTime_Tick);
            // 
            // groupBoxPharmacyInfo
            // 
            this.groupBoxPharmacyInfo.Controls.Add(this.radioButtonOnlyTimePharmacy);
            this.groupBoxPharmacyInfo.Controls.Add(this.radioButtonClearInfo);
            this.groupBoxPharmacyInfo.Controls.Add(this.radioButtonOnlyNamePharmacy);
            this.groupBoxPharmacyInfo.Controls.Add(this.radioButtonAllDataPharmacy);
            this.groupBoxPharmacyInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPharmacyInfo.Location = new System.Drawing.Point(12, 207);
            this.groupBoxPharmacyInfo.Name = "groupBoxPharmacyInfo";
            this.groupBoxPharmacyInfo.Size = new System.Drawing.Size(179, 125);
            this.groupBoxPharmacyInfo.TabIndex = 2;
            this.groupBoxPharmacyInfo.TabStop = false;
            this.groupBoxPharmacyInfo.Text = "Данные об аптеках";
            // 
            // radioButtonOnlyTimePharmacy
            // 
            this.radioButtonOnlyTimePharmacy.AutoSize = true;
            this.radioButtonOnlyTimePharmacy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonOnlyTimePharmacy.Location = new System.Drawing.Point(6, 70);
            this.radioButtonOnlyTimePharmacy.Name = "radioButtonOnlyTimePharmacy";
            this.radioButtonOnlyTimePharmacy.Size = new System.Drawing.Size(128, 24);
            this.radioButtonOnlyTimePharmacy.TabIndex = 2;
            this.radioButtonOnlyTimePharmacy.Text = "Время работы";
            this.toolTip.SetToolTip(this.radioButtonOnlyTimePharmacy, "При наведении на маркер аптеки будет появляться только время её работы.");
            this.radioButtonOnlyTimePharmacy.UseVisualStyleBackColor = true;
            this.radioButtonOnlyTimePharmacy.Click += new System.EventHandler(this.radioButtonOnlyTimePharmacy_Click);
            // 
            // radioButtonClearInfo
            // 
            this.radioButtonClearInfo.AutoSize = true;
            this.radioButtonClearInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonClearInfo.Location = new System.Drawing.Point(6, 95);
            this.radioButtonClearInfo.Name = "radioButtonClearInfo";
            this.radioButtonClearInfo.Size = new System.Drawing.Size(76, 24);
            this.radioButtonClearInfo.TabIndex = 3;
            this.radioButtonClearInfo.Text = "Убрать";
            this.toolTip.SetToolTip(this.radioButtonClearInfo, "Скрыть информацию, выводящуюся при наведении на маркер аптеки.");
            this.radioButtonClearInfo.UseVisualStyleBackColor = true;
            this.radioButtonClearInfo.Click += new System.EventHandler(this.radioButtonClearInfo_Click);
            // 
            // radioButtonOnlyNamePharmacy
            // 
            this.radioButtonOnlyNamePharmacy.AutoSize = true;
            this.radioButtonOnlyNamePharmacy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonOnlyNamePharmacy.Location = new System.Drawing.Point(6, 45);
            this.radioButtonOnlyNamePharmacy.Name = "radioButtonOnlyNamePharmacy";
            this.radioButtonOnlyNamePharmacy.Size = new System.Drawing.Size(146, 24);
            this.radioButtonOnlyNamePharmacy.TabIndex = 1;
            this.radioButtonOnlyNamePharmacy.Text = "Название аптеки";
            this.toolTip.SetToolTip(this.radioButtonOnlyNamePharmacy, "При наведении на маркер аптеки будет появляться только её название.");
            this.radioButtonOnlyNamePharmacy.UseVisualStyleBackColor = true;
            this.radioButtonOnlyNamePharmacy.Click += new System.EventHandler(this.radioButtonOnlyNamePharmacy_Click);
            // 
            // radioButtonAllDataPharmacy
            // 
            this.radioButtonAllDataPharmacy.AutoSize = true;
            this.radioButtonAllDataPharmacy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAllDataPharmacy.Location = new System.Drawing.Point(6, 20);
            this.radioButtonAllDataPharmacy.Name = "radioButtonAllDataPharmacy";
            this.radioButtonAllDataPharmacy.Size = new System.Drawing.Size(108, 24);
            this.radioButtonAllDataPharmacy.TabIndex = 0;
            this.radioButtonAllDataPharmacy.Text = "Все данные";
            this.toolTip.SetToolTip(this.radioButtonAllDataPharmacy, "При наведении на маркер аптеки будет появляться вся информация о ней.");
            this.radioButtonAllDataPharmacy.UseVisualStyleBackColor = true;
            this.radioButtonAllDataPharmacy.Click += new System.EventHandler(this.radioButtonAllDataPharmacy_Click);
            // 
            // groupBoxPharmacy
            // 
            this.groupBoxPharmacy.Controls.Add(this.radioButtonClearPharmacy);
            this.groupBoxPharmacy.Controls.Add(this.radioButtonLoadTime);
            this.groupBoxPharmacy.Controls.Add(this.radioButtonWorkNow);
            this.groupBoxPharmacy.Controls.Add(this.radioButtonAllPharmacy);
            this.groupBoxPharmacy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPharmacy.Location = new System.Drawing.Point(12, 78);
            this.groupBoxPharmacy.Name = "groupBoxPharmacy";
            this.groupBoxPharmacy.Size = new System.Drawing.Size(179, 127);
            this.groupBoxPharmacy.TabIndex = 1;
            this.groupBoxPharmacy.TabStop = false;
            this.groupBoxPharmacy.Text = "Отображение аптек";
            // 
            // radioButtonClearPharmacy
            // 
            this.radioButtonClearPharmacy.AutoSize = true;
            this.radioButtonClearPharmacy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonClearPharmacy.Location = new System.Drawing.Point(6, 95);
            this.radioButtonClearPharmacy.Name = "radioButtonClearPharmacy";
            this.radioButtonClearPharmacy.Size = new System.Drawing.Size(91, 24);
            this.radioButtonClearPharmacy.TabIndex = 3;
            this.radioButtonClearPharmacy.Text = "Очистить";
            this.toolTip.SetToolTip(this.radioButtonClearPharmacy, "Убрать маркеры аптек с карты.");
            this.radioButtonClearPharmacy.UseVisualStyleBackColor = true;
            this.radioButtonClearPharmacy.Click += new System.EventHandler(this.radioButtonClearPharmacy_Click);
            // 
            // radioButtonLoadTime
            // 
            this.radioButtonLoadTime.AutoSize = true;
            this.radioButtonLoadTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonLoadTime.Location = new System.Drawing.Point(6, 70);
            this.radioButtonLoadTime.Name = "radioButtonLoadTime";
            this.radioButtonLoadTime.Size = new System.Drawing.Size(160, 24);
            this.radioButtonLoadTime.TabIndex = 2;
            this.radioButtonLoadTime.Text = "В указанное время";
            this.toolTip.SetToolTip(this.radioButtonLoadTime, "Задайте время работы и на карте отобразятся аптеки, которые работают в указанное " +
        "время.");
            this.radioButtonLoadTime.UseVisualStyleBackColor = true;
            this.radioButtonLoadTime.Click += new System.EventHandler(this.radioButtonLoadTime_Click);
            // 
            // radioButtonWorkNow
            // 
            this.radioButtonWorkNow.AutoSize = true;
            this.radioButtonWorkNow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonWorkNow.Location = new System.Drawing.Point(6, 45);
            this.radioButtonWorkNow.Name = "radioButtonWorkNow";
            this.radioButtonWorkNow.Size = new System.Drawing.Size(167, 24);
            this.radioButtonWorkNow.TabIndex = 1;
            this.radioButtonWorkNow.Text = "Работающие сейчас";
            this.toolTip.SetToolTip(this.radioButtonWorkNow, "На карте отобразятся только аптеки, которые работают на данный момент.\r\nТекущее в" +
        "ремя определяется временем на компьютере.");
            this.radioButtonWorkNow.UseVisualStyleBackColor = true;
            this.radioButtonWorkNow.Click += new System.EventHandler(this.radioButtonWorkNow_Click);
            // 
            // radioButtonAllPharmacy
            // 
            this.radioButtonAllPharmacy.AutoSize = true;
            this.radioButtonAllPharmacy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAllPharmacy.Location = new System.Drawing.Point(6, 20);
            this.radioButtonAllPharmacy.Name = "radioButtonAllPharmacy";
            this.radioButtonAllPharmacy.Size = new System.Drawing.Size(102, 24);
            this.radioButtonAllPharmacy.TabIndex = 0;
            this.radioButtonAllPharmacy.Text = "Все аптеки";
            this.toolTip.SetToolTip(this.radioButtonAllPharmacy, "На карте отобразятся все аптеки города.");
            this.radioButtonAllPharmacy.UseVisualStyleBackColor = true;
            this.radioButtonAllPharmacy.Click += new System.EventHandler(this.radioButtonAllPharmacy_Click);
            // 
            // panelLegendMap
            // 
            this.panelLegendMap.Location = new System.Drawing.Point(6, 24);
            this.panelLegendMap.Name = "panelLegendMap";
            this.panelLegendMap.Size = new System.Drawing.Size(509, 65);
            this.panelLegendMap.TabIndex = 0;
            this.panelLegendMap.TabStop = true;
            this.panelLegendMap.Click += new System.EventHandler(this.panelLegendMap_Click);
            // 
            // groupBoxPanel
            // 
            this.groupBoxPanel.Controls.Add(this.panelLegendMap);
            this.groupBoxPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxPanel.Location = new System.Drawing.Point(203, 601);
            this.groupBoxPanel.Name = "groupBoxPanel";
            this.groupBoxPanel.Size = new System.Drawing.Size(526, 98);
            this.groupBoxPanel.TabIndex = 6;
            this.groupBoxPanel.TabStop = false;
            this.groupBoxPanel.Text = "Легенда карты";
            // 
            // panelLegend
            // 
            this.panelLegend.Controls.Add(this.labelFew);
            this.panelLegend.Controls.Add(this.labelMiddle);
            this.panelLegend.Controls.Add(this.labelLot);
            this.panelLegend.Controls.Add(this.labelUserMarker);
            this.panelLegend.Controls.Add(this.labelPharmacy);
            this.panelLegend.Controls.Add(this.labelLegendForMap);
            this.panelLegend.Controls.Add(this.pictureBoxPharmacy);
            this.panelLegend.Controls.Add(this.pictureBoxFew);
            this.panelLegend.Controls.Add(this.pictureBoxMarker);
            this.panelLegend.Controls.Add(this.pictureBoxMiddle);
            this.panelLegend.Controls.Add(this.pictureBoxLot);
            this.panelLegend.Location = new System.Drawing.Point(1163, 420);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(185, 175);
            this.panelLegend.TabIndex = 12;
            // 
            // labelFew
            // 
            this.labelFew.AutoSize = true;
            this.labelFew.BackColor = System.Drawing.Color.PeachPuff;
            this.labelFew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFew.Location = new System.Drawing.Point(36, 150);
            this.labelFew.Name = "labelFew";
            this.labelFew.Size = new System.Drawing.Size(42, 17);
            this.labelFew.TabIndex = 5;
            this.labelFew.Text = "Мало";
            // 
            // labelMiddle
            // 
            this.labelMiddle.AutoSize = true;
            this.labelMiddle.BackColor = System.Drawing.Color.PeachPuff;
            this.labelMiddle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMiddle.Location = new System.Drawing.Point(36, 120);
            this.labelMiddle.Name = "labelMiddle";
            this.labelMiddle.Size = new System.Drawing.Size(68, 17);
            this.labelMiddle.TabIndex = 4;
            this.labelMiddle.Text = "Умеренно";
            // 
            // labelLot
            // 
            this.labelLot.AutoSize = true;
            this.labelLot.BackColor = System.Drawing.Color.PeachPuff;
            this.labelLot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLot.Location = new System.Drawing.Point(36, 90);
            this.labelLot.Name = "labelLot";
            this.labelLot.Size = new System.Drawing.Size(48, 17);
            this.labelLot.TabIndex = 3;
            this.labelLot.Text = "Много";
            // 
            // labelUserMarker
            // 
            this.labelUserMarker.AutoSize = true;
            this.labelUserMarker.BackColor = System.Drawing.Color.PeachPuff;
            this.labelUserMarker.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserMarker.Location = new System.Drawing.Point(34, 32);
            this.labelUserMarker.Name = "labelUserMarker";
            this.labelUserMarker.Size = new System.Drawing.Size(101, 17);
            this.labelUserMarker.TabIndex = 1;
            this.labelUserMarker.Text = "Точка-кандидат";
            // 
            // labelPharmacy
            // 
            this.labelPharmacy.AutoSize = true;
            this.labelPharmacy.BackColor = System.Drawing.Color.PeachPuff;
            this.labelPharmacy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPharmacy.Location = new System.Drawing.Point(34, 60);
            this.labelPharmacy.Name = "labelPharmacy";
            this.labelPharmacy.Size = new System.Drawing.Size(48, 17);
            this.labelPharmacy.TabIndex = 2;
            this.labelPharmacy.Text = "Аптеки";
            // 
            // labelLegendForMap
            // 
            this.labelLegendForMap.AutoSize = true;
            this.labelLegendForMap.BackColor = System.Drawing.Color.PeachPuff;
            this.labelLegendForMap.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLegendForMap.Location = new System.Drawing.Point(3, 5);
            this.labelLegendForMap.Name = "labelLegendForMap";
            this.labelLegendForMap.Size = new System.Drawing.Size(180, 17);
            this.labelLegendForMap.TabIndex = 0;
            this.labelLegendForMap.Text = "УСЛОВНЫЕ ОБОЗНАЧЕНИЯ";
            // 
            // pictureBoxPharmacy
            // 
            this.pictureBoxPharmacy.Image = global::OptimumPharmacy.Properties.Resources.iconPharmacy;
            this.pictureBoxPharmacy.Location = new System.Drawing.Point(5, 55);
            this.pictureBoxPharmacy.Name = "pictureBoxPharmacy";
            this.pictureBoxPharmacy.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxPharmacy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPharmacy.TabIndex = 99;
            this.pictureBoxPharmacy.TabStop = false;
            // 
            // pictureBoxFew
            // 
            this.pictureBoxFew.Image = global::OptimumPharmacy.Properties.Resources.icon_few;
            this.pictureBoxFew.Location = new System.Drawing.Point(5, 145);
            this.pictureBoxFew.Name = "pictureBoxFew";
            this.pictureBoxFew.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxFew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFew.TabIndex = 103;
            this.pictureBoxFew.TabStop = false;
            // 
            // pictureBoxMarker
            // 
            this.pictureBoxMarker.Image = global::OptimumPharmacy.Properties.Resources.iconUserPharma1;
            this.pictureBoxMarker.Location = new System.Drawing.Point(5, 25);
            this.pictureBoxMarker.Name = "pictureBoxMarker";
            this.pictureBoxMarker.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxMarker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMarker.TabIndex = 100;
            this.pictureBoxMarker.TabStop = false;
            // 
            // pictureBoxMiddle
            // 
            this.pictureBoxMiddle.Image = global::OptimumPharmacy.Properties.Resources.icon_middle;
            this.pictureBoxMiddle.Location = new System.Drawing.Point(5, 115);
            this.pictureBoxMiddle.Name = "pictureBoxMiddle";
            this.pictureBoxMiddle.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxMiddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMiddle.TabIndex = 102;
            this.pictureBoxMiddle.TabStop = false;
            // 
            // pictureBoxLot
            // 
            this.pictureBoxLot.Image = global::OptimumPharmacy.Properties.Resources.icon_lot;
            this.pictureBoxLot.Location = new System.Drawing.Point(5, 85);
            this.pictureBoxLot.Name = "pictureBoxLot";
            this.pictureBoxLot.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxLot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLot.TabIndex = 101;
            this.pictureBoxLot.TabStop = false;
            // 
            // trackBarIntensity
            // 
            this.trackBarIntensity.BackColor = System.Drawing.Color.PeachPuff;
            this.trackBarIntensity.Location = new System.Drawing.Point(1048, 635);
            this.trackBarIntensity.Name = "trackBarIntensity";
            this.trackBarIntensity.Size = new System.Drawing.Size(300, 45);
            this.trackBarIntensity.TabIndex = 10;
            this.trackBarIntensity.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarIntensity.Scroll += new System.EventHandler(this.trackBarIntensity_Scroll);
            // 
            // trackBarTransparent
            // 
            this.trackBarTransparent.BackColor = System.Drawing.Color.PeachPuff;
            this.trackBarTransparent.Location = new System.Drawing.Point(735, 635);
            this.trackBarTransparent.Name = "trackBarTransparent";
            this.trackBarTransparent.Size = new System.Drawing.Size(300, 45);
            this.trackBarTransparent.TabIndex = 8;
            this.trackBarTransparent.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarTransparent.Scroll += new System.EventHandler(this.trackBarTransparent_Scroll);
            // 
            // label_Transparent
            // 
            this.label_Transparent.AutoSize = true;
            this.label_Transparent.BackColor = System.Drawing.Color.PeachPuff;
            this.label_Transparent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Transparent.Location = new System.Drawing.Point(731, 611);
            this.label_Transparent.Name = "label_Transparent";
            this.label_Transparent.Size = new System.Drawing.Size(289, 21);
            this.label_Transparent.TabIndex = 7;
            this.label_Transparent.Text = "Изменение прозрачности раскраски";
            // 
            // label_Intensity
            // 
            this.label_Intensity.AutoSize = true;
            this.label_Intensity.BackColor = System.Drawing.Color.PeachPuff;
            this.label_Intensity.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Intensity.Location = new System.Drawing.Point(1046, 611);
            this.label_Intensity.Name = "label_Intensity";
            this.label_Intensity.Size = new System.Drawing.Size(228, 21);
            this.label_Intensity.TabIndex = 9;
            this.label_Intensity.Text = "Изменение толщины границ";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Подсказка";
            // 
            // MainMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1358, 712);
            this.Controls.Add(this.label_Intensity);
            this.Controls.Add(this.label_Transparent);
            this.Controls.Add(this.trackBarTransparent);
            this.Controls.Add(this.trackBarIntensity);
            this.Controls.Add(this.panelLegend);
            this.Controls.Add(this.groupBoxPharmacy);
            this.Controls.Add(this.groupBoxVisualCity);
            this.Controls.Add(this.groupBoxPanel);
            this.Controls.Add(this.groupBoxPharmacyInfo);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.groupBoxColoringIcons);
            this.Controls.Add(this.groupBoxColoringParameters);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.gmap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1374, 751);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "MainMap";
            this.Text = "Оптимум. Аптеки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Map_FormClosing);
            this.Load += new System.EventHandler(this.Map_Load);
            this.SizeChanged += new System.EventHandler(this.MainMap_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMap_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxVisualCity.ResumeLayout(false);
            this.groupBoxVisualCity.PerformLayout();
            this.groupBoxColoringParameters.ResumeLayout(false);
            this.groupBoxColoringParameters.PerformLayout();
            this.groupBoxColoringIcons.ResumeLayout(false);
            this.groupBoxColoringIcons.PerformLayout();
            this.groupBoxPharmacyInfo.ResumeLayout(false);
            this.groupBoxPharmacyInfo.PerformLayout();
            this.groupBoxPharmacy.ResumeLayout(false);
            this.groupBoxPharmacy.PerformLayout();
            this.groupBoxPanel.ResumeLayout(false);
            this.panelLegend.ResumeLayout(false);
            this.panelLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPharmacy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMarker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.RadioButton radioButtonCity;
        private System.Windows.Forms.RadioButton radioButtonDistrict;
        private System.Windows.Forms.RadioButton radioButtonClearVisual;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.RadioButton radioButtonQuartetRetired;
        private System.Windows.Forms.RadioButton radioButtonQuartetResidents;
        private System.Windows.Forms.RadioButton radioButtonQuartetPharmacy;
        private System.Windows.Forms.RadioButton radioButtonQuartetClear;
        private System.Windows.Forms.RadioButton radioButtonIconClear;
        private System.Windows.Forms.RadioButton radioButtonIconPharmacy;
        private System.Windows.Forms.RadioButton radioButtonIconRetired;
        private System.Windows.Forms.RadioButton radioButtonIconResidents;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.DirectoryServices.DirectorySearcher directorySearcher2;
        private System.Windows.Forms.GroupBox groupBoxVisualCity;
        private System.Windows.Forms.GroupBox groupBoxColoringParameters;
        private System.Windows.Forms.GroupBox groupBoxColoringIcons;
        private System.Windows.Forms.ToolStripMenuItem LoadFileToolStripMenuItem;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Timer timerForDateTime;
        private System.Windows.Forms.ToolStripMenuItem InputTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InputOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchOptimumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LeaveOptimumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadPharmacyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadQuartetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IconPharmacyToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxPharmacyInfo;
        private System.Windows.Forms.RadioButton radioButtonOnlyNamePharmacy;
        private System.Windows.Forms.RadioButton radioButtonAllDataPharmacy;
        private System.Windows.Forms.ToolStripMenuItem InputRadiusToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonClearInfo;
        private System.Windows.Forms.RadioButton radioButtonOnlyTimePharmacy;
        private System.Windows.Forms.GroupBox groupBoxPharmacy;
        private System.Windows.Forms.RadioButton radioButtonWorkNow;
        private System.Windows.Forms.RadioButton radioButtonAllPharmacy;
        private System.Windows.Forms.Panel panelLegendMap;
        private System.Windows.Forms.GroupBox groupBoxPanel;
        private System.Windows.Forms.PictureBox pictureBoxPharmacy;
        private System.Windows.Forms.PictureBox pictureBoxMarker;
        private System.Windows.Forms.PictureBox pictureBoxLot;
        private System.Windows.Forms.PictureBox pictureBoxMiddle;
        private System.Windows.Forms.PictureBox pictureBoxFew;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Label labelLegendForMap;
        private System.Windows.Forms.Label labelFew;
        private System.Windows.Forms.Label labelMiddle;
        private System.Windows.Forms.Label labelLot;
        private System.Windows.Forms.Label labelUserMarker;
        private System.Windows.Forms.Label labelPharmacy;
        private System.Windows.Forms.TrackBar trackBarIntensity;
        private System.Windows.Forms.TrackBar trackBarTransparent;
        private System.Windows.Forms.Label label_Transparent;
        private System.Windows.Forms.Label label_Intensity;
        private System.Windows.Forms.RadioButton radioButtonClearPharmacy;
        private System.Windows.Forms.ToolStripMenuItem SaveOptimumToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.RadioButton radioButtonLoadTime;
    }
}

