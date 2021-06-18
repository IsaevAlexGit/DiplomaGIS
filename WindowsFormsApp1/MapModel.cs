using System;
using System.IO;
using System.Data;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace OptimumPharmacy
{
    public class MapModel
    {
        // Слои из библиотеки GMap.NET для отображения их на карте
        // Слой с полигоном для города
        private readonly GMapOverlay _overlayCity = new GMapOverlay("Город");
        // Слой с полигоном для районов
        private readonly GMapOverlay _overlayDistricts = new GMapOverlay("Районы");
        // Слой со всеми аптеками
        private readonly GMapOverlay _overlayPharmacy = new GMapOverlay("Аптеки");
        // Слой с полигонами кварталов города
        private readonly GMapOverlay _overlayQuartetsPolygon = new GMapOverlay("КварталыПолигоны");
        // Слой для раскраски по значкам
        private readonly GMapOverlay _overlayQuartetsIcon = new GMapOverlay("КварталыИконки");
        // Слой для проверки вхождения точки в квартал
        private readonly GMapOverlay _overlayQuartetsCheck = new GMapOverlay("КварталыИконкиПроверка");
        // Слой с маркерами пользователя
        private readonly GMapOverlay _overlayUserPharmacy = new GMapOverlay("ПользовательскиеАптеки");
        // Слой с граничными точками города для проверки вхождения точек пользователя
        private readonly GMapOverlay _overlayWithBorderPointsCityForUser = new GMapOverlay("ГраничныеТочкиГорода");

        // Список граничных точек города для отображения на карте
        public List<Location> listPointsCity = new List<Location>();
        // Список граничных точек города для проверки вхождения точек пользователя в его границы
        public List<Location> listWithBorderPointsCityForUser = new List<Location>();
        // Список точек, поставленных пользователем на карте
        public List<Location> listPointsUser = new List<Location>();
        // Список районов города
        public List<District> listPointsDistrict = new List<District>();
        // Список аптек
        public List<Pharmacy> listPointsPharmacy = new List<Pharmacy>();
        // Список кварталов
        public List<Quartet> listPointsQuartet = new List<Quartet>();
        // Список буферных зон
        public List<BufferZone> listPointsBufferZone = new List<BufferZone>();

        // Собственные слои - библиотечный слой, список точек, название слоя, значок для отображения маркеров слоя
        // Слой с полигоном для города
        public SublayerLocation sublayerCity = new SublayerLocation("Город", "");
        // Слой с маркерами пользователя
        public SublayerLocation sublayerUserPharmacy = new SublayerLocation("ПользовательскиеАптеки", @"Icon/iconUserPharma.png");
        // Слой с граничными точками города для проверки вхождения точек пользователя
        public SublayerLocation sublayerBorderPointsCityForUser = new SublayerLocation("ПользовательскиеАптеки", @"Icon/iconUserPharma.png");
        // Слой с полигоном для районов
        public SublayerDistrict sublayerDistrict = new SublayerDistrict("Район", "");
        // Слой со всеми аптеками
        public SublayerPharmacy sublayerPharmacy = new SublayerPharmacy("Аптека", @"Icon/iconPharmacy_v3.png");
        // Слой с полигонами кварталов города
        public SublayerQuartet sublayerQuartetPolygon = new SublayerQuartet("КварталыПолигоны", "");
        // Слой для раскраски по значкам
        public SublayerQuartet sublayerQuartetIcon = new SublayerQuartet("КварталыИконки", "");
        // Слой для проверки вхождения точки в квартал
        public SublayerQuartet sublayerQuartetCheck = new SublayerQuartet("КварталыИконкиПроверка", "");

        // Настройка для того, чтобы программа работала на английской версии Windows
        private readonly CultureInfo _cultureInfo = new CultureInfo("ru-RU");

        // Три значка для раскраски полигонов
        public string iconFew = @"Icon/icon_few.png";          // красный - мало
        public string iconMiddle = @"Icon/icon_middle.png";    // желтый - среднее
        public string iconLot = @"Icon/icon_lot.png";          // зеленый - много

        // Радиус буферной зоны, по умолчнаию 500 метров
        public int radiusBufferZone = 500;

        // Временный список для граничных точек квартала
        public List<PointLatLng> tempListForQuartet;

        // Режим раскраски карты, 1 - аптеки, 2 - жители, 3 - пенсионеры
        public int modeColorCoding = 0;

        // Минимум, максимум и количество оттенков для раскраски кварталов по аптекам
        public int minPharmacy = 0;
        public int maxPharmacy = 7;
        public int numberOfShadesPharmacy = 7;
        // Минимум, максимум и количество оттенков для раскраски кварталов по жителям
        public int minResidents = 0;
        public int maxResidents = 4000;
        public int numberOfShadesResidents = 8;
        // Минимум, максимум и количество оттенков для раскраски кварталов по пенсионерам
        public int minRetired = 0;
        public int maxRetired = 1500;
        public int numberOfShadesRetired = 8;

        // Веса важности критериев
        public double weightResidents = 0.33;
        public double weightRetired = 0.33;
        public double weightPharmacy = 0.34;

        // Оптимальная точка
        public BufferZone optimalPoint = new BufferZone(0, 0, 0, 0, 0, 0, 0);

        // Загруженный пользователем значок для отображения аптек
        public string iconPharmacyUser = @"Icon/iconPharmacy_v3.png";

        /// <summary>
        /// Инициализация всех слоев
        /// </summary>
        public MapModel()
        {
            _ReadingFilesWithInfo();
            _ConnectMySublayerWithLibraryOverlay();
        }

        /// <summary>
        /// Чтение всех данных и заполнение списков точек для всех слоев
        /// </summary>
        private void _ReadingFilesWithInfo()
        {
            // Если файлы, поставляемые с приложением не найдены
            try
            {
                sublayerCity.listWithLocation = _ReadingPointsCity(@"Data\dataTaganrog.csv");
                sublayerDistrict.listWithDistricts = _ReadingPointsDistricts(@"Data\dataDistrict.csv");
                sublayerPharmacy.listWithPharmacy = _ReadingPointsPharmacy(@"Data\dataPharmacy.csv");
                sublayerQuartetPolygon.listWithQuartets = _ReadingPointsQuartets(@"Data\dataQuartet.csv");
                sublayerBorderPointsCityForUser.listWithLocation = _ReadingBorderCityForUser(@"Data\dataBorderCityForUser.csv");
                sublayerQuartetIcon.listWithQuartets = sublayerQuartetPolygon.listWithQuartets;
                sublayerQuartetCheck.listWithQuartets = sublayerQuartetPolygon.listWithQuartets;
                sublayerUserPharmacy.listWithLocation = listPointsUser;
            }
            catch
            {
                // Аварийный выход
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Инициализация собственных слоев
        /// </summary>
        private void _ConnectMySublayerWithLibraryOverlay()
        {
            // Привязка библиотечных слоев к нашим
            sublayerCity.overlay = _overlayCity;
            sublayerDistrict.overlay = _overlayDistricts;
            sublayerPharmacy.overlay = _overlayPharmacy;
            sublayerQuartetPolygon.overlay = _overlayQuartetsPolygon;
            sublayerQuartetIcon.overlay = _overlayQuartetsIcon;
            sublayerQuartetCheck.overlay = _overlayQuartetsCheck;
            sublayerUserPharmacy.overlay = _overlayUserPharmacy;
            sublayerBorderPointsCityForUser.overlay = _overlayWithBorderPointsCityForUser;
            // Установить всем слоям видимость
            sublayerCity.overlay.IsVisibile = false;
            sublayerDistrict.overlay.IsVisibile = false;
            sublayerPharmacy.overlay.IsVisibile = false;
            sublayerQuartetPolygon.overlay.IsVisibile = false;
            sublayerQuartetIcon.overlay.IsVisibile = false;
            sublayerQuartetCheck.overlay.IsVisibile = false;
            sublayerUserPharmacy.overlay.IsVisibile = false;
            sublayerBorderPointsCityForUser.overlay.IsVisibile = false;
        }

        /// <summary>
        /// Заполнение списка граничных точек города для проверки вхождения в него точек пользователя
        /// </summary>
        /// <param name="_FileNameForReading">Путь к файлу</param>
        /// <returns>Список граничных точек для города</returns>
        private List<Location> _ReadingBorderCityForUser(string fileNameForReading)
        {
            using (StreamReader filereader = new StreamReader(fileNameForReading, Encoding.GetEncoding(1251)))
            {
                while (!filereader.EndOfStream)
                {
                    string OneString = filereader.ReadLine();
                    string[] SplitOneString = OneString.Split(new char[] { ';' });
                    listWithBorderPointsCityForUser.Add(new Location(Convert.ToDouble(SplitOneString[0], _cultureInfo),
                        Convert.ToDouble(SplitOneString[1], _cultureInfo)));
                }
            }
            return listWithBorderPointsCityForUser;
        }

        /// <summary>
        /// Заполнение списка граничных точек города
        /// </summary>
        /// <param name="_FileNameForReading">Путь к файлу</param>
        /// <returns>Список граничных точек для города</returns>
        private List<Location> _ReadingPointsCity(string fileNameForReading)
        {
            using (StreamReader filereader = new StreamReader(fileNameForReading, Encoding.GetEncoding(1251)))
            {
                while (!filereader.EndOfStream)
                {
                    string OneString = filereader.ReadLine();
                    string[] SplitOneString = OneString.Split(new char[] { ';' });
                    listPointsCity.Add(new Location(Convert.ToDouble(SplitOneString[0], _cultureInfo),
                        Convert.ToDouble(SplitOneString[1], _cultureInfo)));
                }
            }
            return listPointsCity;
        }

        /// <summary>
        /// Заполнение списка аптек
        /// </summary>
        /// <param name="_FileNameForReading">Путь к файлу</param>
        /// <returns>Список с данными об аптеках города</returns>
        private List<Pharmacy> _ReadingPointsPharmacy(string fileNameForReading)
        {
            using (StreamReader filereader = new StreamReader(fileNameForReading, Encoding.GetEncoding(1251)))
            {
                while (!filereader.EndOfStream)
                {
                    string OneString = filereader.ReadLine();
                    string[] SplitOneString = OneString.Split(new char[] { ';' });
                    listPointsPharmacy.Add(new Pharmacy
                        (Convert.ToInt32(SplitOneString[0]), Convert.ToDouble(SplitOneString[1], _cultureInfo),
                        Convert.ToDouble(SplitOneString[2], _cultureInfo), SplitOneString[3], SplitOneString[4], SplitOneString[5],
                        SplitOneString[6], SplitOneString[7], Convert.ToDouble(SplitOneString[8], _cultureInfo),
                        Convert.ToDouble(SplitOneString[9], _cultureInfo)));
                }
            }
            return listPointsPharmacy;
        }

        /// <summary>
        /// Заполнение списка данными о районах города
        /// </summary>
        /// <param name="_FileNameForReading">Путь к файлу</param>
        /// <returns>Список с данными о районах города</returns>
        private List<District> _ReadingPointsDistricts(string fileNameForReading)
        {
            List<Location> tempListPoints = new List<Location>();
            using (StreamReader filereader = new StreamReader(fileNameForReading, Encoding.GetEncoding(1251)))
            {
                while (!filereader.EndOfStream)
                {
                    string OneString = filereader.ReadLine();
                    string[] SplitOneString = OneString.Split(new char[] { ';' });

                    int ID = Convert.ToInt32(SplitOneString[0]);
                    string NameDistrict = Convert.ToString(SplitOneString[1]);
                    double CentreX = Convert.ToDouble(SplitOneString[2], _cultureInfo);
                    double CentreY = Convert.ToDouble(SplitOneString[3], _cultureInfo);
                    int CountBoundaryPoints = Convert.ToInt32(SplitOneString[4]);
                    tempListPoints = new List<Location>();

                    for (int j = 5; j <= CountBoundaryPoints * 2;)
                    {
                        tempListPoints.Add(new Location(Convert.ToDouble(SplitOneString[j], _cultureInfo),
                            Convert.ToDouble(SplitOneString[j + 1], _cultureInfo)));
                        j += 2;
                    }
                    listPointsDistrict.Add(new District(ID, NameDistrict, CentreX, CentreY, CountBoundaryPoints, tempListPoints));
                }
            }
            return listPointsDistrict;
        }

        /// <summary>
        /// Заполнение списка кварталов
        /// </summary>
        /// <param name="_FileNameForReading">Путь к файлу</param>
        /// <returns>Список с данными о кварталах города</returns>
        private List<Quartet> _ReadingPointsQuartets(string fileNameForReading)
        {
            listPointsQuartet.Clear();
            List<Location> tempListPoints = new List<Location>();
            using (StreamReader filereader = new StreamReader(fileNameForReading, Encoding.GetEncoding(1251)))
            {
                while (!filereader.EndOfStream)
                {
                    string OneString = filereader.ReadLine();
                    string[] SplitOneString = OneString.Split(new char[] { ';' });

                    int ID = Convert.ToInt32(SplitOneString[0]);
                    int CountBoundaryPoints = Convert.ToInt32(SplitOneString[1]);
                    tempListPoints = new List<Location>();

                    for (int j = 2; j <= CountBoundaryPoints * 2;)
                    {
                        tempListPoints.Add(new Location(Convert.ToDouble(SplitOneString[j], _cultureInfo),
                            Convert.ToDouble(SplitOneString[j + 1], _cultureInfo)));
                        j += 2;
                    }

                    double CentreX = Convert.ToDouble(SplitOneString[CountBoundaryPoints * 2 + 2], _cultureInfo);
                    double CentreY = Convert.ToDouble(SplitOneString[CountBoundaryPoints * 2 + 3], _cultureInfo);
                    int CountOfPharmacy = Convert.ToInt32(SplitOneString[CountBoundaryPoints * 2 + 4]);
                    int CountOfResidents = Convert.ToInt32(SplitOneString[CountBoundaryPoints * 2 + 5]);
                    int CountOfRetired = Convert.ToInt32(SplitOneString[CountBoundaryPoints * 2 + 6]);
                    listPointsQuartet.Add(new Quartet(ID, CountBoundaryPoints, tempListPoints, CentreX, CentreY, 
                        CountOfPharmacy, CountOfResidents, CountOfRetired));
                }
            }
            return listPointsQuartet;
        }

        /// <summary>
        /// Создание таблицы из кварталов
        /// </summary>
        /// <returns>Таблица, заполненная данными из списка кварталов</returns>
        public DataTable CreateTableFromQuartets()
        {
            // Создание таблицы
            DataTable dateTableQuartets = new DataTable();
            // Добавление столбцов для таблицы
            dateTableQuartets.Columns.Add("ID", typeof(int));
            dateTableQuartets.Columns.Add("N", typeof(int));
            dateTableQuartets.Columns.Add("List", typeof(List<Location>));
            dateTableQuartets.Columns.Add("X", typeof(double));
            dateTableQuartets.Columns.Add("Y", typeof(double));
            dateTableQuartets.Columns.Add("Phar", typeof(int));
            dateTableQuartets.Columns.Add("People", typeof(int));
            dateTableQuartets.Columns.Add("Olds", typeof(int));

            // Заполнение таблицы данными из списка кварталов
            for (int i = 0; i < listPointsQuartet.Count; i++)
            {
                DataRow row = dateTableQuartets.NewRow();
                row["ID"] = listPointsQuartet[i].idQuartet;
                row["N"] = listPointsQuartet[i].countBoundaryPoints;
                row["List"] = listPointsQuartet[i].listBoundaryPoints;
                row["X"] = listPointsQuartet[i].xCentreOfQuartet;
                row["Y"] = listPointsQuartet[i].yCentreOfQuartet;
                row["Phar"] = listPointsQuartet[i].countOfPharmacy;
                row["People"] = listPointsQuartet[i].countOfResidents;
                row["Olds"] = listPointsQuartet[i].countOfRetired;
                dateTableQuartets.Rows.Add(row);
            }
            return dateTableQuartets;
        }

        /// <summary>
        /// Определение цвета, в который будет окрашен полигон
        /// </summary>
        /// <param name="valueForColoring">Число для раскраски</param>
        /// <param name="minValueColoring">Минимум раскраски</param>
        /// <param name="maxValueColoring">Максимум раскраски</param>
        /// <param name="CountOfGrids">Количество оттенков</param>
        /// <param name="CountOfSteps">Количество шагов</param>
        /// <returns>Номер оттенка</returns>
        public int GetnumberShade(double valueForColoring, double minValueColoring, double maxValueColoring, int countOfGrids, double countOfSteps)
        {
            // Границы левого и правого прямоугольника
            double leftBorder, rightBorder;
            // Номер оттенка для раскраски
            int numberShade = -1;

            // Для каждого прямоугольника
            for (int i = 0; i < countOfGrids; i++)
            {
                // Левый крайн - минимум + шаг*на количество уже сделанных шагов
                leftBorder = minValueColoring + countOfSteps * i;
                // Правый край = левый + шаг
                rightBorder = leftBorder + countOfSteps;

                // Если число для раскраски больше левого и меньше правого
                if ((valueForColoring >= leftBorder) && (valueForColoring < rightBorder))
                    numberShade = i;
            }

            // Если число меньше минимума, то раскраска - 0 - белая - самая левая граница
            if (valueForColoring <= minValueColoring)
                numberShade = 0;
            // Если число больше максимум, то раскраска - 1 - самая яркая - максимальный оттенок
            if (valueForColoring >= maxValueColoring)
                numberShade = countOfGrids - 1;
            return numberShade;
        }

        /// <summary>
        /// Вычисление для каждого полигона у слоя _SublayerUserPharmacy количества вошедших аптек, жителей и пенсионеров
        /// </summary>
        public void CreateListBufferZones()
        {
            // Очистка списка буферных зон
            listPointsBufferZone.Clear();
            // Начальные значения
            int tempPharma = 0;
            int tempResidents = 0;
            int tempRetired = 0;
            int tempID = 1;

            for (int i = 0; i < sublayerUserPharmacy.overlay.Polygons.Count; i++)
            {
                // Перед обработкой очередного полигона обнуление счетчиков после предыдущих вычислений
                tempPharma = 0;
                tempResidents = 0;
                tempRetired = 0;

                // Цикл по всем кварталам города
                for (int j = 0; j < sublayerQuartetPolygon.listWithQuartets.Count; j++)
                {
                    // Центр квартала
                    PointLatLng point = new PointLatLng(sublayerQuartetPolygon.listWithQuartets[j].xCentreOfQuartet,
                        sublayerQuartetPolygon.listWithQuartets[j].yCentreOfQuartet);
                    // Если точка квартала вошла в радиус буферной зоны, то суммируем число аптек, жителей и пенсионеров в данном квартале
                    if (sublayerUserPharmacy.overlay.Polygons[i].IsInside(point))
                    {
                        tempPharma += sublayerQuartetPolygon.listWithQuartets[j].countOfPharmacy;
                        tempResidents += sublayerQuartetPolygon.listWithQuartets[j].countOfResidents;
                        tempRetired += sublayerQuartetPolygon.listWithQuartets[j].countOfRetired;
                    }
                }
                // Когда мы для круга нашли количество вошедших в него кварталов и просуммировали все аптеки, жителей и пенсионеров этих кварталов
                // В список заносим данные о данной буферной зоне
                BufferZone zone = new BufferZone(tempID, sublayerUserPharmacy.listWithLocation[i].x,
                    sublayerUserPharmacy.listWithLocation[i].y, radiusBufferZone, tempPharma, tempResidents, tempRetired);
                listPointsBufferZone.Add(zone);
                // Увиличить ID на 1 для следующей буферной зоны
                tempID++;
            }
        }

        /// <summary>
        /// Загрузка данных пользователя об аптеках
        /// </summary>
        public void ChangeFileForPharmacy(string fileName)
        {
            // Сделать слой невидимым, убрать маркеры, очистить слой
            sublayerPharmacy.overlay.IsVisibile = false;
            sublayerPharmacy.overlay.Markers.Clear();
            sublayerPharmacy.overlay.Clear();
            // Очистить список аптек
            listPointsPharmacy.Clear();
            // Считать аптеки пользователя
            sublayerPharmacy.listWithPharmacy = _ReadingPointsPharmacy(fileName);
            sublayerPharmacy.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Загрузить данные пользователя о кварталах и населении
        /// </summary>
        public void ChangeFileForQuartet(string fileName)
        {
            // Сделать слой невидимым, убрать маркеры и полигоны, очистить слой
            sublayerQuartetPolygon.overlay.IsVisibile = false;
            sublayerQuartetPolygon.overlay.Markers.Clear();
            sublayerQuartetPolygon.overlay.Polygons.Clear();
            sublayerQuartetPolygon.overlay.Clear();

            sublayerQuartetCheck.overlay.IsVisibile = false;
            sublayerQuartetCheck.overlay.Markers.Clear();
            sublayerQuartetCheck.overlay.Polygons.Clear();
            sublayerQuartetCheck.overlay.Clear();

            sublayerQuartetIcon.overlay.IsVisibile = false;
            sublayerQuartetIcon.overlay.Markers.Clear();
            sublayerQuartetIcon.overlay.Polygons.Clear();
            sublayerQuartetIcon.overlay.Clear();

            // Очистить список кварталов
            listPointsQuartet.Clear();
            // Считать кварталы пользователя
            sublayerQuartetPolygon.listWithQuartets = _ReadingPointsQuartets(fileName);
            sublayerQuartetCheck.listWithQuartets = sublayerQuartetPolygon.listWithQuartets;
            sublayerQuartetIcon.listWithQuartets = sublayerQuartetPolygon.listWithQuartets;
            sublayerQuartetPolygon.overlay.IsVisibile = true;
        }

        /// <summary>
        /// Получение слоя SublayerCity
        /// </summary>
        /// <returns>Слой SublayerCity</returns>
        public SublayerLocation GetSublayerCity()
        {
            return sublayerCity;
        }

        /// <summary>
        /// Получение слоя SublayerDistrict
        /// </summary>
        /// <returns>Слой SublayerDistrict</returns>
        public SublayerDistrict GetSublayerDistrict()
        {
            return sublayerDistrict;
        }

        /// <summary>
        /// Получение слоя SublayerPharmacy
        /// </summary>
        /// <returns>Слой SublayerPharmacy</returns>
        public SublayerPharmacy GetSublayerPharmacy()
        {
            return sublayerPharmacy;
        }

        /// <summary>
        /// Получение слоя SublayerQuartetPolygon
        /// </summary>
        /// <returns>Слой SublayerQuartetPolygon</returns>
        public SublayerQuartet GetSublayerQuartetPolygon()
        {
            return sublayerQuartetPolygon;
        }

        /// <summary>
        /// Получение слоя SublayerQuartetIcon
        /// </summary>
        /// <returns>Слой SublayerQuartetIcon</returns>
        public SublayerQuartet GetSublayerQuartetIcon()
        {
            return sublayerQuartetIcon;
        }

        /// <summary>
        /// Получение слоя SublayerUserPoints
        /// </summary>
        /// <returns>Слой SublayerUserPoints</returns>
        public SublayerLocation GetSublayerUserPoints()
        {
            return sublayerUserPharmacy;
        }

        /// <summary>
        /// Получение слоя SublayerBorderCityForUser
        /// </summary>
        /// <returns>Слой SublayerBorderCityForUser</returns>
        public SublayerLocation GetSublayerBorderCityForUser()
        {
            return sublayerBorderPointsCityForUser;
        }

        /// <summary>
        /// Получение слоя SublayerQuartetCheck
        /// </summary>
        /// <returns>Слой SublayerQuartetCheck</returns>
        public SublayerQuartet GetSublayerQuartetCheck()
        {
            return sublayerQuartetCheck;
        }
    }
}