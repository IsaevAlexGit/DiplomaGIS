using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace OptimumPharmacy
{
    public class FileValidator
    {
        // Слой для проверки принадлежности точек границам города
        private SublayerLocation _sublayerBorderPointsCity = new SublayerLocation();

        // Константы для ошибок чтения файла
        private const string NOT_EXTST_FILE = "Такого файла не существует";
        private const string NOT_CSV_FILE = "Выберите файл .csv расширения";
        private const string NULL_NAME_FILE = "Имя файла отсутствует";
        private const string FILE_READ_ONLY = "Данный файл доступен только для чтения";
        private const string FILE_EMPTY = "Данный файл не содержит данных";
        private const string FILE_HAS_BIG_SIZE = "Данный файл слишком большого размера";
        private const string SUCCESSFUL_LOAD = "Успешно";

        // Константы для проверки аптек из файла пользователя
        private const string COORDINATES_OUTSIDE_CITY = "Координаты находятся за границами города";
        private const string WRONG_FORMAT_OPENING_TIME = "Неверный формат времени открытия аптеки";
        private const string WRONG_FORMAT_CLOSING_TIME = "Неверный формат времени закрытия аптеки";
        private const string UNSUCCESSFUL_ATTEMPT_READ_DATA = "Неверный формат хранения данных";

        // Константы для проверки кварталов из файла пользователя
        private const string NUMBER_OF_BOUNDARY_POINTS_LESS_TWO = "Количество граничных точек не может быть меньше двух";
        private const string NUMBER_OF_PHARMACY_LESS_THAN_ZERO = "Количество аптек не может быть меньше нуля";
        private const string NUMBER_OF_RESIDENTS_LESS_THAN_ZERO = "Количество жителей не может быть меньше нуля";
        private const string NUMBER_OF_RETIRED_LESS_THAN_ZERO = "Количество пенсионеров не может быть меньше нуля";

        /// <summary>
        /// Конструктор
        /// </summary>
        public FileValidator() { }

        /// <summary>
        /// Проверка csv-файла, в который производят запись оптимальной точки, открывая существующий файл
        /// </summary>
        /// <param name="pathToFile">Путь к файлу</param>
        /// <returns>Результат проверки файла</returns>
        public string FileValidationCSV(string pathToFile)
        {
            FileInfo InfoFileCSV = new FileInfo(pathToFile);
            // Если файл существует
            if (File.Exists(pathToFile))
            {
                // Если файл имеет расширение csv
                if (InfoFileCSV.Extension == ".csv")
                {
                    // Если у файла есть имя
                    if (InfoFileCSV.Name != ".csv")
                    {
                        // Если файл доступен не только для чтения
                        if (InfoFileCSV.IsReadOnly == false)
                            return SUCCESSFUL_LOAD;
                        else
                            return FILE_READ_ONLY;
                    }
                    else
                        return NULL_NAME_FILE;
                }
                else
                    return NOT_CSV_FILE;
            }
            else
                return NOT_EXTST_FILE;
        }

        /// <summary>
        /// Проверка csv-файла, в который производят запись оптимальной точки, создавая файл
        /// </summary>
        /// <param name="pathToFile">Путь к файлу</param>
        /// <returns>Результат проверки файла</returns>
        public string FileValidationCreateCSV(string pathToFile)
        {
            FileInfo InfoFileCSV = new FileInfo(pathToFile);
            // Если файл имеет расширение csv
            if (InfoFileCSV.Extension == ".csv")
            {
                // Если у файла есть имя
                if (InfoFileCSV.Name != ".csv")
                {
                    return SUCCESSFUL_LOAD;
                }
                else
                    return NULL_NAME_FILE;
            }
            else
                return NOT_CSV_FILE;
        }

        /// <summary>
        /// Запись в csv-файл информации об оптимальной точке
        /// </summary>
        /// <param name="pathFile">Путь к файлу</param>
        /// <param name="point">Оптимальная точка</param>
        public void WriteInfoOptimumToCSV(string pathFile, BufferZone point)
        {
            StringBuilder WriterCSV = new StringBuilder();
            // Создание строки с данными об оптимальной точке
            WriterCSV.AppendLine("Координата Х: " + point.x);
            WriterCSV.AppendLine("Координата Y: " + point.y);
            WriterCSV.AppendLine("Радиус поиска: " + point.lengthRadiusSearch + " м.");
            WriterCSV.AppendLine("Количество охваченных аптек: " + point.countOfPharmacy + " шт.");
            WriterCSV.AppendLine("Количество охваченных жителей: " + point.countOfResidents + " чел.");
            WriterCSV.AppendLine("Количество охваченных пенсионеров: " + point.countOfRetired + " чел.");
            // Запись данных
            File.WriteAllText(pathFile, WriterCSV.ToString(), Encoding.GetEncoding(1251));
            WriterCSV.Clear();
        }

        /// <summary>
        ///  Проверка csv-файла, из которого загружаются данные
        /// </summary>
        /// <param name="pathToFile">Путь к файлу</param>
        /// <returns>Результат проверки файла</returns>
        public string FileUserValidation(string pathToFile)
        {
            FileInfo InfoFileCSV = new FileInfo(pathToFile);
            // Если файл существует
            if (File.Exists(pathToFile))
            {
                // Если файл имеет расширение csv
                if (InfoFileCSV.Extension == ".csv")
                {
                    // Если у файла есть имя
                    if (InfoFileCSV.Name != ".csv")
                    {
                        // Если файл большого размера (больше 1Мб)
                        if (InfoFileCSV.Length < 1024700)
                        {
                            // Чтение данных из файла
                            using (StreamReader readerExcel = new StreamReader(pathToFile, Encoding.GetEncoding(1251)))
                            {
                                string AllStringsFromFileUser = readerExcel.ReadToEnd();
                                // Если файл не пустой
                                if (AllStringsFromFileUser.Length != 2)
                                    return SUCCESSFUL_LOAD;
                                else
                                    return FILE_EMPTY;
                            }
                        }
                        else
                            return FILE_HAS_BIG_SIZE;
                    }
                    else
                        return NULL_NAME_FILE;
                }
                else
                    return NOT_CSV_FILE;
            }
            else
                return NOT_EXTST_FILE;
        }

        /// <summary>
        /// Проверка файла с аптеками на целостность данных
        /// </summary>
        /// <param name="pathToFile">Путь к файлу с данными</param>
        /// <param name="overlayCity">Слой с границами города для проверки принадлежности аптек городу</param>
        /// <returns>Результат проверки файла</returns>
        public string DataValidationUserPharmacy(string pathToFile, SublayerLocation overlayCity)
        {
            _sublayerBorderPointsCity = overlayCity;
            List<Pharmacy> _ListPointsPharmacy = new List<Pharmacy>();
            List<PointLatLng> _boundaryPointsCityPolygon = new List<PointLatLng>();
            // Инициализация списка с граничными точками города
            for (int i = 0; i < _sublayerBorderPointsCity.listWithLocation.Count; i++)
                _boundaryPointsCityPolygon.Add(new PointLatLng(_sublayerBorderPointsCity.listWithLocation[i].x,
                    _sublayerBorderPointsCity.listWithLocation[i].y));
            // Создание полигона из граничных точек
            var polygon = new GMapPolygon(_boundaryPointsCityPolygon, "BordersPointsCity");

            // Если файл не смог прочитаться
            try
            {
                try
                {
                    using (StreamReader readerCsvFile = new StreamReader(pathToFile, Encoding.GetEncoding(1251)))
                    {
                        while (!readerCsvFile.EndOfStream)
                        {
                            string OneString = readerCsvFile.ReadLine();
                            string[] SplitOneString = OneString.Split(new char[] { ';' });
                            // Принадлежность точки городу
                            bool IsInsydeCity = false;

                            // Текущая аптека
                            PointLatLng point = new PointLatLng(Convert.ToDouble(SplitOneString[1]), Convert.ToDouble(SplitOneString[2]));
                            // Проверка принадлежности аптеки городу
                            if (polygon.IsInside(point))
                                IsInsydeCity = true;
                            else
                                IsInsydeCity = false;

                            if (IsInsydeCity)
                            {
                                // Если время открытия аптеки соответствует требованиям хранения данных
                                if (Convert.ToDouble(SplitOneString[8]) >= -1 && Convert.ToDouble(SplitOneString[8]) <= 25)
                                {
                                    // Если время закрытия аптеки соответствует требованиям хранения данных
                                    if (Convert.ToDouble(SplitOneString[9]) >= -1 && Convert.ToDouble(SplitOneString[9]) <= 25)
                                    {
                                        // Попытка считать данные
                                        _ListPointsPharmacy.Add(new Pharmacy(Convert.ToInt32(SplitOneString[0]), Convert.ToDouble(SplitOneString[1]),
                                            Convert.ToDouble(SplitOneString[2]), SplitOneString[3], SplitOneString[4], SplitOneString[5],
                                            SplitOneString[6], SplitOneString[7], Convert.ToDouble(SplitOneString[8]), Convert.ToDouble(SplitOneString[9])));
                                    }
                                    else
                                        return WRONG_FORMAT_CLOSING_TIME;
                                }
                                else
                                    return WRONG_FORMAT_OPENING_TIME;
                            }
                            else
                                return COORDINATES_OUTSIDE_CITY;

                        }
                        return SUCCESSFUL_LOAD;
                    }
                }
                catch (FormatException)
                {
                    return UNSUCCESSFUL_ATTEMPT_READ_DATA;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return UNSUCCESSFUL_ATTEMPT_READ_DATA;
            }
        }

        /// <summary>
        /// Проверка файла с кварталами на целостность данных
        /// </summary>
        /// <param name="pathToFile">Путь к файлу с данными</param>
        /// <param name="overlayCity">Слой с границами города для проверки принадлежности точек кварталов городу</param>
        /// <returns>Результат проверки файла</returns>
        public string DataValidationUserQuartet(string pathToFile, SublayerLocation overlayCity)
        {
            _sublayerBorderPointsCity = overlayCity;
            List<Quartet> _ListPointsQuartet = new List<Quartet>();
            List<PointLatLng> _boundaryPointsCityPolygon = new List<PointLatLng>();
            // Инициализация списка с граничными точками города
            for (int i = 0; i < _sublayerBorderPointsCity.listWithLocation.Count; i++)
                _boundaryPointsCityPolygon.Add(new PointLatLng(_sublayerBorderPointsCity.listWithLocation[i].x,
                    _sublayerBorderPointsCity.listWithLocation[i].y));
            // Создание полигона из граничных точек
            var polygon = new GMapPolygon(_boundaryPointsCityPolygon, "BordersPointsCity");

            // Если файл не смог прочитаться
            try
            {
                try
                {
                    List<Location> tempListPoints = new List<Location>();
                    using (StreamReader readerCsvFile = new StreamReader(pathToFile, Encoding.GetEncoding(1251)))
                    {
                        while (!readerCsvFile.EndOfStream)
                        {
                            string OneString = readerCsvFile.ReadLine();
                            string[] SplitOneString = OneString.Split(new char[] { ';' });
                            int ID = Convert.ToInt32(SplitOneString[0]);
                            int CountBoundaryPoints = Convert.ToInt32(SplitOneString[1]);

                            if (CountBoundaryPoints >= 3)
                            {
                                tempListPoints = new List<Location>();
                                for (int j = 2; j <= CountBoundaryPoints * 2;)
                                {
                                    tempListPoints.Add(new Location(Convert.ToDouble(SplitOneString[j]), Convert.ToDouble(SplitOneString[j + 1])));
                                    j += 2;
                                }

                                // Принадлежность граничных точек кварталов городу
                                int numberOfEnteredPoints = 0;
                                for (int i = 0; i < tempListPoints.Count; i++)
                                {
                                    // Текущая считанная точка границы
                                    PointLatLng point = new PointLatLng(tempListPoints[i].x, tempListPoints[i].y);
                                    if (polygon.IsInside(point))
                                        numberOfEnteredPoints++;
                                }

                                // Если все граничные точки квартала принадлежат городу
                                if (numberOfEnteredPoints == tempListPoints.Count)
                                {
                                    // Координаты центральной точки района
                                    double CentreX = Convert.ToDouble(SplitOneString[CountBoundaryPoints * 2 + 2]);
                                    double CentreY = Convert.ToDouble(SplitOneString[CountBoundaryPoints * 2 + 3]);
                                    bool CentrePointOfQuartetIsInsydeCity = false;
                                    PointLatLng point = new PointLatLng(CentreX, CentreY);

                                    // Проверка принадлежности центральной точки городу
                                    if (polygon.IsInside(point))
                                        CentrePointOfQuartetIsInsydeCity = true;
                                    else
                                        CentrePointOfQuartetIsInsydeCity = false;

                                    if (CentrePointOfQuartetIsInsydeCity)
                                    {
                                        // Число аптек, жителей и пенсионеров в квартале
                                        int CountOfPharmacy = Convert.ToInt32(SplitOneString[CountBoundaryPoints * 2 + 4]);
                                        int CountOfResidents = Convert.ToInt32(SplitOneString[CountBoundaryPoints * 2 + 5]);
                                        int CountOfRetired = Convert.ToInt32(SplitOneString[CountBoundaryPoints * 2 + 6]);

                                        if (CountOfPharmacy >= 0)
                                        {
                                            if (CountOfResidents >= 0)
                                            {
                                                if (CountOfRetired >= 0)
                                                {
                                                    // Попытка считать данные
                                                    _ListPointsQuartet.Add(new Quartet(ID, CountBoundaryPoints, tempListPoints, CentreX, CentreY,
                                                        CountOfPharmacy, CountOfResidents, CountOfRetired));
                                                }
                                                else
                                                    return NUMBER_OF_RETIRED_LESS_THAN_ZERO;
                                            }
                                            else
                                                return NUMBER_OF_RESIDENTS_LESS_THAN_ZERO;
                                        }
                                        else
                                            return NUMBER_OF_PHARMACY_LESS_THAN_ZERO;
                                    }
                                    else
                                        return COORDINATES_OUTSIDE_CITY;
                                }
                                else
                                    return COORDINATES_OUTSIDE_CITY;
                            }
                            else
                                return NUMBER_OF_BOUNDARY_POINTS_LESS_TWO;
                        }
                        return SUCCESSFUL_LOAD;
                    }
                }
                catch (FormatException)
                {
                    return UNSUCCESSFUL_ATTEMPT_READ_DATA;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return UNSUCCESSFUL_ATTEMPT_READ_DATA;
            }
        }
    }
}