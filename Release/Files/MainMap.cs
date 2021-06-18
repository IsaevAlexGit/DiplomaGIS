using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace OptimumPharmacy
{
    public partial class MainMap : Form
    {
        private LanguageType _languageOfMap;

        /// <summary>
        /// Инициализация формы
        /// </summary>
        /// <param name="language">Язык карты</param>
        public MainMap(LanguageType language)
        {
            _languageOfMap = language;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
        }

        private MapModel _mapModel;
        private MapView _mapView;

        /// <summary>
        /// Загрузка карты
        /// </summary>
        private void gMapControl_Load(object sender, EventArgs e)
        {
            // Инициализация данных и настройка карты
            _mapModel = new MapModel();
            _mapView = new MapView(_mapModel);
            _mapView.InitGMapControl(gmap);
            GMapProvider.Language = _languageOfMap;

            // Контекстное меню для выбора поставщика карты
            ToolStripMenuItem YandexMenuItem = new ToolStripMenuItem("Установить Яндекс-карту");
            ToolStripMenuItem GoogleMenuItem = new ToolStripMenuItem("Установить Google-карту");
            ToolStripMenuItem OpenCycleMapMenuItem = new ToolStripMenuItem("Установить OpenCycleMap-карту");
            ToolStripMenuItem BingHybridMapMenuItem = new ToolStripMenuItem("Установить BingHybridMap-карту");
            ToolStripMenuItem YandexHybridMapMenuItem = new ToolStripMenuItem("Установить YandexHybridMap-карту");
            ToolStripMenuItem ArcGISMenuItem = new ToolStripMenuItem("Установить ArcGIS-карту");
            ToolStripMenuItem WikiMapiaMapMenuItem = new ToolStripMenuItem("Установить WikiMapiaMap-карту");

            // Инициализация контестного меню в зависимости от выбранного языка
            if (_languageOfMap == LanguageType.English)
                contextMenu.Items.AddRange(new[] { YandexMenuItem, GoogleMenuItem, BingHybridMapMenuItem,
                    YandexHybridMapMenuItem, ArcGISMenuItem, WikiMapiaMapMenuItem });
            else
                contextMenu.Items.AddRange(new[] { YandexMenuItem, GoogleMenuItem, OpenCycleMapMenuItem, YandexHybridMapMenuItem });

            gmap.ContextMenuStrip = contextMenu;

            YandexMenuItem.Click += YandexMenuItem_Click;
            GoogleMenuItem.Click += GoogleMenuItem_Click;
            OpenCycleMapMenuItem.Click += OpenCycleMapMenuItem_Click;
            BingHybridMapMenuItem.Click += BingHybridMapMenuItem_Click;
            YandexHybridMapMenuItem.Click += YandexHybridMapMenuItem_Click;
            WikiMapiaMapMenuItem.Click += WikiMapiaMapMenuItem_Click;
            ArcGISMenuItem.Click += ArcGISMenuItem_Click;
        }

        // Отрисовка границ groupbox
        private PaintGroupBoxBorder _paintGroupBoxBorder = new PaintGroupBoxBorder();
        // Слой для кварталов
        private SublayerQuartet _sublayerQuartet;
        // Слой для маркеров пользователя
        private SublayerLocation _sublayerUser;
        // Работа с файлом
        private FileValidator _fileValidator;
        // Цвет раскраски кварталов
        private Color _colorForColoring;

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void Map_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1374, 751);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            _sublayerQuartet = _mapModel.sublayerQuartetPolygon;
            _sublayerUser = _mapModel.sublayerUserPharmacy;
            _fileValidator = new FileValidator();

            // Начальный цвет раскраски (зеленый)
            _colorForColoring = Color.FromArgb(255, 0, 255, 0);

            // Скрыть элементы раскраски
            _DisplayLegendElements(false);

            // Минимум и максимум толщины границ
            trackBarIntensity.Minimum = 0;
            trackBarIntensity.Maximum = 3;
            trackBarIntensity.Value = 1;

            // Минимум и максимум прозрачности раскраски
            trackBarTransparent.Minimum = 0;
            trackBarTransparent.Maximum = 5;
            trackBarTransparent.Value = 5;

            // Наполнение условных обозначений
            pictureBoxPharmacy.Image = Properties.Resources.iconPharmacy;
            pictureBoxMarker.Image = Properties.Resources.iconUserPharma;
            pictureBoxLot.Image = Properties.Resources.icon_lot;
            pictureBoxMiddle.Image = Properties.Resources.icon_middle;
            pictureBoxFew.Image = Properties.Resources.icon_few;
            WindowState = FormWindowState.Maximized;

            // Запуск таймера для вывода даты и времени
            timerForDateTime.Start();

            // Отрисовка границ groupbox
            foreach (Control groupbox in Controls)
            {
                GroupBox everyGroupBox = groupbox as GroupBox;
                if (everyGroupBox != null)
                    everyGroupBox.Paint += _paintGroupBoxBorder.groupBox_Paint;
            }

            // Начальная установка переключателей
            radioButtonAllPharmacy.Checked = true;
            radioButtonClearPharmacy_Click(sender, e);
            radioButtonOnlyNamePharmacy.Checked = true;
            radioButtonOnlyNamePharmacy_Click(sender, e);
            radioButtonClearVisual.Checked = true;
            radioButtonClearVisual_Click(sender, e);
            radioButtonQuartetClear.Checked = true;
            radioButtonQuartetClear_Click(sender, e);
            radioButtonIconClear.Checked = true;
            radioButtonIconClear_Click(sender, e);
        }

        /// <summary>
        /// Обработка щелчка по маркеру
        /// </summary>
        /// <param name="item">Маркер</param>
        /// <param name="e">Кнопка, которой сделали щелчок</param>
        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            // Если нажали левой кнопкой мыши
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < _mapModel.listPointsPharmacy.Count; i++)
                {
                    // Если координаты выбранной совпали с одной точкой из списка
                    if (item.Position.Lat == _mapModel.listPointsPharmacy[i].x && item.Position.Lng == _mapModel.listPointsPharmacy[i].y)
                    {
                        PharmacyInfo form = new PharmacyInfo(_mapModel.listPointsPharmacy[i]);
                        form.ShowDialog();
                    }
                }
            }
            // Если нажали колесиком мыши
            if (e.Button == MouseButtons.Middle)
            {
                // Координаты маркера
                double roundX_Location;
                double roundY_Location;
                // Координаты оптимальной точки
                double roundX_Optimal = Math.Round(_mapModel.optimalPoint.x, 6);
                double roundY_Optimal = Math.Round(_mapModel.optimalPoint.y, 6);

                for (int i = 0; i < _sublayerUser.listWithLocation.Count; i++)
                {
                    // Если координаты выбранной совпали с одной точкой из списка
                    if (item.Position.Lat == _sublayerUser.listWithLocation[i].x && item.Position.Lng == _sublayerUser.listWithLocation[i].y)
                    {
                        // Координаты текущей точки
                        roundX_Location = Math.Round(item.Position.Lat, 6);
                        roundY_Location = Math.Round(item.Position.Lng, 6);
                        // Удаление маркера, который был оптимальным
                        if (roundX_Optimal == roundX_Location && roundY_Optimal == roundY_Location)
                        {
                            // Убрать данный маркер с карты
                            _sublayerUser.listWithLocation.Remove(_sublayerUser.listWithLocation[i]);
                            // Перерисовать все маркеры на карте
                            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
                            // Обнулить оптимальную точку
                            _mapModel.optimalPoint.idBufferZone = 0;
                        }
                        // Удаление неоптимальной точки
                        else
                        {
                            _sublayerUser.listWithLocation.Remove(_sublayerUser.listWithLocation[i]);
                            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Перерисовать всю карту
        /// </summary>
        private void _RedrawMap(object sender, EventArgs e)
        {
            // Перерисовать на карте аптеки
            if (radioButtonAllPharmacy.Checked)
            {
                radioButtonClearPharmacy_Click(sender, e);
                radioButtonAllPharmacy_Click(sender, e);
            }
            if (radioButtonWorkNow.Checked)
            {
                radioButtonClearPharmacy_Click(sender, e);
                radioButtonWorkNow_Click(sender, e);
            }
            if (radioButtonLoadTime.Checked)
            {
                radioButtonClearPharmacy_Click(sender, e);
                radioButtonLoadTime_Click(sender, e);
            }

            // Перерисовать на карте кварталы
            if (radioButtonQuartetResidents.Checked)
                radioButtonQuartetResidents_CheckedChanged(sender, e);
            else if (radioButtonQuartetRetired.Checked)
                radioButtonQuartetRetired_CheckedChanged(sender, e);
            else
                radioButtonQuartetPharmacy_CheckedChanged(sender, e);
        }

        /// <summary>
        /// Обработка смены карты на YandexMap
        /// </summary>
        private void YandexMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.YandexMap;
            _RedrawMap(sender, e);
        }

        /// <summary>
        /// Обработка смены карты на GoogleMap
        /// </summary>
        private void GoogleMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.GoogleMap;
            _RedrawMap(sender, e);
        }

        /// <summary>
        /// Обработка смены карты на OpenCycleMap
        /// </summary>
        private void OpenCycleMapMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.OpenCycleMap;
            _RedrawMap(sender, e);
        }

        /// <summary>
        /// Обработка смены карты на BingHybridMap
        /// </summary>
        private void BingHybridMapMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.BingHybridMap;
            _RedrawMap(sender, e);
        }

        /// <summary>
        /// Обработка смены карты на YandexHybridMap
        /// </summary>
        private void YandexHybridMapMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.YandexHybridMap;
            _RedrawMap(sender, e);
        }

        /// <summary>
        /// Обработка смены карты на ArcGIS_World_Topo_Map
        /// </summary>
        private void ArcGISMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.ArcGIS_World_Topo_Map;
            _RedrawMap(sender, e);
        }

        /// <summary>
        /// Обработка смены карты на WikiMapiaMap
        /// </summary>
        private void WikiMapiaMapMenuItem_Click(object sender, EventArgs e)
        {
            gmap.MapProvider = GMapProviders.WikiMapiaMap;
            _RedrawMap(sender, e);
        }

        /// <summary>
        /// Отображение всех аптек
        /// </summary>
        private void radioButtonAllPharmacy_Click(object sender, EventArgs e)
        {
            _mapView.DrawPharmacy();
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Отображение аптек, которые работают сейчас
        /// </summary>
        private void radioButtonWorkNow_Click(object sender, EventArgs e)
        {
            _mapView.DrawWorkNowPharmacy();
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Отображение аптек, которые работают в указанное время
        /// </summary>
        private void radioButtonLoadTime_Click(object sender, EventArgs e)
        {
            // Если на форме ввели время работы
            if (_workTimePharmacy != -100)
            {
                // Оставить только работающие в заданное время аптеки
                _mapView.DrawWorkLoadTimePharmacy(_workTimePharmacy);
                _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
            }
            else
            {
                radioButtonLoadTime.Checked = false;
                MessageBox.Show("Задайте время для поиска", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                radioButtonClearPharmacy.Checked = true;
                radioButtonClearPharmacy_Click(sender, e);
            }
        }

        // Введенное время работы аптеки
        private double _workTimePharmacy = -100;
        private bool _flagExitFormLoadTime = false;
        /// <summary>
        /// Открытие формы для задания времени работы аптеки
        /// </summary>
        private void InputTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingTime form = new SettingTime();
            form.ShowDialog();
            // Получение времени, введенного на форме
            _workTimePharmacy = form.workTimePharmacy;
            _flagExitFormLoadTime = form.exitForm;
            if (_flagExitFormLoadTime)
            {
                radioButtonLoadTime.Checked = true;
                radioButtonLoadTime_Click(sender, e);
            }
        }

        /// <summary>
        /// Отключение отображения аптек на карте
        /// </summary>
        private void radioButtonClearPharmacy_Click(object sender, EventArgs e)
        {
            _mapView.ClearPharmacy();
        }

        /// <summary>
        /// Отображение полной информации аптеки при наведении на маркер
        /// </summary>
        private void radioButtonAllDataPharmacy_Click(object sender, EventArgs e)
        {
            _mapView.SetTextForPharmacy(2);
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
        }

        /// <summary>
        /// Отображение только названия аптеки при наведении на маркер
        /// </summary>
        private void radioButtonOnlyNamePharmacy_Click(object sender, EventArgs e)
        {
            _mapView.SetTextForPharmacy(3);
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
        }

        /// <summary>
        /// Отображение только времени работы аптеки при наведении на маркер
        /// </summary>
        private void radioButtonOnlyTimePharmacy_Click(object sender, EventArgs e)
        {
            _mapView.SetTextForPharmacy(4);
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
        }

        /// <summary>
        /// Отключение выводимой информации аптеки при наведении на маркер
        /// </summary>
        private void radioButtonClearInfo_Click(object sender, EventArgs e)
        {
            _mapView.SetTextForPharmacy(5);
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
        }

        /// <summary>
        /// Определить, какой переключать для аптек выбран
        /// </summary>
        private void _CheckSelectedRadioButtonForMarkersPharmacy(object sender, EventArgs e)
        {
            if (radioButtonAllPharmacy.Checked)
                radioButtonAllPharmacy_Click(sender, e);
            else if (radioButtonWorkNow.Checked)
                radioButtonWorkNow_Click(sender, e);
            else if (radioButtonLoadTime.Checked)
                radioButtonLoadTime_Click(sender, e);
            else
                radioButtonClearPharmacy_Click(sender, e);
        }

        /// <summary>
        /// Отображение визуализации города
        /// </summary>
        private void radioButtonCity_Click(object sender, EventArgs e)
        {
            _mapView.DrawCity();
            _RedrawMap(sender, e);
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Отображение визуализации районов города
        /// </summary>
        private void radioButtonDistrict_Click(object sender, EventArgs e)
        {
            _mapView.DrawDistricts();
            _RedrawMap(sender, e);
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Отключение отображения визуализации города
        /// </summary>
        private void radioButtonClearVisual_Click(object sender, EventArgs e)
        {
            _mapView.ClearDistricts();
        }

        /// <summary>
        /// Изменеие отображения легенды карты
        /// </summary>
        /// <param name="_modeDisplay">флаг отображения</param>
        private void _DisplayLegendElements(bool _modeDisplay)
        {
            groupBoxPanel.Visible = _modeDisplay;
            label_Transparent.Visible = _modeDisplay;
            label_Intensity.Visible = _modeDisplay;
            trackBarIntensity.Visible = _modeDisplay;
            trackBarTransparent.Visible = _modeDisplay;
        }

        /// <summary>
        /// Отображение раскраски кварталов по аптекам
        /// </summary>
        private void radioButtonQuartetPharmacy_Click(object sender, EventArgs e)
        {
            // Установить режим раскраски по аптекам
            _mapModel.modeColorCoding = 1;
            // Включить элементы легенды карты
            _DisplayLegendElements(true);
            // Перерисовать панель
            panelLegendMap.Refresh();
            // Отобразить раскраску
            _DrawPolygonForQuartet();
            // Перерисовать аптеки
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            // Перерисовать кварталы
            _CheckSelectedRadioButtonForIconQuartet(sender, e);
            // Перерисовать буферные зоны
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Отображение раскраски кварталов по жителям
        /// </summary>
        private void radioButtonQuartetResidents_Click(object sender, EventArgs e)
        {
            // Установить режим раскраски по жителям
            _mapModel.modeColorCoding = 2;
            // Включить элементы легенды карты
            _DisplayLegendElements(true);
            // Перерисовать панель
            panelLegendMap.Refresh();
            // Отобразить раскраску
            _DrawPolygonForQuartet();
            // Перерисовать аптеки
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            // Перерисовать кварталы
            _CheckSelectedRadioButtonForIconQuartet(sender, e);
            // Перерисовать буферные зоны
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Отображение раскраски кварталов по пенсионерам
        /// </summary>
        private void radioButtonQuartetRetired_Click(object sender, EventArgs e)
        {
            // Установить режим раскраски по пенсионерам
            _mapModel.modeColorCoding = 3;
            // Включить элементы легенды карты
            _DisplayLegendElements(true);
            // Перерисовать панель
            panelLegendMap.Refresh();
            // Отобразить раскраску
            _DrawPolygonForQuartet();
            // Перерисовать аптеки
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            // Перерисовать кварталы
            _CheckSelectedRadioButtonForIconQuartet(sender, e);
            // Перерисовать буферные зоны
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Отключение отображения раскраски кварталов
        /// </summary>
        private void radioButtonQuartetClear_Click(object sender, EventArgs e)
        {
            _mapView.ClearPolygonQuartet(_sublayerQuartet);
            _DisplayLegendElements(false);
        }

        /// <summary>
        /// Обработка щелчка по легенде карты
        /// </summary>
        private void panelLegendMap_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Сохранение выбранного цвета
                _colorForColoring = colorDialog.Color;
                // Перерисовать кварталы с новым выбранным цветом
                if (radioButtonQuartetResidents.Checked)
                    radioButtonQuartetResidents_CheckedChanged(sender, e);
                else if (radioButtonQuartetRetired.Checked)
                    radioButtonQuartetRetired_CheckedChanged(sender, e);
                else
                    radioButtonQuartetPharmacy_CheckedChanged(sender, e);
            }
        }

        /// <summary>
        /// Перерисовка раскраски кварталов по аптекам
        /// </summary>
        private void radioButtonQuartetPharmacy_CheckedChanged(object sender, EventArgs e)
        {
            _mapModel.modeColorCoding = 1;
            panelLegendMap.Show();
            panelLegendMap.Refresh();
            if (radioButtonQuartetPharmacy.Checked == true)
                _DrawPolygonForQuartet();
            gmap.Refresh();
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            _CheckSelectedRadioButtonForIconQuartet(sender, e);
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Перерисовка раскраски кварталов по жителям
        /// </summary>
        private void radioButtonQuartetResidents_CheckedChanged(object sender, EventArgs e)
        {
            _mapModel.modeColorCoding = 2;
            panelLegendMap.Show();
            panelLegendMap.Refresh();
            if (radioButtonQuartetResidents.Checked == true)
                _DrawPolygonForQuartet();
            gmap.Refresh();
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            _CheckSelectedRadioButtonForIconQuartet(sender, e);
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Перерисовка раскраски кварталов по пенсионерам
        /// </summary>
        private void radioButtonQuartetRetired_CheckedChanged(object sender, EventArgs e)
        {
            _mapModel.modeColorCoding = 3;
            panelLegendMap.Show();
            panelLegendMap.Refresh();
            if (radioButtonQuartetRetired.Checked == true)
                _DrawPolygonForQuartet();
            gmap.Refresh();
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            _CheckSelectedRadioButtonForIconQuartet(sender, e);
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        // Отрисовка границ
        private Pen _penBoundary;
        // Начальная толщина границ
        private int _intensity = 1;
        // Начальная прозрачность полигонов
        private int _transparent = 255;

        /// <summary>
        /// Отрисовка кварталов
        /// </summary>
        private void _DrawPolygonForQuartet()
        {
            /// Установка толщины границ
            if (_intensity >= 1)
                _penBoundary = new Pen(Color.FromArgb(255, 255, 0, 0), _intensity);
            else
                _penBoundary = new Pen(Color.FromArgb(0, 0, 0, 0), 0);

            // Удаление слоя
            _sublayerQuartet.overlay.Polygons.Clear();
            _sublayerQuartet.overlay.Markers.Clear();
            gmap.Overlays.Remove(_sublayerQuartet.overlay);
            _sublayerQuartet.overlay.Clear();

            // Заполнение таблицы данными из списка с кварталами
            DataTable dataquartets = _mapModel.CreateTableFromQuartets();
            int countOfQuartets = dataquartets.Rows.Count;

            // Для каждого квартала создается список граничных точек этого квартала
            List<PointLatLng>[] listBoundaryForEveryQuartet = new List<PointLatLng>[countOfQuartets];
            for (int i = 0; i < listBoundaryForEveryQuartet.Length; i++)
                listBoundaryForEveryQuartet[i] = new List<PointLatLng>();

            // Получить минимум, максимум для раскраски, количество оттенков, а также массив оттенков выбранного цвета
            _Legend(out Color[] colorPolygon, out double min, out double max, out int grids, out double step);

            for (int j = 0; j < countOfQuartets; j++)
            {
                _mapModel.tempListForQuartet = new List<PointLatLng>();
                for (int k = 0; k < _sublayerQuartet.listWithQuartets[j].listBoundaryPoints.Count; k++)
                {
                    Location tempLocation = new Location(_sublayerQuartet.listWithQuartets[j].listBoundaryPoints[k].x,
                        _sublayerQuartet.listWithQuartets[j].listBoundaryPoints[k].y);
                    PointLatLng tempLocationForPolygon = new PointLatLng(tempLocation.x, tempLocation.y);
                    _mapModel.tempListForQuartet.Add(tempLocationForPolygon);
                }
                listBoundaryForEveryQuartet[j] = _mapModel.tempListForQuartet;
            }

            for (int j = 0; j < countOfQuartets; j++)
            {
                // Создание полигона для квартала
                var mapPolygon = new GMapPolygon(listBoundaryForEveryQuartet[j], "Quartet" + j.ToString());
                // Установка толщины границ у квартала
                mapPolygon.Stroke = _penBoundary;
                // Определение оттенка, в который необходимо окрасить квартал
                int ShadeNumber = 0;
                if (_mapModel.modeColorCoding == 1)
                    ShadeNumber = _mapModel.GetnumberShade(Convert.ToDouble(dataquartets.Rows[j][5]), min, max, grids, step);
                else if (_mapModel.modeColorCoding == 2)
                    ShadeNumber = _mapModel.GetnumberShade(Convert.ToDouble(dataquartets.Rows[j][6]), min, max, grids, step);
                else
                    ShadeNumber = _mapModel.GetnumberShade(Convert.ToDouble(dataquartets.Rows[j][7]), min, max, grids, step);

                // Заливка полигона определенным цветом
                mapPolygon.Fill = new SolidBrush(colorPolygon[ShadeNumber]);
                // Добавление на слой квартала
                _sublayerQuartet.overlay.Polygons.Add(mapPolygon);
            }
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerQuartet.overlay);
            _sublayerQuartet.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Легенда карты
        /// </summary>
        /// <param name="colorPolygon">Массив оттенков определенного цвета</param>
        /// <param name="min">Минимум для раскраски</param>
        /// <param name="max">Максимум для раскраски</param>
        /// <param name="grids">Количество оттенков</param>
        /// <param name="step">Интервал каждого оттенка</param>
        private void _Legend(out Color[] colorPolygon, out double minValueColoring,
            out double maxValueColoring, out int countOfGrids, out double countOfSteps)
        {
            countOfGrids = 0;
            minValueColoring = 0;
            maxValueColoring = 0;

            // Временные переменные для работы с цветом
            int red, green, blue;
            int hred, hgreen, hblue;

            // Первым будет всегда белый цвет у минимума
            // От RGB белого цвета будет вычитаться RGB выбранного цвета, чтобы получить оттенки
            Color tempColor = Color.FromArgb(255, 255, 255, 255);
            // Ободок прямоугольников у оттенков
            Pen penBoundaryOfRectangle = new Pen(Color.Black, 0.002f);

            // Получение минимума, максимума и количества оттенков для выбранной раскраски
            if (_mapModel.modeColorCoding == 1)
            {
                countOfGrids = _mapModel.numberOfShadesPharmacy;
                minValueColoring = _mapModel.minPharmacy;
                maxValueColoring = _mapModel.maxPharmacy;
            }
            else if (_mapModel.modeColorCoding == 2)
            {
                countOfGrids = _mapModel.numberOfShadesResidents;
                minValueColoring = _mapModel.minResidents;
                maxValueColoring = _mapModel.maxResidents;
            }
            else
            {
                countOfGrids = _mapModel.numberOfShadesRetired;
                minValueColoring = _mapModel.minRetired;
                maxValueColoring = _mapModel.maxRetired;
            }

            // Длина прямоугольника с цветом зависит от длины панели
            int widthOneRectangle = panelLegendMap.Width / countOfGrids;
            // Шаг градаций
            countOfSteps = maxValueColoring / countOfGrids;
            // Округлить шаг до одной точки после запятой
            countOfSteps = Math.Round(countOfSteps, 1);

            // Отрисовка прямоугольников на панеле
            Graphics graphics = panelLegendMap.CreateGraphics();
            // Прямоугольников с оттенками будет столько, сколько градаций цветов
            Rectangle[] arrayOfRactangles = new Rectangle[countOfGrids];
            Brush[] brush = new SolidBrush[countOfGrids];
            colorPolygon = new Color[countOfGrids];

            // Заполнение цветами и шрифт надписей
            Font arialFont = new Font("Times New Roman", 14);
            Font timesFont = new Font("Times New Roman", 14);

            // От RGB белого цвета будет вычитаться RGB выбранного цвета, чтобы получить оттенки
            hred = (tempColor.R - _colorForColoring.R) / countOfGrids;
            hgreen = (tempColor.G - _colorForColoring.G) / countOfGrids;
            hblue = (tempColor.B - _colorForColoring.B) / countOfGrids;
            // Заполнение прямоугольников оттенками, для каждого прямоугольника находим RGB
            for (int i = 0; i < countOfGrids; i++)
            {
                red = tempColor.R - hred * i;
                green = tempColor.G - hgreen * i;
                blue = tempColor.B - hblue * i;

                // Заливка полигона
                colorPolygon[i] = Color.FromArgb(_transparent, red, green, blue);
                // Отображение прямоугольника по координанатам на панеле
                arrayOfRactangles[i] = new Rectangle(widthOneRectangle * i, 0, widthOneRectangle, 20);
                brush[i] = new SolidBrush(colorPolygon[i]);
                // Заливка прямоугольника на панеле определенным оттенком
                graphics.FillRectangle(brush[i], arrayOfRactangles[i]);
                // Отображение ободка у прямоугольника
                graphics.DrawRectangle(penBoundaryOfRectangle, arrayOfRactangles[i]);
                // Под каждым прямоугольником отображаем цифру шага
                graphics.DrawString(Convert.ToString(countOfSteps * i), arialFont, Brushes.Black, widthOneRectangle * i - i, 20);
            }

            // Под оттенками выводим данную подпись для текущего вида раскраски
            if (_mapModel.modeColorCoding == 1)
                graphics.DrawString("Количество аптек, шт.                                         Сменить цвет", timesFont, Brushes.Black, 0, 40);
            else if (_mapModel.modeColorCoding == 2)
                graphics.DrawString("Количество жителей, чел.                                    Сменить цвет", timesFont, Brushes.Black, 0, 40);
            else
                graphics.DrawString("Количество пенсионеров, чел.                             Сменить цвет", timesFont, Brushes.Black, 0, 40);
        }

        /// <summary>
        /// Обработка изменения прозрачности цвета заливки полигона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarTransparent_Scroll(object sender, EventArgs e)
        {
            // От 0 до 5, то есть от 0(без заливки) до 255(полной заливки)
            _transparent = trackBarTransparent.Value * 51;
            // Перерисовать кварталы
            _DrawPolygonForQuartet();
            // Перерисовать аптеки
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            // Перерисовать раскраску по иконкам
            _CheckSelectedRadioButtonForIconQuartet(sender, e);
            // Перерисовать буферные зоны
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Обработка изменения жирности границ для кварталов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarIntensity_Scroll(object sender, EventArgs e)
        {
            // Значение с ползунка задает толщину границ
            _intensity = trackBarIntensity.Value;
            // Перерисовать кварталы
            _DrawPolygonForQuartet();
            // Перерисовать аптеки
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            // Перерисовать раскраску по иконкам
            _CheckSelectedRadioButtonForIconQuartet(sender, e);
            // Перерисовать буферные зоны
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Свернуть форму
        /// </summary>
        private void MainMap_SizeChanged(object sender, EventArgs e)
        {
            // Если форму сворачивали и при этом была выбрана какая-то раскраска - перерисовать легенду карты
            if ((WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Minimized) && _mapModel.modeColorCoding != 0)
            {
                _DrawPolygonForQuartet();
                _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
                _CheckSelectedRadioButtonForIconQuartet(sender, e);
                _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
            }
        }

        /// <summary>
        /// Перерисовка значков для раскраски кварталов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _CheckSelectedRadioButtonForIconQuartet(object sender, EventArgs e)
        {
            if (radioButtonIconPharmacy.Checked)
                radioButtonIconPharmacy_Click(sender, e);
            if (radioButtonIconResidents.Checked)
                radioButtonIconResidents_Click(sender, e);
            if (radioButtonIconRetired.Checked)
                radioButtonIconRetired_Click(sender, e);
        }

        /// <summary>
        /// Раскраска кварталов по аптекам значками трех цветов
        /// </summary>
        private void radioButtonIconPharmacy_Click(object sender, EventArgs e)
        {
            _mapView.ShowIconPharmacy();
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Раскраска кварталов по жителям значками трех цветов
        /// </summary>
        private void radioButtonIconResidents_Click(object sender, EventArgs e)
        {
            _mapView.ShowIconResidents();
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Раскраска кварталов по пенсионерам значками трех цветов
        /// </summary>
        private void radioButtonIconRetired_Click(object sender, EventArgs e)
        {
            _mapView.ShowIconRetired();
            _CheckSelectedRadioButtonForMarkersPharmacy(sender, e);
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Очистка карты от раскраски значками трех цветов
        /// </summary>
        private void radioButtonIconClear_Click(object sender, EventArgs e)
        {
            _mapView.ClearIconQuartet();
        }

        /// <summary>
        /// Сохранение фотографии
        /// </summary>
        private void SaveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog SaveMapDialog = new SaveFileDialog())
                {
                    // Формат изображения
                    SaveMapDialog.Filter = "Image Files (*.png) | *.png";
                    // Название изображения
                    SaveMapDialog.FileName = "Текущее положение карты";
                    // Преобразование карты в картинку
                    Image image = gmap.ToImage();
                    if (image != null)
                    {
                        using (image)
                        {
                            // Если пользователь подтвердил сохранение
                            if (SaveMapDialog.ShowDialog() == DialogResult.OK)
                            {
                                // Сохранение по выбранному пользователем пути картинку в формате png
                                string fileName = SaveMapDialog.FileName;
                                if (!fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                    fileName += ".png";
                                image.Save(fileName);
                                // Уведомление о том, что сохранение успешно
                                MessageBox.Show("Карта успешно сохранена в директории: " + Environment.NewLine + SaveMapDialog.FileName,
                                    "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении карты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Вывод текущей даты и времени
        /// </summary>
        private void timerForDateTime_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = "Текущая дата и время: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            timerForDateTime.Start();
        }

        /// <summary>
        /// Открытие руководства пользователя
        /// </summary>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\Data\UserManual.pdf");
            }
            catch
            {
                MessageBox.Show("Файл не найден", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Открытие формы для установки параметров для раскраски
        /// </summary>
        private void InputOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingOptions form = new SettingOptions(_mapModel);
            form.ShowDialog();
            // Переотрисовка карты
            _RedrawMap(sender, e);
        }

        /// <summary>
        /// Открытие формы для ввода радиуса
        /// </summary>
        private void InputRadiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingRadius form = new SettingRadius(_mapModel);
            form.ShowDialog();
            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
        }

        /// <summary>
        /// Обработка двойного щелчка левой кнопкой мыши по карте
        /// </summary>
        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Координаты на карте, по которым поставили маркер
                double x = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                double y = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                PointLatLng pointLatLng = new PointLatLng(x, y);

                // В списке маркеров не больше 10 точек
                if (_sublayerUser.listWithLocation.Count < 10)
                {
                    // Если точка в пределах города
                    if (_mapView.CheckInsidePointCity(pointLatLng) == true)
                    {
                        // Если точка не принадлежит любому кварталу
                        if (_mapView.CheckInsidePointQuartet(pointLatLng) == false)
                        {
                            // Ситуация, когда маркер в городе, но находится не в квартале (Дубки, набережная, заводы)
                            if (MessageBox.Show("Точка не принадлежит кварталу. Продолжить?", "Предупреждение",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                // Добавление точки в список маркеров, поставленных пользователем
                                _sublayerUser.listWithLocation.Add(new Location(x, y));
                                // Установка маркера
                                _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
                            }
                        }
                        else
                        {
                            _sublayerUser.listWithLocation.Add(new Location(x, y));
                            _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
                        }
                    }
                    else
                        MessageBox.Show("Маркер должен быть расположен в границах города", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Нельзя разместить более десяти маркеров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _searchOptimum = false;
        /// <summary>
        /// Открытие формы для поиска оптимума
        /// </summary>
        private void SearchOptimumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Для каждого поставленного маркера найти количество охваченных аптек, жителей и пенсионеров
            _mapModel.CreateListBufferZones();
            // Если на карте более двух маркеров
            if (_mapModel.listPointsBufferZone.Count >= 2 && _mapModel.listPointsBufferZone.Count <= 10)
            {
                CalculateOptimum form = new CalculateOptimum(_mapModel, _mapModel.listPointsBufferZone);
                form.ShowDialog();
                // После закрытия формы перерисовать точки, выделив оптимум зеленым цветом
                _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
                // Флажок, что пользователь оставил на карте только оптимальную точку
                _searchOptimum = true;
            }
            else
                MessageBox.Show("Необходимо разместить не менее двух маркеров", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Оставить на карте отображение только оптимальной точки
        /// </summary>
        private void LeaveOptimumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double roundX_Optimal = Math.Round(_mapModel.optimalPoint.x, 12);
            double roundY_Optimal = Math.Round(_mapModel.optimalPoint.y, 12);
            double roundX_Location;
            double roundY_Location;

            // Если пользователь не разместил на карте аптек
            if (_sublayerUser.listWithLocation.Count != 0)
            {
                // Если пользователь не искал оптимальную точку на карте
                if (_mapModel.optimalPoint.idBufferZone != 0)
                {
                    for (int i = 0; _sublayerUser.listWithLocation.Count != 1;)
                    {
                        roundX_Location = Math.Round(_sublayerUser.listWithLocation[i].x, 12);
                        roundY_Location = Math.Round(_sublayerUser.listWithLocation[i].y, 12);
                        // Удаляем из списка маркеров, установленных на карте все кроме оптимальной
                        if (roundX_Optimal != roundX_Location || roundY_Optimal != roundY_Location)
                        {
                            _sublayerUser.listWithLocation.Remove(_sublayerUser.listWithLocation[i]);
                            i = 0;
                        }
                        // Если точку не удалили, значит она оптимальная и нам надо пройти дальше по списку для удаления остальных
                        else
                            i++;
                    }
                    // Перерисовать маркеры на карте, чтобы на ней остался только оптимальный
                    _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
                }
                else
                {
                    for (int i = 0; _sublayerUser.listWithLocation.Count != 0;)
                    {
                        _sublayerUser.listWithLocation.Remove(_sublayerUser.listWithLocation[i]);
                        _mapView.DrawPointBufferZone(_sublayerUser.listWithLocation, _mapModel.radiusBufferZone);
                    }
                }
            }
            else
            {
                MessageBox.Show("На карте нет точек", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Обнуление оптимальной точки
                _mapModel.optimalPoint.idBufferZone = 0;
            }
        }

        private bool _flagSaveOptimum = false;
        /// <summary>
        /// Сохранение оптимума в файл
        /// </summary>
        private void SaveOptimumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если пользователь оставил на карте оптимальную точку
            if (_mapModel.optimalPoint.idBufferZone != 0)
            {
                try
                {
                    using (SaveFileDialog SaveOptimumDialog = new SaveFileDialog())
                    {
                        SaveOptimumDialog.Filter = "Files (*.csv) | *.csv";
                        SaveOptimumDialog.InitialDirectory = Application.StartupPath + @"\Data\DataTest";
                        SaveOptimumDialog.Title = "Сохранение в CSV-файл данных об оптимальной точке";
                        SaveOptimumDialog.FileName = "Оптимальная точка";

                        // Если пользователь подтвердил сохранение
                        if (SaveOptimumDialog.ShowDialog() == DialogResult.OK)
                        {
                            string pathToFile = SaveOptimumDialog.FileName.ToString();
                            string isValidFile = _fileValidator.FileValidationCreateCSV(pathToFile);

                            // Если файл прошёл все проверки
                            if (isValidFile == "Успешно")
                            {
                                // Запись в файл информации об оптимальной точке
                                _fileValidator.WriteInfoOptimumToCSV(pathToFile, _mapModel.optimalPoint);
                                // Флажок, что пользователь сохранил оптимальную точку в файл
                                _flagSaveOptimum = true;
                                MessageBox.Show("Данные успешно сохранены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(isValidFile, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении карты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Найдите оптимульную точку", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        /// <summary>
        /// Нажатие на красный крестик формы
        /// </summary>
        private void Map_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если пользователь сохранил точку в csv-файл
            if (_flagSaveOptimum == true)
                e.Cancel = false;
            else
            {
                // Если пользователь искал оптимум
                if (_searchOptimum == true)
                {
                    // Если пользователь не сохранил оптимальную точку в csv-файл, но при этом искал оптимум
                    if (MessageBox.Show("Вы не сохранили оптимальную точку. Выйти?", "Предупреждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        e.Cancel = false;
                    else
                        e.Cancel = true;
                }
                else
                    e.Cancel = false;
            }
        }

        /// <summary>
        /// Закрыть форму через ESC
        /// </summary>
        private void MainMap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        // Загруженный пользователем значок для отображения аптек
        private Bitmap _bitmapForLoadIconPharmacy;
        /// <summary>
        /// Загрузка значка для отображения аптек
        /// </summary>
        private void IconPharmacyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenDialogIconPharma = new OpenFileDialog();
                // PNG — оптимален для изображений с небольшим количеством цветов, например, для иконок, схем, рисунков и скриншотов.
                // JPEG — это формат изображений, который использует сжатие с потерями и не поддерживает прозрачность.
                OpenDialogIconPharma.Filter = "Files (*.PNG)|*.PNG;";
                OpenDialogIconPharma.InitialDirectory = Application.StartupPath + @"\Icon\IconsPharmacy";
                OpenDialogIconPharma.Title = "Выберите иконку для отображения аптек";

                if (OpenDialogIconPharma.ShowDialog() == DialogResult.OK)
                {
                    // Получение загруженной картинки
                    _bitmapForLoadIconPharmacy = (Bitmap)Bitmap.FromFile(OpenDialogIconPharma.FileName.ToString());
                    Image image = (Image)_bitmapForLoadIconPharmacy;

                    // Если разрешение файла от 5х5 до 90x90 пикселов 
                    if (_bitmapForLoadIconPharmacy.Size.Height >= 5 && _bitmapForLoadIconPharmacy.Size.Height <= 90 &&
                        _bitmapForLoadIconPharmacy.Size.Width >= 5 && _bitmapForLoadIconPharmacy.Size.Width <= 90)
                    {
                        // Если файл png формата
                        if (image.RawFormat.Equals(ImageFormat.Png))
                        {
                            // Замена значка у аптек
                            _mapModel.sublayerPharmacy.iconOfOverlay = OpenDialogIconPharma.FileName.ToString();
                            // В условных обозначениях измнеить значок аптеки
                            pictureBoxPharmacy.Image = image;

                            // Перерисовать аптеки на карте с новым значком
                            if (radioButtonAllPharmacy.Checked)
                            {
                                radioButtonClearPharmacy_Click(sender, e);
                                radioButtonAllPharmacy_Click(sender, e);
                            }
                            if (radioButtonWorkNow.Checked)
                            {
                                radioButtonClearPharmacy_Click(sender, e);
                                radioButtonWorkNow_Click(sender, e);
                            }
                            if (radioButtonLoadTime.Checked)
                            {
                                radioButtonClearPharmacy_Click(sender, e);
                                radioButtonLoadTime_Click(sender, e);
                            }
                        }
                        else
                            MessageBox.Show("Файл должен иметь png-расширение", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Разрешение файла должно быть в пределах от 5х5 до 90x90 пикселов", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Не получилось открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузка файла с данными об аптеках
        /// </summary>
        private void LoadPharmacyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если файл открыт в данный момент
            try
            {
                OpenFileDialog OpenDialogLoadFilePharmacy = new OpenFileDialog();
                OpenDialogLoadFilePharmacy.Filter = "Files (*.csv)|*.csv;";
                OpenDialogLoadFilePharmacy.InitialDirectory = Application.StartupPath + @"\Data\DataTest\CSV_pharmacy_read";
                OpenDialogLoadFilePharmacy.Title = "Выберите CSV-файл для загрузки данных об аптеках";

                if (OpenDialogLoadFilePharmacy.ShowDialog() == DialogResult.OK)
                {
                    string pathToFile = OpenDialogLoadFilePharmacy.FileName.ToString();
                    string isValidFile = _fileValidator.FileUserValidation(pathToFile);

                    // Если файл прошёл все проверки
                    if (isValidFile == "Успешно")
                    {
                        // Валидация хранения данных в файле
                        string isValidDataFile = _fileValidator.DataValidationUserPharmacy(pathToFile, _mapModel.GetSublayerBorderCityForUser());

                        // Если файл прошёл все проверки
                        if (isValidDataFile == "Успешно")
                        {
                            _mapModel.ChangeFileForPharmacy(pathToFile);

                            // Перерисовать на карте аптеки с новыми данными
                            if (radioButtonAllPharmacy.Checked)
                            {
                                radioButtonClearPharmacy_Click(sender, e);
                                radioButtonAllPharmacy_Click(sender, e);
                            }
                            if (radioButtonWorkNow.Checked)
                            {
                                radioButtonClearPharmacy_Click(sender, e);
                                radioButtonWorkNow_Click(sender, e);
                            }
                            if (radioButtonLoadTime.Checked)
                            {
                                radioButtonClearPharmacy_Click(sender, e);
                                radioButtonLoadTime_Click(sender, e);
                            }
                            MessageBox.Show("Данные об аптеках успешно загружены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(isValidDataFile, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show(isValidFile, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Закройте файл, из которого должны загрузиться данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Загрузка файлов с данными о кварталах
        /// </summary>
        private void LoadQuartetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если файл открыт в данный момент
            try
            {
                OpenFileDialog OpenDialogLoadFileQuartet = new OpenFileDialog();
                OpenDialogLoadFileQuartet.Filter = "Files (*.csv)|*.csv;";
                OpenDialogLoadFileQuartet.InitialDirectory = Application.StartupPath + @"\Data\DataTest\CSV_quartet_read";
                OpenDialogLoadFileQuartet.Title = "Выберите CSV-файл для загрузки данных о кварталах и населении";

                if (OpenDialogLoadFileQuartet.ShowDialog() == DialogResult.OK)
                {
                    string pathToFile = OpenDialogLoadFileQuartet.FileName.ToString();
                    string isValidFile = _fileValidator.FileUserValidation(pathToFile);

                    // Если файл прошёл все проверки
                    if (isValidFile == "Успешно")
                    {
                        // Валидация хранения данных в файле
                        string isValidDataFile = _fileValidator.DataValidationUserQuartet(pathToFile, _mapModel.GetSublayerBorderCityForUser());

                        // Если файл прошёл все проверки
                        if (isValidDataFile == "Успешно")
                        {
                            // Изменить данные для кварталов
                            _mapModel.ChangeFileForQuartet(pathToFile);

                            // Перерисовать на карте кварталы
                            if (radioButtonQuartetResidents.Checked)
                                radioButtonQuartetResidents_CheckedChanged(sender, e);
                            else if (radioButtonQuartetRetired.Checked)
                                radioButtonQuartetRetired_CheckedChanged(sender, e);
                            else
                                radioButtonQuartetPharmacy_CheckedChanged(sender, e);

                            MessageBox.Show("Данные о кварталах и населении успешно загружены", "Уведомление",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(isValidDataFile, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show(isValidFile, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Закройте файл, из которого должны загрузиться данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}