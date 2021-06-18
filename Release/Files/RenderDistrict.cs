using System.Drawing;
using System.Collections.Generic;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace OptimumPharmacy
{
    public class RenderDistrict
    {
        // Слой для отображения районов города
        private SublayerDistrict _sublayerDistrict = new SublayerDistrict();
        // Слой для отображения города
        private SublayerLocation _ListBoundaryPointsCity = new SublayerLocation();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="gmap">Карта</param>
        /// <param name="sublayerDis">Слой с районами</param>
        /// <param name="city">Слой с городом</param>
        public RenderDistrict(GMapControl gmap, SublayerDistrict sublayerDis, SublayerLocation city)
        {
            _sublayerDistrict = sublayerDis;
            _ListBoundaryPointsCity = city;
        }

        // Список точек для построения полигона
        private List<PointLatLng> _pointsPolygon = new List<PointLatLng>();

        /// <summary>
        /// Отображение города
        /// </summary>
        /// <param name="gmap">Карта</param>
        public void DrawCity(GMapControl gmap)
        {
            // Очистить у слоя маркеры
            _sublayerDistrict.overlay.Markers.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerDistrict.overlay);
            // Очистка слоя
            _sublayerDistrict.overlay.Clear();
            // Очистка списка точек
            _pointsPolygon.Clear();

            // Создание списка точек для полигона
            for (int i = 0; i < _ListBoundaryPointsCity.listWithLocation.Count; i++)
                _pointsPolygon.Add(new PointLatLng(_ListBoundaryPointsCity.listWithLocation[i].x, _ListBoundaryPointsCity.listWithLocation[i].y));

            // Создание полигона из считанных точек
            var polygon = new GMapPolygon(_pointsPolygon, "city");
            // Заливка полигона красным цветом, прозрачностью 40
            polygon.Fill = new SolidBrush(Color.FromArgb(40, Color.Red));
            // Граница красного цвета
            polygon.Stroke = new Pen(Color.Red);
            // Добавление полигона на слой
            _sublayerDistrict.overlay.Polygons.Add(polygon);
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerDistrict.overlay);
            _sublayerDistrict.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Отображение всех районов
        /// </summary>
        /// <param name="gmap">Карта</param>
        public void DrawDistricts(GMapControl gmap)
        {
            // Очистить у слоя маркеры
            _sublayerDistrict.overlay.Markers.Clear();
            // Очистить у слоя полигоны
            _sublayerDistrict.overlay.Polygons.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerDistrict.overlay);
            // Очистка слоя
            _sublayerDistrict.overlay.Clear();
            // Очистка списка точек
            _pointsPolygon.Clear();

            // Создание списка точек для каждого квартала
            for (int i = 0; i < _sublayerDistrict.listWithDistricts.Count; i++)
            {
                _pointsPolygon = new List<PointLatLng>();
                for (int j = 0; j < _sublayerDistrict.listWithDistricts[i].listBoundaryPoints.Count; j++)
                    _pointsPolygon.Add(new PointLatLng(_sublayerDistrict.listWithDistricts[i].listBoundaryPoints[j].x,
                        _sublayerDistrict.listWithDistricts[i].listBoundaryPoints[j].y));

                // В центре района установить маркер
                GMarkerGoogle CentreDistrict = new GMarkerGoogle(new PointLatLng(_sublayerDistrict.listWithDistricts[i].xCentreOfDistrict,
                    _sublayerDistrict.listWithDistricts[i].yCentreOfDistrict), GMarkerGoogleType.yellow_dot);
                CentreDistrict.ToolTip = new GMapRoundedToolTip(CentreDistrict);
                // Добавить маркер на слой
                _sublayerDistrict.overlay.Markers.Add(CentreDistrict);
                // Создание полигона из считанных точек
                var polygon = new GMapPolygon(_pointsPolygon, "district");
                // Заливка полигона красным цветом, прозрачностью 40
                polygon.Fill = new SolidBrush(Color.FromArgb(40, Color.Red));
                // Граница красного цвета
                polygon.Stroke = new Pen(Color.Red);
                // Добавление полигона на слой
                _sublayerDistrict.overlay.Polygons.Add(polygon);
            }
            // Добавление слоя на карту
            gmap.Overlays.Add(_sublayerDistrict.overlay);
            _sublayerDistrict.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Очистка отображения районов или города
        /// </summary>
        /// <param name="gmap">Карта</param>
        public void ClearDistrict(GMapControl gmap)
        {
            // Очистить у слоя маркеры
            _sublayerDistrict.overlay.Markers.Clear();
            // Очистить у слоя полигоны
            _sublayerDistrict.overlay.Polygons.Clear();
            // Убрать слой с карты
            gmap.Overlays.Remove(_sublayerDistrict.overlay);
            // Убрать видимость слоя
            _sublayerDistrict.overlay.IsVisibile = false;
            // Очистка слоя
            _sublayerDistrict.overlay.Clear();
            // Очистка списка точек
            _pointsPolygon.Clear();
        }
    }
}