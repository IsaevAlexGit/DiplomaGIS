using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace OptimumPharmacy
{
    public class MapView
    {
        private MapModel _mapModel;
        private GMapControl _gmap = new GMapControl();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapModel">Объект MapModel</param>
        public MapView(MapModel mapModel)
        {
            _mapModel = mapModel;
            // Инициализация отрисовщиков
            _InitializationRenderers();
        }

        // Отрисовщики каждого слоя
        private RenderPharmacy _renderPharmacy;
        private RenderDistrict _renderDistrict;
        private RenderQuartet _renderQuartet;
        private RenderUserMarker _renderUserPoints;

        /// <summary>
        /// Инициализация всех отрисовщиков
        /// </summary>
        private void _InitializationRenderers()
        {
            _renderPharmacy = new RenderPharmacy(_gmap, _mapModel.GetSublayerPharmacy());
            _renderDistrict = new RenderDistrict(_gmap, _mapModel.GetSublayerDistrict(), _mapModel.GetSublayerCity());
            _renderQuartet = new RenderQuartet(_gmap, _mapModel.GetSublayerQuartetIcon());
            _renderUserPoints = new RenderUserMarker(_gmap, _mapModel.GetSublayerUserPoints());
        }

        /// <summary>
        /// Отображение всех аптек
        /// </summary>
        public void DrawPharmacy()
        {
            _renderPharmacy.DrawPharmacy(_gmap);
        }

        /// <summary>
        /// Отображение аптек, работающих сейчас
        /// </summary>
        public void DrawWorkNowPharmacy()
        {
            _renderPharmacy.DrawWorkPharmacy(_gmap);
        }

        /// <summary>
        /// Отображение аптек, работающих в заданное время
        /// </summary>
        /// <param name="Time"></param>
        public void DrawWorkLoadTimePharmacy(double Time)
        {
            _renderPharmacy.DrawWorkLoadTimePharmacy(_gmap, Time);
        }

        /// <summary>
        /// Очистка карты от аптек
        /// </summary>
        public void ClearPharmacy()
        {
            _renderPharmacy.ClearPharmacy(_gmap);
        }

        /// <summary>
        /// Обработка выводящейся информации при наведении на аптеку
        /// </summary>
        /// <param name="Pharmacymode">Режим вывода информации</param>
        public void SetTextForPharmacy(int modePharma)
        {
            _renderPharmacy.SetMode(modePharma);
        }

        /// <summary>
        /// Отображение города
        /// </summary>
        public void DrawCity()
        {
            _renderDistrict.DrawCity(_gmap);
        }

        /// <summary>
        /// Отображение районов города
        /// </summary>
        public void DrawDistricts()
        {
            _renderDistrict.DrawDistricts(_gmap);
        }

        /// <summary>
        /// Очистка карты от города и районов
        /// </summary>
        public void ClearDistricts()
        {
            _renderDistrict.ClearDistrict(_gmap);
        }

        /// <summary>
        /// Убрать раскраску по полигонам
        /// </summary>
        /// <param name="renderQuartet">Слой с кварталами</param>
        public void ClearPolygonQuartet(SublayerQuartet subQuartet)
        {
            subQuartet.overlay.Polygons.Clear();
            subQuartet.overlay.Markers.Clear();
            subQuartet.overlay.IsVisibile = false;
            _gmap.Overlays.Remove(subQuartet.overlay);
            subQuartet.overlay.Clear();
        }

        /// <summary>
        /// Раскраска по аптекам иконками
        /// </summary>
        public void ShowIconPharmacy()
        {
            _renderQuartet.ShowIconPharmacy(_gmap, _mapModel.maxPharmacy, _mapModel.iconFew, _mapModel.iconMiddle, _mapModel.iconLot);
        }

        /// <summary>
        /// Раскраска по жителям иконками
        /// </summary>
        public void ShowIconResidents()
        {
            _renderQuartet.ShowIconResidents(_gmap, _mapModel.maxResidents, _mapModel.iconFew, _mapModel.iconMiddle, _mapModel.iconLot);
        }

        /// <summary>
        /// Раскраска по пенсионерам иконками
        /// </summary>
        public void ShowIconRetired()
        {
            _renderQuartet.ShowIconRetired(_gmap, _mapModel.maxRetired, _mapModel.iconFew, _mapModel.iconMiddle, _mapModel.iconLot);
        }

        /// <summary>
        /// Очистка карты от раскраски иконками
        /// </summary>
        public void ClearIconQuartet()
        {
            _renderQuartet.ClearIconQuartet(_gmap);
        }

        /// <summary>
        /// Проверка принадлежности точки городу
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Флаг принадлежности городу</returns>
        public bool CheckInsidePointCity(PointLatLng point)
        {
            // Принадлежность точки городу
            bool isInsydeCity = false;

            // Список граничных точек города
            SublayerLocation listBoundaryPointsCity = _mapModel.GetSublayerCity();
            List<PointLatLng> pointsPolygon = new List<PointLatLng>();
            for (int i = 0; i < listBoundaryPointsCity.listWithLocation.Count; i++)
                pointsPolygon.Add(new PointLatLng(listBoundaryPointsCity.listWithLocation[i].x, listBoundaryPointsCity.listWithLocation[i].y));

            // Создание полигона
            var polygon = new GMapPolygon(pointsPolygon, "city");
            // Проверка принадлежности
            if (polygon.IsInside(point))
                isInsydeCity = true;
            else
                isInsydeCity = false;
            return isInsydeCity;
        }

        /// <summary>
        /// Проверка принадлежности точки кварталу
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Флаг принадлежности городу</returns>
        public bool CheckInsidePointQuartet(PointLatLng point)
        {
            // Слой для проверки
            SublayerQuartet sublayer = _mapModel.GetSublayerQuartetCheck();
            List<PointLatLng> listTemp;
            // Принадлежность точки любому кварталу
            bool isInsydeQuartet = false;

            // Заполнение таблицы данными из списка с кварталами
            DataTable dataquartets = _mapModel.CreateTableFromQuartets();
            int countOfQuartets = dataquartets.Rows.Count;

            List<PointLatLng>[] listBoundaryForEveryQuartet = new List<PointLatLng>[countOfQuartets];
            for (int i = 0; i < listBoundaryForEveryQuartet.Length; i++)
                listBoundaryForEveryQuartet[i] = new List<PointLatLng>();

            // Заполнение listTemp
            for (int j = 0; j < countOfQuartets; j++)
            {
                listTemp = new List<PointLatLng>();
                for (int k = 0; k < sublayer.listWithQuartets[j].listBoundaryPoints.Count; k++)
                {
                    Location tempPoint = new Location(sublayer.listWithQuartets[j].listBoundaryPoints[k].x,
                        sublayer.listWithQuartets[j].listBoundaryPoints[k].y);
                    PointLatLng temp2 = new PointLatLng(tempPoint.x, tempPoint.y);
                    listTemp.Add(temp2);
                }
                listBoundaryForEveryQuartet[j] = listTemp;
            }

            // Добавление всех кварталов на слой
            for (int j = 0; j < countOfQuartets; j++)
            {
                var mapPolygon = new GMapPolygon(listBoundaryForEveryQuartet[j], "Quartet" + j.ToString());
                sublayer.overlay.Polygons.Add(mapPolygon);
            }

            // Все полигоны слоя
            var polygons = sublayer.overlay.Polygons;
            foreach (var polygon in polygons)
            {
                // В каждом полигоне слоя проверяем принадлежность точки полигону
                if (polygon.IsInside(point))
                    isInsydeQuartet = true;
            }
            return isInsydeQuartet;
        }

        /// <summary>
        /// Отрисовка маркера и окружности пользователя
        /// </summary>
        /// <param name="_radiusForSearch">Радиус буферной зоны</param>
        public void DrawPointBufferZone(List<Location> _listMarkers, int _radiusForSearch)
        {
            _renderUserPoints.InitializationPoint(_gmap, _radiusForSearch, _mapModel.optimalPoint);
        }

        /// <summary>
        /// Инициализация настроек карты
        /// </summary>
        /// <param name="gMapControl">Карта</param>
        public void InitGMapControl(GMapControl gMapControl)
        {
            _gmap = gMapControl;
            // Угол карты
            _gmap.Bearing = 0;
            // Перетаскивание правой кнопки мыши
            _gmap.CanDragMap = true;
            // Перетаскивание карты левой кнопкой мыши
            _gmap.DragButton = MouseButtons.Left;
            _gmap.GrayScaleMode = true;
            // Все маркеры будут показаны
            _gmap.MarkersEnabled = true;
            // Максимальное приближение
            _gmap.MaxZoom = 17;
            // Минимальное приближение
            _gmap.MinZoom = 2;
            // Курсор мыши в центр карты
            _gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            // Отключение нигативного режима
            _gmap.NegativeMode = false;
            // Разрешение полигонов
            _gmap.PolygonsEnabled = true;
            // Разрешение маршрутов
            _gmap.RoutesEnabled = true;
            // Скрытие внешней сетки карты
            _gmap.ShowTileGridLines = false;
            // При загрузке 11-кратное увеличение
            _gmap.Zoom = 11;
            // Убрать красный крестик по центру
            _gmap.ShowCenter = false;
            // Поставщик карты
            _gmap.MapProvider = GMapProviders.GoogleMap;
            // Карта работает только с Интернетом
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            // Начальная точка загрузки карты
            _gmap.Position = new PointLatLng(47.2229, 38.9095);
        }
    }
}