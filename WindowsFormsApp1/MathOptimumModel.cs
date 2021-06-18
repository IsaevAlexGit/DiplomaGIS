using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace OptimumPharmacy
{
    public class MathOptimumModel
    {
        // Список буферных зон, который нормализуется
        private List<BufferZone> _listForNormalization = new List<BufferZone>();
        // Оптимальная точка
        private BufferZone _bestPoint = new BufferZone();

        // Веса важности
        private readonly double _weightPharma;
        private readonly double _weightResid;
        private readonly double _weightRetir;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="_arrayBuffers">Список буферных зон</param>
        /// <param name="_wPharma">Важность критерия "Аптеки"</param>
        /// <param name="_wResidents">Важность критерия "Жители"</param>
        /// <param name="_wRetired">Важность критерия "Пенсионеры"</param>
        public MathOptimumModel(List<BufferZone> _arrayBuffers, double _wPharma, double _wResidents, double _wRetired)
        {
            _listForNormalization = _arrayBuffers;
            _weightPharma = _wPharma;
            _weightResid = _wResidents;
            _weightRetir = _wRetired;
        }

        /// <summary>
        /// Получение оптимальной точки
        /// </summary>
        /// <returns>Оптимальная точка</returns>
        public BufferZone GetOptimum()
        {
            // Сохранить значения массива до нормализации
            _WriteTxtBufferZones();
            // Минимизация параметра аптек
            _MaximizationOfPharmacies();
            // Поиск минимума и максимума для каждого критерия
            _SearchMaxMinForEachCriterion();
            // Нормализация
            _Normalization();
            // Линейная свертка
            _LinearConvolution();
            // Мультипликативная свертка
            _MultiplicativeConvolution();
            // Максиминная свертка
            _MaxiMinConvolution();
            // Принятие решения
            _SearchForTheOptimum();
            // Вернуть лучшую точку
            return _bestPoint;
        }

        /// <summary>
        /// Максимизация параметра аптек
        /// </summary>
        private void _MaximizationOfPharmacies()
        {
            // Для каждой буферной зоны значение аптек заменяется отрицательным, так как критерий "Аптеки" минимизируется
            for (int i = 0; i < _listForNormalization.Count; i++)
                _listForNormalization[i].countOfPharmacy = _listForNormalization[i].countOfPharmacy * (-1);
        }

        // Для нормализации надо найти максимум и минимум по каждому критерию
        private double _maxPharma = 0;
        private double _minPharma = 5000;
        private double _maxResidents = 0;
        private double _minResidents = 250000;
        private double _maxRetired = 0;
        private double _minRetired = 150000;

        /// <summary>
        /// Поиск максимума и минимума для каждого критерия
        /// </summary>
        private void _SearchMaxMinForEachCriterion()
        {
            // Ищем максимум и минимум для аптек
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                if (_listForNormalization[i].countOfPharmacy >= _maxPharma)
                    _maxPharma = _listForNormalization[i].countOfPharmacy;
                if (_listForNormalization[i].countOfPharmacy <= _minPharma)
                    _minPharma = _listForNormalization[i].countOfPharmacy;
            }

            // Ищем максимум и минимум для жителей
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                if (_listForNormalization[i].countOfResidents >= _maxResidents)
                    _maxResidents = _listForNormalization[i].countOfResidents;
                if (_listForNormalization[i].countOfResidents <= _minResidents)
                    _minResidents = _listForNormalization[i].countOfResidents;
            }

            // Ищем максимум и минимум для пенсионеров
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                if (_listForNormalization[i].countOfRetired >= _maxRetired)
                    _maxRetired = _listForNormalization[i].countOfRetired;
                if (_listForNormalization[i].countOfRetired <= _minRetired)
                    _minRetired = _listForNormalization[i].countOfRetired;
            }
        }

        /// <summary>
        /// Нормализация всех критериев
        /// </summary>
        private void _Normalization()
        {
            // Разность между максимумом и минимумом для каждого критерия
            double DiffPharma = _maxPharma - _minPharma;
            double DiffRes = _maxResidents - _minResidents;
            double DiffRet = _maxRetired - _minRetired;

            // Нормализация: (текущее - минимум) / (максимум - минимум)
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                // Для текущих нормализованных значений округлить результат до 7 знаков после запятой
                if (DiffPharma != 0)
                {
                    _listForNormalization[i].countOfPharmacy = (_listForNormalization[i].countOfPharmacy - _minPharma) / DiffPharma;
                    _listForNormalization[i].countOfPharmacy = Math.Round(_listForNormalization[i].countOfPharmacy, 7);
                }
                if (DiffRes != 0)
                {
                    _listForNormalization[i].countOfResidents = (_listForNormalization[i].countOfResidents - _minResidents) / DiffRes;
                    _listForNormalization[i].countOfResidents = Math.Round(_listForNormalization[i].countOfResidents, 7);
                }
                if (DiffRet != 0)
                {
                    _listForNormalization[i].countOfRetired = (_listForNormalization[i].countOfRetired - _minRetired) / DiffRet;
                    _listForNormalization[i].countOfRetired = Math.Round(_listForNormalization[i].countOfRetired, 7);
                }
            }
        }

        private int _idBestPointByLinearConvolution = -1;
        /// <summary>
        /// Линейная свертка
        /// </summary>
        private void _LinearConvolution()
        {
            // Максимум для линейной свертки
            double MaxLinearConvolution = -1;
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                double temporaryVariable = _listForNormalization[i].countOfPharmacy * _weightPharma +
                    _listForNormalization[i].countOfResidents * _weightResid + _listForNormalization[i].countOfRetired * _weightRetir;
                if (temporaryVariable >= MaxLinearConvolution)
                {
                    MaxLinearConvolution = temporaryVariable;
                    _idBestPointByLinearConvolution = _listForNormalization[i].idBufferZone;
                }
            }
        }

        private int _idBestPointByMultiplicativeConvolution = -1;
        /// <summary>
        /// Мультипликативная свертка
        /// </summary>
        private void _MultiplicativeConvolution()
        {
            // Максимум для мультипликативной свертки
            double MaxMultiplicativeConvolution = -1;
            double temporaryVariable = 1;
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                // Флаг входа в одну из веток
                bool flag = false;
                // Сбросили прошлое вычисление
                temporaryVariable = 1;

                // Если вес аптек и число аптек не 0
                if (_weightPharma != 0 && _listForNormalization[i].countOfPharmacy != 0)
                {
                    flag = true;
                    temporaryVariable = temporaryVariable * _listForNormalization[i].countOfPharmacy * _weightPharma;
                }
                // Если вес жителей и число жителей не 0
                if (_weightResid != 0 && _listForNormalization[i].countOfResidents != 0)
                {
                    flag = true;
                    temporaryVariable = temporaryVariable * _listForNormalization[i].countOfResidents * _weightResid;
                }
                // Если вес пенсионеров и число пенсионеров не 0
                if (_weightRetir != 0 && _listForNormalization[i].countOfRetired != 0)
                {
                    flag = true;
                    temporaryVariable = temporaryVariable * _listForNormalization[i].countOfRetired * _weightRetir;
                }
                // Если везде были нули и calculate не изменился
                if (temporaryVariable == 1 && flag == false)
                    temporaryVariable = 0;

                if (temporaryVariable >= MaxMultiplicativeConvolution)
                {
                    MaxMultiplicativeConvolution = temporaryVariable;
                    _idBestPointByMultiplicativeConvolution = _listForNormalization[i].idBufferZone;
                }
            }
        }

        private int _idBestPointByMaxiMinConvolution = -1;
        /// <summary>
        /// Максиминная свертка
        /// </summary>
        private void _MaxiMinConvolution()
        {
            // Максимум для максиминной свертки
            double MaxMaxiMinConvolution = -1;
            // Минимум среди критериев
            double temporaryVariable;
            // Свертка максиминная - минимум в строке - максимум из столбца минимумов
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                // Найти минимум среди трех критериев одной альтернативы
                temporaryVariable = _FindMinFromThreeValues(_listForNormalization[i].countOfPharmacy,
                    _listForNormalization[i].countOfResidents, _listForNormalization[i].countOfRetired);
                // Среди этих минимумов найти максимум
                if (temporaryVariable >= MaxMaxiMinConvolution)
                {
                    MaxMaxiMinConvolution = temporaryVariable;
                    _idBestPointByMaxiMinConvolution = _listForNormalization[i].idBufferZone;
                }
            }
        }

        // Список буферных зон с карты
        private List<BufferZone> _listWithStartZones = new List<BufferZone>();
        /// <summary>
        /// Принятие решения, какая же точка оптимальная после всех расчетов
        /// </summary>
        private void _SearchForTheOptimum()
        {
            _ReadTxtBufferZones();
            double theMostImportantCriterion;
            // Список буферных зон, которых будет три - это самые лучшие по мнению каждой свертки
            List<BufferZone> _ThreeZones = new List<BufferZone>();
            // ID лучшей точки
            int idBestPoint = -1;

            // Имея три оптимальных точки с точки зрения трех сверток, определяемся, какая точка будет выдана пользователю
            // Если все свертки нашли одну оптимальную точку
            if (_idBestPointByLinearConvolution == _idBestPointByMultiplicativeConvolution
                && _idBestPointByLinearConvolution == _idBestPointByMaxiMinConvolution)
            {
                for (int i = 0; i < _listWithStartZones.Count; i++)
                    if (_listWithStartZones[i].idBufferZone == _idBestPointByLinearConvolution)
                        _bestPoint = _listWithStartZones[i];
            }
            // Если согласны две из трех сверток
            else
            {
                // Если согласна линейная и мультипликативная
                if (_idBestPointByLinearConvolution == _idBestPointByMultiplicativeConvolution)
                {
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                        if (_listWithStartZones[i].idBufferZone == _idBestPointByLinearConvolution)
                            _bestPoint = _listWithStartZones[i];
                }
                // Если согласна линейная и максиминная
                else if (_idBestPointByLinearConvolution == _idBestPointByMaxiMinConvolution)
                {
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                        if (_listWithStartZones[i].idBufferZone == _idBestPointByLinearConvolution)
                            _bestPoint = _listWithStartZones[i];
                }
                // Если согласна мультипликативная и максиминная
                else if (_idBestPointByMultiplicativeConvolution == _idBestPointByMaxiMinConvolution)
                {
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                        if (_listWithStartZones[i].idBufferZone == _idBestPointByMultiplicativeConvolution)
                            _bestPoint = _listWithStartZones[i];
                }
                // Если все три свертки дали разные оптимальные точки - смотрим по важности критерия
                else
                {
                    // Создаем список самых лучших буферных зон
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                    {
                        // Сюда попадает три точки, ID которых из общего списка совпадают с ID лучших альтернатив по мнению трех сверток
                        if (_listWithStartZones[i].idBufferZone == _idBestPointByLinearConvolution
                            || _listWithStartZones[i].idBufferZone == _idBestPointByMultiplicativeConvolution
                            || _listWithStartZones[i].idBufferZone == _idBestPointByMaxiMinConvolution)
                        {
                            // Список трех лучших точек по мнению трех сверток
                            _ThreeZones.Add(_listWithStartZones[i]);
                        }
                    }

                    // Какой для пользователя самый важный критерий
                    theMostImportantCriterion = _FindMaxCriterion(_weightPharma, _weightResid, _weightRetir);
                    // Если это критерий для аптек
                    if (theMostImportantCriterion == _weightPharma)
                    {
                        // Минимум для аптек
                        double MinPharmaInZone = 5000;
                        // В списке лучших зон ищем, где меньше аптек
                        for (int i = 0; i < _ThreeZones.Count; i++)
                        {
                            // Ищем точку, охватившую минимум аптек
                            if (_ThreeZones[i].countOfPharmacy <= MinPharmaInZone)
                            {
                                // Если изначально в точке 0 аптек, 0 жителей и 0 пенсионеров, то она не учитывается
                                if (_ThreeZones[i].countOfPharmacy == 0 && _ThreeZones[i].countOfResidents == 0 && _ThreeZones[i].countOfRetired == 0)
                                {

                                }
                                else
                                {
                                    MinPharmaInZone = _ThreeZones[i].countOfPharmacy;
                                    // ID лучшей точки в списке всех лучших зон
                                    idBestPoint = _ThreeZones[i].idBufferZone;
                                }
                            }
                        }
                    }
                    // Если это критерий для жителей
                    else if (theMostImportantCriterion == _weightResid)
                    {
                        // Максимум для жителей
                        double MaxResidentsInZone = -1;
                        // В списке лучших зон ищем где больше жителей
                        for (int i = 0; i < _ThreeZones.Count; i++)
                        {
                            // Ищем точку, охватившую максимум жителей
                            if (_ThreeZones[i].countOfResidents >= MaxResidentsInZone)
                            {
                                // Если изначально в точке 0 аптек, 0 жителей и 0 пенсионеров, то она не учитывается
                                if (_ThreeZones[i].countOfPharmacy == 0 && _ThreeZones[i].countOfResidents == 0 && _ThreeZones[i].countOfRetired == 0)
                                {

                                }
                                else
                                {
                                    MaxResidentsInZone = _ThreeZones[i].countOfResidents;
                                    // ID лучшей точки в списке всех лучших зон
                                    idBestPoint = _ThreeZones[i].idBufferZone;
                                }
                            }
                        }
                    }
                    // Если это критерий для пенсионеров
                    else
                    {
                        // Максимум для пенсионеров
                        double MaxRetiredInZone = -1;
                        // В списке лучших зон ищем где больше пенсионеров
                        for (int i = 0; i < _ThreeZones.Count; i++)
                        {
                            // Ищем точку, охватившую максимум пенсионеров
                            if (_ThreeZones[i].countOfRetired >= MaxRetiredInZone)
                            {
                                // Если изначально в точке 0 аптек, 0 жителей и 0 пенсионеров, то она не учитывается
                                if (_ThreeZones[i].countOfPharmacy == 0 && _ThreeZones[i].countOfResidents == 0 && _ThreeZones[i].countOfRetired == 0)
                                {

                                }
                                else
                                {
                                    MaxRetiredInZone = _ThreeZones[i].countOfRetired;
                                    // ID лучшей точки в списке всех лучших зон
                                    idBestPoint = _ThreeZones[i].idBufferZone;
                                }
                            }
                        }
                    }
                    // По итогу присвоить оптимальной точке одно из трех значений
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                        if (_listWithStartZones[i].idBufferZone == idBestPoint)
                            _bestPoint = _listWithStartZones[i];
                }
            }
        }

        /// <summary>
        /// Поиск минимума среди трёх чисел - минимум по трем критериям одной альтернативы
        /// </summary>
        /// <param name="x">Нормализованное значение критерия "Аптеки"</param>
        /// <param name="y">Нормализованное значение критерия "Жители"</param>
        /// <param name="z">Нормализованное значение критерия "Пенсионеры"</param>
        /// <returns></returns>
        private double _FindMinFromThreeValues(double normalPharma, double normalResidents, double normalRetired)
        {
            return Math.Min(normalPharma, Math.Min(normalResidents, normalRetired));
        }

        /// <summary>
        /// Поиск максимума среди трех весов - максимум изтрех весов, равны они быть не могут
        /// </summary>
        /// <param name="x">Важность критерия "Аптеки"</param>
        /// <param name="y">Важность критерия "Жители"</param>
        /// <param name="z">Важность критерия "Пенсионеры"</param>
        /// <returns></returns>
        private double _FindMaxCriterion(double weightPharma, double weightResidents, double weightRetired)
        {
            return Math.Max(weightPharma, Math.Max(weightResidents, weightRetired));
        }

        // Настройка для того, чтобы программа работала на английской версии Windows
        private readonly CultureInfo _cultureInfo = new CultureInfo("ru-RU");

        /// <summary>
        /// Сохранение данных о буферных зонах в текстовый файл
        /// </summary>
        private void _WriteTxtBufferZones()
        {
            // Если файл, поставляемый с приложением не найден
            try
            {
                FileStream fileStream = new FileStream(@"Data\FilesTXT\dataBufferZones.txt", FileMode.Create, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.GetEncoding(1251));
                for (int i = 0; i < _listForNormalization.Count; i++)
                {
                    streamWriter.Write(_listForNormalization[i].idBufferZone + ";" + _listForNormalization[i].x.ToString(_cultureInfo) + ";" +
                        _listForNormalization[i].y.ToString(_cultureInfo) + ";" + _listForNormalization[i].lengthRadiusSearch + ";" +
                        _listForNormalization[i].countOfPharmacy + ";" + _listForNormalization[i].countOfResidents + ";" +
                        _listForNormalization[i].countOfRetired);
                    streamWriter.WriteLine();
                }
                streamWriter.Close();
            }
            catch
            {
                // Аварийный выход
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Чтение текстового файла с данными о буферных зонах
        /// </summary>
        private void _ReadTxtBufferZones()
        {
            // Если файл, поставляемый с приложением не найден
            try
            {
                string[] ArrayBufferZones = File.ReadAllLines(@"Data\FilesTXT\dataBufferZones.txt", Encoding.GetEncoding(1251));
                for (int i = 0; i < ArrayBufferZones.Length; i++)
                {
                    string[] BufferZoneObj = ArrayBufferZones[i].Split(new char[] { ';' });
                    _listWithStartZones.Add(new BufferZone(Convert.ToInt32(BufferZoneObj[0]), Convert.ToDouble(BufferZoneObj[1], _cultureInfo),
                        Convert.ToDouble(BufferZoneObj[2], _cultureInfo), Convert.ToInt32(BufferZoneObj[3]), Convert.ToDouble(BufferZoneObj[4]),
                        Convert.ToDouble(BufferZoneObj[5]), Convert.ToDouble(BufferZoneObj[6])));
                }
            }
            catch
            {
                // Аварийный выход
                Environment.Exit(0);
            }
        }
    }
}