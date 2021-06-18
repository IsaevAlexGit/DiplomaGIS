using System;
using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace OptimumPharmacy
{
    public class RenderQuartet
    {
        // Слой для отображения раскраски кварталов по значкам
        private SublayerQuartet _sublayerQuartetIcon = new SublayerQuartet();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="gmap">Карта</param>
        /// <param name="sublayerQuartet">Слой с кварталами</param>
        public RenderQuartet(GMapControl gmap, SublayerQuartet sublayerQuartet)
        {
            _sublayerQuartetIcon = sublayerQuartet;
        }

        // Максимумы для раскраски
        private int _maxPharma = 0;
        private int _maxResidents = 0;
        private int _maxRetired = 0;

        /// <summary>
        /// Раскраска иконками по аптекам
        /// </summary>
        /// <param name="gmap">Карта</param>
        /// <param name="MaxForPharma">Максимум для аптек</param>
        /// <param name="IconFew">Иконка для значения "мало"</param>
        /// <param name="IconMiddle">Иконка для значения "умеренно"</param>
        /// <param name="IconLot">Иконка для значения "много"</param>
        public void ShowIconPharmacy(GMapControl gmap, int MaxForPharma, string IconFew, string IconMiddle, string IconLot)
        {
            _maxPharma = MaxForPharma;
            // Очистить у слоя маркеры
            _sublayerQuartetIcon.overlay.Markers.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerQuartetIcon.overlay);
            // Очистка слоя
            _sublayerQuartetIcon.overlay.Clear();
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerQuartetIcon.overlay);
            // Инициализация маркеров
            _InitializationMarkersPharmacy(_sublayerQuartetIcon, IconFew, IconMiddle, IconLot);
            // Делаем слой видимым
            _sublayerQuartetIcon.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Инициализация маркеров аптек
        /// </summary>
        /// <param name="subQuartet">Слой для отображения</param>
        /// <param name="IconFew">Иконка для значения "мало"</param>
        /// <param name="IconMiddle">Иконка для значения "умеренно"</param>
        /// <param name="IconLot">Иконка для значения "много"</param>
        private void _InitializationMarkersPharmacy(SublayerQuartet subQuartet, string IconFew, string IconMiddle, string IconLot)
        {
            // Имея максимум для раскраски и минимум по умолчанию, ищем три равных интервала для раскраски
            double _minValue = 0;
            double _maxValue = _maxPharma;
            double _thirdOfValue = _maxValue / 3;
            _thirdOfValue = Math.Round(_thirdOfValue, 1);
            double _secondValue = _minValue + _thirdOfValue;
            double _thirdValue = _secondValue + _thirdOfValue;

            // Определить в какой диапазон попадает квартал
            for (int i = 0; i < subQuartet.listWithQuartets.Count; i++)
            {
                if (subQuartet.listWithQuartets[i].countOfPharmacy >= _minValue && subQuartet.listWithQuartets[i].countOfPharmacy < _secondValue)
                {
                    Bitmap icon = new Bitmap(IconFew);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Аптек: " + subQuartet.listWithQuartets[i].countOfPharmacy.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
                else if (subQuartet.listWithQuartets[i].countOfPharmacy >= _secondValue && subQuartet.listWithQuartets[i].countOfPharmacy < _thirdValue)
                {
                    Bitmap icon = new Bitmap(IconMiddle);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Аптек: " + subQuartet.listWithQuartets[i].countOfPharmacy.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
                else
                {
                    Bitmap icon = new Bitmap(IconLot);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Аптек: " + subQuartet.listWithQuartets[i].countOfPharmacy.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
            }
        }

        /// <summary>
        /// Раскраска иконками по жителям
        /// </summary>
        /// <param name="gmap">Карта</param>
        /// <param name="MaxForResidents">Максимум для жителей</param>
        /// <param name="IconFew">Иконка для значения "мало"</param>
        /// <param name="IconMiddle">Иконка для значения "умеренно"</param>
        /// <param name="IconLot">Иконка для значения "много"</param>
        public void ShowIconResidents(GMapControl gmap, int MaxForResidents, string IconFew, string IconMiddle, string IconLot)
        {
            _maxResidents = MaxForResidents;
            // Очистить у слоя маркеры
            _sublayerQuartetIcon.overlay.Markers.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerQuartetIcon.overlay);
            // Очистка слоя
            _sublayerQuartetIcon.overlay.Clear();
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerQuartetIcon.overlay);
            // Инициализация маркеров
            _InitializationMarkersResidents(_sublayerQuartetIcon, IconFew, IconMiddle, IconLot);
            // Делаем слой видимым
            _sublayerQuartetIcon.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Инициализация маркеров жителей
        /// </summary>
        /// <param name="subQuartet">Слой для отображения</param>
        /// <param name="IconFew">Иконка для значения "мало"</param>
        /// <param name="IconMiddle">Иконка для значения "умеренно"</param>
        /// <param name="IconLot">Иконка для значения "много"</param>
        private void _InitializationMarkersResidents(SublayerQuartet subQuartet, string IconFew, string IconMiddle, string IconLot)
        {
            // Имея максимум для раскраски и минимум по умолчанию, ищем три равных интервала для раскраски
            double _minValue = 0;
            double _maxValue = _maxResidents;
            double _thirdOfValue = _maxValue / 3;
            _thirdOfValue = Math.Round(_thirdOfValue, 1);
            double _secondValue = _minValue + _thirdOfValue;
            double _thirdValue = _secondValue + _thirdOfValue;

            // Определить в какой диапазон попадает квартал
            for (int i = 0; i < subQuartet.listWithQuartets.Count; i++)
            {
                if (subQuartet.listWithQuartets[i].countOfResidents >= _minValue && subQuartet.listWithQuartets[i].countOfResidents < _secondValue)
                {
                    Bitmap icon = new Bitmap(IconFew);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Жителей: " + subQuartet.listWithQuartets[i].countOfResidents.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
                else if (subQuartet.listWithQuartets[i].countOfResidents >= _secondValue && subQuartet.listWithQuartets[i].countOfResidents < _thirdValue)
                {
                    Bitmap icon = new Bitmap(IconMiddle);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Жителей: " + subQuartet.listWithQuartets[i].countOfResidents.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
                else
                {
                    Bitmap icon = new Bitmap(IconLot);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Жителей: " + subQuartet.listWithQuartets[i].countOfResidents.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
            }
        }

        /// <summary>
        /// Раскраска иконками по пенсионерам
        /// </summary>
        /// <param name="gmap">Карта</param>
        /// <param name="MaxForRetired">Максимум для пенсионеров</param>
        /// <param name="IconFew">Иконка для значения "мало"</param>
        /// <param name="IconMiddle">Иконка для значения "умеренно"</param>
        /// <param name="IconLot">Иконка для значения "много"</param>
        public void ShowIconRetired(GMapControl gmap, int MaxForRetired, string IconFew, string IconMiddle, string IconLot)
        {
            _maxRetired = MaxForRetired;
            // Очистить у слоя маркеры
            _sublayerQuartetIcon.overlay.Markers.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerQuartetIcon.overlay);
            // Очистка слоя
            _sublayerQuartetIcon.overlay.Clear();
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerQuartetIcon.overlay);
            // Инициализация маркеров
            _InitializationMarkersRetired(_sublayerQuartetIcon, IconFew, IconMiddle, IconLot);
            // Делаем слой видимым
            _sublayerQuartetIcon.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Инициализация маркеров пенсионеров
        /// </summary>
        /// <param name="subQuartet">Слой для отображения</param>
        /// <param name="IconFew">Иконка для значения "мало"</param>
        /// <param name="IconMiddle">Иконка для значения "умеренно"</param>
        /// <param name="IconLot">Иконка для значения "много"</param>
        private void _InitializationMarkersRetired(SublayerQuartet subQuartet, string IconFew, string IconMiddle, string IconLot)
        {
            // Имея максимум для раскраски и минимум по умолчанию, ищем три равных интервала для раскраски
            double _minValue = 0;
            double _maxValue = _maxRetired;
            double _thirdOfValue = _maxValue / 3;
            _thirdOfValue = Math.Round(_thirdOfValue, 1);
            double _secondValue = _minValue + _thirdOfValue;
            double _thirdValue = _secondValue + _thirdOfValue;

            // Определить в какой диапазон попадает квартал
            for (int i = 0; i < subQuartet.listWithQuartets.Count; i++)
            {
                if (subQuartet.listWithQuartets[i].countOfRetired >= _minValue && subQuartet.listWithQuartets[i].countOfRetired < _secondValue)
                {
                    Bitmap icon = new Bitmap(IconFew);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Пенсионеров: " + subQuartet.listWithQuartets[i].countOfRetired.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
                else if (subQuartet.listWithQuartets[i].countOfRetired >= _secondValue && subQuartet.listWithQuartets[i].countOfRetired < _thirdValue)
                {
                    Bitmap icon = new Bitmap(IconMiddle);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Пенсионеров: " + subQuartet.listWithQuartets[i].countOfRetired.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
                else
                {
                    Bitmap icon = new Bitmap(IconLot);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(subQuartet.listWithQuartets[i].xCentreOfQuartet,
                        subQuartet.listWithQuartets[i].yCentreOfQuartet), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = "Пенсионеров: " + subQuartet.listWithQuartets[i].countOfRetired.ToString();
                    subQuartet.overlay.Markers.Add(marker);
                }
            }
        }

        /// <summary>
        /// Очистка раскраски иконками
        /// </summary>
        /// <param name="gmap"></param>
        public void ClearIconQuartet(GMapControl gmap)
        {
            // Очистить у слоя маркеры
            _sublayerQuartetIcon.overlay.Markers.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerQuartetIcon.overlay);
            // Убрать видимость слоя
            _sublayerQuartetIcon.overlay.IsVisibile = false;
            // Очистка слоя
            _sublayerQuartetIcon.overlay.Clear();
        }
    }
}