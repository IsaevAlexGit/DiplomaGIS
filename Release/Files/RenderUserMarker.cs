using System;
using System.Drawing;
using System.Collections.Generic;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace OptimumPharmacy
{
    public class RenderUserMarker
    {
        // Слой с маркерами пользователя
        private SublayerLocation _subLocationPharmaUsers = new SublayerLocation();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="gmap">Карта</param>
        /// <param name="subUser">Слой пользователя</param>
        public RenderUserMarker(GMapControl gmap, SublayerLocation subUser)
        {
            _subLocationPharmaUsers = subUser;
        }

        // Радиус поиска и оптимум
        private int _radiusSearch;
        private BufferZone _optimimPoint;
        /// <summary>
        /// Инициализация точек на карте
        /// </summary>
        /// <param name="gmap">Карта</param>
        /// <param name="radius">Радиус</param>
        /// <param name="optimum">Оптимальная точка</param>
        public void InitializationPoint(GMapControl gmap, int radius, BufferZone optimum)
        {
            _radiusSearch = radius;
            _optimimPoint = optimum;
            // Очистить у слоя маркеры
            _subLocationPharmaUsers.overlay.Markers.Clear();
            // Очистить у слоя полигоны
            _subLocationPharmaUsers.overlay.Polygons.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_subLocationPharmaUsers.overlay);
            // Очистка слоя
            _subLocationPharmaUsers.overlay.Clear();
            // Добавление слоя на карту
            gmap.Overlays.Add(_subLocationPharmaUsers.overlay);
            // Инициализация маркеров
            _InitializationMarkers(_subLocationPharmaUsers);
            // Делаем слой видимым
            _subLocationPharmaUsers.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Инициализация маркеров
        /// </summary>
        /// <param name="_subUser"></param>
        private void _InitializationMarkers(SublayerLocation _subUser)
        {
            // Координаты оптимальной точки
            double roundX_Optimal = Math.Round(_optimimPoint.x, 6);
            double roundY_Optimal = Math.Round(_optimimPoint.y, 6);
            // Координаты маркера
            double roundX_Location;
            double roundY_Location;

            // Список с маркерами пользователя
            for (int i = 0; i < _subUser.listWithLocation.Count; i++)
            {
                roundX_Location = Math.Round(_subUser.listWithLocation[i].x, 6);
                roundY_Location = Math.Round(_subUser.listWithLocation[i].y, 6);

                if (roundX_Optimal == roundX_Location && roundY_Optimal == roundY_Location)
                {
                    // Значок маркера
                    Bitmap icon = new Bitmap(_subUser.iconOfOverlay);
                    // Координаты маркера
                    PointLatLng point = new PointLatLng(_subUser.listWithLocation[i].x, _subUser.listWithLocation[i].y);
                    GMarkerGoogle marker = new GMarkerGoogle(point, icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    // Подпись маркера для оптимума
                    marker.ToolTipText = "Оптимум";
                    // Добавление маркера на слой
                    _subUser.overlay.Markers.Add(marker);
                    // Отрисовка окружности у маркера
                    _InitializationZoneOptimum(point);
                }
                else
                {
                    // Значок маркера
                    Bitmap icon = new Bitmap(_subUser.iconOfOverlay);
                    // Координаты маркера
                    PointLatLng point = new PointLatLng(_subUser.listWithLocation[i].x, _subUser.listWithLocation[i].y);
                    GMarkerGoogle marker = new GMarkerGoogle(point, icon);
                    marker.ToolTip = new GMapRoundedToolTip(marker);
                    marker.Offset = new Point(-icon.Width / 2, -icon.Height / 2);
                    // Подпись маркера
                    marker.ToolTipText = "Кандидат #" + (_subUser.overlay.Markers.Count + 1);
                    // Добавление маркера на слой
                    _subUser.overlay.Markers.Add(marker);
                    // Отрисовка окружности у маркера
                    _InitializationZone(point);
                }
            }
        }

        private GMapPolygon _polygon;
        // Доля от окружности
        private readonly int _segments = 360;
        private List<PointLatLng> _listPointsForCircle;
        private const double CONVERSION_FROM_DEGREES_TO_RADIANS = Math.PI / 180;
        private const double CONVERSION_FROM_RADIANS_TO_DEGREES = 180 / Math.PI;
        // Радиус планеты Земля = 6 371 км.
        private const double RADIUS_OF_THE_EARTH_IN_KILOMETERS = 6371.01;

        /// <summary>
        /// Инициализация буферной зоны
        /// </summary>
        /// <param name="point">Точка</param>
        private void _InitializationZone(PointLatLng point)
        {
            // Отрисовка окружности
            _CreateCircle(point, _radiusSearch);
            // Добавление полигона на слой карты
            _subLocationPharmaUsers.overlay.Polygons.Add(_polygon);
        }

        /// <summary>
        /// Инициализация оптимальной буферной зоны
        /// </summary>
        /// <param name="point">Точка</param>
        private void _InitializationZoneOptimum(PointLatLng point)
        {
            // Отрисовка окружности
            _CreateCircleOptimum(point, _radiusSearch);
            // Добавление полигона на слой карты
            _subLocationPharmaUsers.overlay.Polygons.Add(_polygon);
        }

        /// <summary>
        /// Отрисовка окружности
        /// </summary>
        /// <param name="centre">Центр окружности</param>
        /// <param name="radius">Радиус окружности</param>
        private void _CreateCircle(PointLatLng centre, double radius)
        {
            // Список для полигонов
            _listPointsForCircle = new List<PointLatLng>();
            // Для каждого сегмента
            for (int i = 0; i < _segments; i++)
                _listPointsForCircle.Add(_FindPointAtDistanceFrom(centre, i * (Math.PI / 180), radius / 1000));

            // Создание полигона
            _polygon = new GMapPolygon(_listPointsForCircle, "Circle");
            // Заливка полигона и его прозрачность
            _polygon.Fill = new SolidBrush(Color.FromArgb(100, Color.Red));
            // Цвет и толщина границы окружности
            _polygon.Stroke = new Pen(Color.Transparent, 0);
        }

        /// <summary>
        /// Отрисовка окружности оптимальной точки
        /// </summary>
        /// <param name="centre">Центр окружности</param>
        /// <param name="radius">Радиус окружности</param>
        private void _CreateCircleOptimum(PointLatLng centre, double radius)
        {
            // Список для полигонов
            _listPointsForCircle = new List<PointLatLng>();
            // Для каждого сегмента
            for (int i = 0; i < _segments; i++)
                _listPointsForCircle.Add(_FindPointAtDistanceFrom(centre, i * (Math.PI / 180), radius / 1000));

            // Создание полигона
            _polygon = new GMapPolygon(_listPointsForCircle, "Circle");
            // Заливка полигона и его прозрачность
            _polygon.Fill = new SolidBrush(Color.FromArgb(100, Color.Green));
            // Цвет и толщина границы окружности
            _polygon.Stroke = new Pen(Color.Transparent, 0);
        }

        /// <summary>
        /// Вычисление каждой точки окружности
        /// </summary>
        /// <param name="startPoint">Начальная точка (центр окружности)</param>
        /// <param name="initialBearingRadians">Точка сегмента (от 0 до 360)</param>
        /// <param name="distanceKilometres">Радиус в километрах</param>
        /// <returns>Точка, которая образует окружность</returns>
        private static PointLatLng _FindPointAtDistanceFrom(PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            // Cоотношение радиуса окружности к радиусу Земли = расстояние от центра до сегмента / радиус Земли
            var distRatio = distanceKilometres / RADIUS_OF_THE_EARTH_IN_KILOMETERS;

            // Синус соотношения
            var distRatioSine = Math.Sin(distRatio);
            // Косинус соотношения
            var distRatioCosine = Math.Cos(distRatio);

            // Перевод начальнрнр х и у (центр) в радианы
            var startLatRad = startPoint.Lat * CONVERSION_FROM_DEGREES_TO_RADIANS;
            var startLonRad = startPoint.Lng * CONVERSION_FROM_DEGREES_TO_RADIANS;

            // Синус и косинус х,у центра в радианах
            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            // Поиск х,у конечной точки, где будет стоять точка, из которых будет строиться круг
            // Формулы для расчета новой позиции
            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
            var endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos,
                distRatioCosine - startLatSin * Math.Sin(endLatRads));

            // Конечные х,у в радианах переводим в градусы и возвращаем эту точку, до которой будет строиться линия
            return new PointLatLng(endLatRads * CONVERSION_FROM_RADIANS_TO_DEGREES, endLonRads * CONVERSION_FROM_RADIANS_TO_DEGREES);
        }
    }
}