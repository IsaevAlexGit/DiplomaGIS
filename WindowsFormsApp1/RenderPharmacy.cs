using System;
using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace OptimumPharmacy
{
    // Класс Отрисовщик
    public class RenderPharmacy
    {
        // Слой с аптеками
        private SublayerPharmacy _sublayerPharmacy = new SublayerPharmacy();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="gmap">Карта</param>
        /// <param name="sublayerPharma">Слой для аптек</param>
        public RenderPharmacy(GMapControl gmap, SublayerPharmacy sublayerPharma)
        {
            _sublayerPharmacy = sublayerPharma;
        }

        // Режим выводящейся информации об аптеки
        // 1 - Слово "Пптека"
        // 2 - Вся информация
        // 3 - Название аптеки
        // 4 - Время работы
        // 5 - Убрать подписи
        private int _modeInfoPharmacy = 1;

        /// <summary>
        /// Установка режима выводящейся информации об аптеки
        /// </summary>
        /// <param name="mode">Режим</param>
        public void SetMode(int mode)
        {
            _modeInfoPharmacy = mode;
        }

        /// <summary>
        /// Отображение всех аптек
        /// </summary>
        /// <param name="gmap">Карта</param>
        public void DrawPharmacy(GMapControl gmap)
        {
            // Очистить у слоя маркеры
            _sublayerPharmacy.overlay.Markers.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerPharmacy.overlay);
            // Очистка слоя
            _sublayerPharmacy.overlay.Clear();
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerPharmacy.overlay);
            // Инициализация маркеров
            _InitializationMarkersPharmacy(_sublayerPharmacy);
            // Делаем слой видимым
            _sublayerPharmacy.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Инициализация маркеров аптек
        /// </summary>
        /// <param name="sub">Слой аптеки</param>
        private void _InitializationMarkersPharmacy(SublayerPharmacy sub)
        {
            for (int i = 0; i < sub.listWithPharmacy.Count; i++)
            {
                Bitmap icon = new Bitmap(sub.iconOfOverlay);
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(sub.listWithPharmacy[i].x, sub.listWithPharmacy[i].y), icon);
                marker.ToolTip = new GMapRoundedToolTip(marker);
                marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                marker.ToolTipText = _ChangeInfoTextPharmacy(_modeInfoPharmacy, sub.listWithPharmacy[i]);
                sub.overlay.Markers.Add(marker);
            }
        }

        /// <summary>
        /// Отображение аптек, работающих сейчас
        /// </summary>
        /// <param name="gmap"></param>
        public void DrawWorkPharmacy(GMapControl gmap)
        {
            // Очистить у слоя маркеры
            _sublayerPharmacy.overlay.Markers.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerPharmacy.overlay);
            // Очистка слоя
            _sublayerPharmacy.overlay.Clear();
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerPharmacy.overlay);
            // Инициализация маркеров
            _InitializationMarkersPharmacyWorkNow(_sublayerPharmacy);
            // Делаем слой видимым
            _sublayerPharmacy.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Инициализация аптек, работающих сейчас
        /// </summary>
        /// <param name="sub">Слой аптеки</param>
        private void _InitializationMarkersPharmacyWorkNow(SublayerPharmacy sub)
        {
            // Текущее время
            DateTime dateNow = DateTime.Now;
            // Получили час
            double hours = dateNow.Hour;
            // Получили минуты
            double min = dateNow.Minute;
            // Нашли время в удобном формате для работы с ним
            double workTime = Convert.ToDouble(hours) + (min / 100);

            for (int i = 0; i < sub.listWithPharmacy.Count; i++)
            {
                // Если текущее время на компьютере между открытием и закрытием аптеки
                if (workTime >= sub.listWithPharmacy[i].timeOpening && workTime <= sub.listWithPharmacy[i].timeClosing)
                {
                    Bitmap icon = new Bitmap(sub.iconOfOverlay);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(sub.listWithPharmacy[i].x, sub.listWithPharmacy[i].y), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = _ChangeInfoTextPharmacy(_modeInfoPharmacy, sub.listWithPharmacy[i]);
                    sub.overlay.Markers.Add(marker);
                }
            }
        }

        private double _loadTime;
       /// <summary>
       /// Отображение аптек, работающих в заданное время
       /// </summary>
       /// <param name="gmap">Карта</param>
       /// <param name="Time">Заданное время работы</param>
        public void DrawWorkLoadTimePharmacy(GMapControl gmap, double Time)
        {
            _loadTime = Time;
            // Очистить у слоя маркеры
            _sublayerPharmacy.overlay.Markers.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerPharmacy.overlay);
            // Очистка слоя
            _sublayerPharmacy.overlay.Clear();
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerPharmacy.overlay);
            // Инициализация маркеров
            _InitializationMarkersPharmacyWorkLoadTime(_sublayerPharmacy);
            // Делаем слой видимым
            _sublayerPharmacy.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Инициализация аптек, работающих в введенное время
        /// </summary>
        /// <param name="sub">Слой аптеки</param>
        private void _InitializationMarkersPharmacyWorkLoadTime(SublayerPharmacy sub)
        {
            for (int i = 0; i < sub.listWithPharmacy.Count; i++)
            {
                // Если указанное время между открытием и закрытием аптеки
                if (_loadTime >= sub.listWithPharmacy[i].timeOpening && _loadTime <= sub.listWithPharmacy[i].timeClosing)
                {
                    Bitmap icon = new Bitmap(sub.iconOfOverlay);
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(sub.listWithPharmacy[i].x, sub.listWithPharmacy[i].y), icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    marker.ToolTipText = _ChangeInfoTextPharmacy(_modeInfoPharmacy, sub.listWithPharmacy[i]);
                    sub.overlay.Markers.Add(marker);
                }
            }
        }

        /// <summary>
        /// Изменение выводимой информации об аптеке
        /// </summary>
        /// <param name="mode">Режим выводимой информации</param>
        /// <param name="point">Аптека на карте</param>
        /// <returns>Выводящаяся информация об аптеке</returns>
        private string _ChangeInfoTextPharmacy(int mode, Pharmacy point)
        {
            // Конечная подпись аптеки
            string TextInfo = "";

            // Если 1 - Аптека
            if (mode == 1)
                TextInfo = "Аптека";

            // Если 2 - вся информация об аптеке
            else if (mode == 2)
            {
                string Time = "";
                // Время
                double Open = point.timeOpening;
                double Close = point.timeClosing;

                // Если неизвестно
                if (Open == -1.0 && Close == -1.0)
                    Time = "Время работы: неизвестно";
                // Если круглосуточно
                else if (Open == 0.0 && Close == 25.0)
                    Time = "Время работы: круглосуточно";
                // Если есть время
                else
                {
                    double OpenInt = Open * 10;
                    double CloseInt = Close * 10;
                    // Последние цифры времени
                    int EndOpen = Convert.ToInt32(OpenInt) % 10;
                    int EndClose = Convert.ToInt32(CloseInt) % 10;

                    // 07:00-20:00
                    if (EndOpen == 0 && EndClose == 0)
                    {
                        if (Open <= 9)
                            Time = "Время работы: 0" + Open + ":00-" + Close + ":00";
                        else
                            Time = "Время работы: " + Open + ":00-" + Close + ":00";
                    }
                    // 07:00-21:30
                    if (EndOpen == 0 && EndClose == 5)
                    {
                        Close = Close - 0.5;
                        if (Open <= 9)
                            Time = "Время работы: 0" + Open + ":00-" + Close + ":30";
                        else
                            Time = "Время работы: " + Open + ":00 -" + Close + ":30";
                    }
                    // 07:30-21:00
                    if (EndOpen == 5 && EndClose == 0)
                    {
                        Open = Open - 0.5;
                        if (Open <= 9)
                            Time = "Время работы: 0" + Open + ":30-" + Close + ":00";
                        else
                            Time = "Время работы: " + Open + ":30 -" + Close + ":00";
                    }
                    // 07:30-21:30
                    if (EndOpen == 5 && EndClose == 5)
                    {
                        Open = Open - 0.5;
                        Close = Close - 0.5;
                        if (Open <= 9)
                            Time = "Время работы: 0" + Open + ":30-" + Close + ":30";
                        else
                            Time = "Время работы: " + Open + ":30 -" + Close + ":30";
                    }
                }

                TextInfo =
                    "Название: " + point.namePharmacy + Environment.NewLine +
                    "Адрес: " + point.address + Environment.NewLine +
                    "Сайт: " + point.site + Environment.NewLine +
                    "Телефон: " + point.phone + Environment.NewLine +
                    Time;
            }
            // Если 3 - Название аптеки
            else if (mode == 3)
                TextInfo = point.namePharmacy;
            // Если 4 - Время работы аптеки
            else if (mode == 4)
            {
                // Время
                double Open = point.timeOpening;
                double Close = point.timeClosing;

                // Если неизвестно
                if (Open == -1.0 && Close == -1.0)
                    TextInfo = "Время работы: неизвестно";
                // Если круглосуточно
                else if (Open == 0.0 && Close == 25.0)
                    TextInfo = "Время работы: круглосуточно";
                // Если есть время
                else
                {
                    double OpenInt = Open * 10;
                    double CloseInt = Close * 10;
                    // Последние цифры времени
                    int EndOpen = Convert.ToInt32(OpenInt) % 10;
                    int EndClose = Convert.ToInt32(CloseInt) % 10;
                    // 07:00-20:00
                    if (EndOpen == 0 && EndClose == 0)
                    {
                        if (Open <= 9)
                            TextInfo = "Время работы: 0" + Open + ":00-" + Close + ":00";
                        else
                            TextInfo = "Время работы: " + Open + ":00-" + Close + ":00";
                    }
                    // 07:00-21:30
                    if (EndOpen == 0 && EndClose == 5)
                    {
                        Close = Close - 0.5;
                        if (Open <= 9)
                            TextInfo = "Время работы: 0" + Open + ":00-" + Close + ":30";
                        else
                            TextInfo = "Время работы: " + Open + ":00 -" + Close + ":30";
                    }
                    // 07:30-21:00
                    if (EndOpen == 5 && EndClose == 0)
                    {
                        Open = Open - 0.5;
                        if (Open <= 9)
                            TextInfo = "Время работы: 0" + Open + ":30-" + Close + ":00";
                        else
                            TextInfo = "Время работы: " + Open + ":30 -" + Close + ":00";
                    }
                    // 07:30-21:30
                    if (EndOpen == 5 && EndClose == 5)
                    {
                        Open = Open - 0.5;
                        Close = Close - 0.5;
                        if (Open <= 9)
                            TextInfo = "Время работы: 0" + Open + ":30-" + Close + ":30";
                        else
                            TextInfo = "Время работы: " + Open + ":30 -" + Close + ":30";
                    }
                }
            }
            // Если 5 - убрать информацию об аптеке
            else
                TextInfo = "";
            return TextInfo;
        }

        /// <summary>
        /// Очистка отображения всех аптек
        /// </summary>
        /// <param name="gmap">Карта</param>
        public void ClearPharmacy(GMapControl gmap)
        {
            // Очистить у слоя маркеры, если они были проинициализированы ранее
            _sublayerPharmacy.overlay.Markers.Clear();
            // Убираем слой с карты
            gmap.Overlays.Remove(_sublayerPharmacy.overlay);
            // Убираем видимость маркеров
            _sublayerPharmacy.overlay.IsVisibile = false;
            // Очищаем слой
            _sublayerPharmacy.overlay.Clear();
        }
    }
}