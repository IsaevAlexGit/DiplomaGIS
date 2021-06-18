using System;
using System.Collections.Generic;

namespace MyCalcLib
{
    public class BufferZone
    {
        public int IDBufferZone { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int LengthRadiusSearch { get; set; }
        public double CountOfPharmacy { get; set; }
        public double CountOfResidents { get; set; }
        public double CountOfRetired { get; set; }

        public BufferZone() { }

        // Конструктор
        public BufferZone(int id, double x, double y, int lengthRadius, int countpharmacy, int countresidents, int countretired)
        {
            IDBufferZone = id;
            X = x;
            Y = y;
            LengthRadiusSearch = lengthRadius;
            CountOfPharmacy = countpharmacy;
            CountOfResidents = countresidents;
            CountOfRetired = countretired;
        }
    }

    public class Optimum
    {
        // Список буферных зон, который нормализуется
        List<BufferZone> _listForNormalization = new List<BufferZone>();
        // Список буферных зон с карты
        List<BufferZone> _listWithStartZones = new List<BufferZone>();
        // Оптимальная точка
        BufferZone _BestPoint = new BufferZone();

        // Веса важности
        double weightPharma;
        double weightResid;
        double weightRetir;

        // Начальные значения максимума и минимума для каждого критерия
        double MaxPharma = 0;
        double MinPharma = 5000;
        double MaxResidents = 0;
        double MinResidents = 250000;
        double MaxRetired = 0;
        double MinRetired = 150000;

        // ID лучших точек по мнению каждой свертки
        int IdBestPointByLinearConvolution = -1;
        int IdBestPointByMultiplicativeConvolution = -1;
        int IdBestPointByMaxiMinConvolution = -1;

        /// <summary>
        /// Получение оптимальной точки
        /// </summary>
        /// <returns></returns>
        public int getOptimum(List<BufferZone> _arrayBuffers, List<BufferZone> _saveBuffers, double _wPharma, double _wResidents, double _wRetired)
        {
            // Инициалиазция данных
            _listForNormalization = _arrayBuffers;
            _listWithStartZones = _saveBuffers;
            weightPharma = _wPharma;
            weightResid = _wResidents;
            weightRetir = _wRetired;

            // Максимизация критерия аптек
            for (int i = 0; i < _listForNormalization.Count; i++)
                _listForNormalization[i].CountOfPharmacy = _listForNormalization[i].CountOfPharmacy * (-1);

            // Поиск максимума и минимума для каждого критерия
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                if (_listForNormalization[i].CountOfPharmacy >= MaxPharma)
                    MaxPharma = _listForNormalization[i].CountOfPharmacy;
                if (_listForNormalization[i].CountOfPharmacy <= MinPharma)
                    MinPharma = _listForNormalization[i].CountOfPharmacy;
            }
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                if (_listForNormalization[i].CountOfResidents >= MaxResidents)
                    MaxResidents = _listForNormalization[i].CountOfResidents;
                if (_listForNormalization[i].CountOfResidents <= MinResidents)
                    MinResidents = _listForNormalization[i].CountOfResidents;
            }
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                if (_listForNormalization[i].CountOfRetired >= MaxRetired)
                    MaxRetired = _listForNormalization[i].CountOfRetired;
                if (_listForNormalization[i].CountOfRetired <= MinRetired)
                    MinRetired = _listForNormalization[i].CountOfRetired;
            }

            // Разность между максимумом и минимумом для каждого критерия
            double DiffPharma = MaxPharma - MinPharma;
            double DiffRes = MaxResidents - MinResidents;
            double DiffRet = MaxRetired - MinRetired;

            // Нормализация всех критериев
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                // Для текущих нормализованных значений - округлить результат - до 7 знаков после запятой
                if (DiffPharma != 0)
                {
                    _listForNormalization[i].CountOfPharmacy = (_listForNormalization[i].CountOfPharmacy - MinPharma) / DiffPharma;
                    _listForNormalization[i].CountOfPharmacy = Math.Round(_listForNormalization[i].CountOfPharmacy, 7);
                }
                if (DiffRes != 0)
                {
                    _listForNormalization[i].CountOfResidents = (_listForNormalization[i].CountOfResidents - MinResidents) / DiffRes;
                    _listForNormalization[i].CountOfResidents = Math.Round(_listForNormalization[i].CountOfResidents, 7);
                }
                if (DiffRet != 0)
                {
                    _listForNormalization[i].CountOfRetired = (_listForNormalization[i].CountOfRetired - MinRetired) / DiffRet;
                    _listForNormalization[i].CountOfRetired = Math.Round(_listForNormalization[i].CountOfRetired, 7);
                }
            }

            // Максимум для линейной свертки
            double MaxLinearConvolution = -1;
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                double _temporaryVariableLinear = _listForNormalization[i].CountOfPharmacy * weightPharma +
                    _listForNormalization[i].CountOfResidents * weightResid + _listForNormalization[i].CountOfRetired * weightRetir;
                if (_temporaryVariableLinear >= MaxLinearConvolution)
                {
                    MaxLinearConvolution = _temporaryVariableLinear;
                    IdBestPointByLinearConvolution = _listForNormalization[i].IDBufferZone;
                }
            }

            double MaxMultiplicativeConvolution = -1;
            double _temporaryVariable = 1;
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                // Флаг входа в одну из веток
                bool flag = false;

                // Сбросили прошлое вычисление
                _temporaryVariable = 1;
                // Если вес аптеки и число аптек не равно 0
                if (weightPharma != 0 && _listForNormalization[i].CountOfPharmacy != 0)
                {
                    flag = true;
                    _temporaryVariable = _temporaryVariable * _listForNormalization[i].CountOfPharmacy * weightPharma;
                }
                // Если вес жителей и число жителей не равно 0
                if (weightResid != 0 && _listForNormalization[i].CountOfResidents != 0)
                {
                    flag = true;
                    _temporaryVariable = _temporaryVariable * _listForNormalization[i].CountOfResidents * weightResid;
                }
                // Если вес пенсионеров и число пенсионеров не равно 0
                if (weightRetir != 0 && _listForNormalization[i].CountOfRetired != 0)
                {
                    flag = true;
                    _temporaryVariable = _temporaryVariable * _listForNormalization[i].CountOfRetired * weightRetir;
                }
                // Если везде были нули, и мы так и не изменили число calculate
                if (_temporaryVariable == 1 && flag == false)
                    _temporaryVariable = 0;

                if (_temporaryVariable >= MaxMultiplicativeConvolution)
                {
                    MaxMultiplicativeConvolution = _temporaryVariable;
                    IdBestPointByMultiplicativeConvolution = _listForNormalization[i].IDBufferZone;
                }
            }

            // Максимум для максиминной свертки
            double MaxMaxiMinConvolution = -1;
            // Временная переменная - минимум среди критериев
            double _temporaryVariableMaxMin;
            for (int i = 0; i < _listForNormalization.Count; i++)
            {
                // Найти минимум среди трех критериев одной альтернативы
                _temporaryVariableMaxMin = FindMinFromThreeValues(_listForNormalization[i].CountOfPharmacy,
                    _listForNormalization[i].CountOfResidents, _listForNormalization[i].CountOfRetired);
                // И среди этих минимумов найти максимум
                if (_temporaryVariableMaxMin >= MaxMaxiMinConvolution)
                {
                    MaxMaxiMinConvolution = _temporaryVariableMaxMin;
                    IdBestPointByMaxiMinConvolution = _listForNormalization[i].IDBufferZone;
                }
            }

            // Самый важный критерий из трех
            double _TheMostImportantCriterion;
            // Список буферных зон, количество которых три - это самые лучшие точки по мнению каждой свертки
            List<BufferZone> _ThreeZones = new List<BufferZone>();
            // ID лучшей точки
            int IDBestPoint = -1;

            // Имея три оптимальных точки с точки зрения трех сверток, определяемся какая точка будет выдана пользователю
            // Если все свертки выдали один вердикт - то это оптимальная точка - 1=2, 1=3 -> 2=3 единое решение
            if (IdBestPointByLinearConvolution == IdBestPointByMultiplicativeConvolution
                && IdBestPointByLinearConvolution == IdBestPointByMaxiMinConvolution)
            {
                for (int i = 0; i < _listWithStartZones.Count; i++)
                    if (_listWithStartZones[i].IDBufferZone == IdBestPointByLinearConvolution)
                        _BestPoint = _listWithStartZones[i];
            }
            // Если не все три свертки согласны, но согласны две из трех - советуем эту
            else
            {
                // Если согласны первая и вторая сверткаы
                if (IdBestPointByLinearConvolution == IdBestPointByMultiplicativeConvolution)
                {
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                        if (_listWithStartZones[i].IDBufferZone == IdBestPointByLinearConvolution)
                            _BestPoint = _listWithStartZones[i];
                }
                // Если согласны первая и третья свертка
                else if (IdBestPointByLinearConvolution == IdBestPointByMaxiMinConvolution)
                {
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                        if (_listWithStartZones[i].IDBufferZone == IdBestPointByLinearConvolution)
                            _BestPoint = _listWithStartZones[i];
                }
                // Если согласны вторая и третья свертка
                else if (IdBestPointByMultiplicativeConvolution == IdBestPointByMaxiMinConvolution)
                {
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                        if (_listWithStartZones[i].IDBufferZone == IdBestPointByMultiplicativeConvolution)
                            _BestPoint = _listWithStartZones[i];
                }
                // если все три свертки нашли разные оптимальные точки - смотрим по важности критерия
                else
                {
                    // Создаем список самых лучших буферных зон
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                    {
                        // Сюда попадет три точки, ID которых из общего списка совпадают с ID лучших альтернатив по мнению трех сверток
                        if (_listWithStartZones[i].IDBufferZone == IdBestPointByLinearConvolution
                            || _listWithStartZones[i].IDBufferZone == IdBestPointByMultiplicativeConvolution
                            || _listWithStartZones[i].IDBufferZone == IdBestPointByMaxiMinConvolution)
                        {
                            // Список трех лучших точек по мнению трех сверток
                            _ThreeZones.Add(_listWithStartZones[i]);
                        }
                    }

                    // Какой для пользователя самый важный критерий
                    _TheMostImportantCriterion = FindMaxCriterion(weightPharma, weightResid, weightRetir);

                    // Если это критерий для аптек
                    if (_TheMostImportantCriterion == weightPharma)
                    {
                        // Минимум для аптек
                        double MinPharmaInZone = 5000;
                        // В списке лучших зон ищем, где меньше аптек
                        for (int i = 0; i < _ThreeZones.Count; i++)
                        {
                            // Ищем точку, охватившую минимум аптек
                            if (_ThreeZones[i].CountOfPharmacy <= MinPharmaInZone)
                            {
                                // Если изначально в точке 0 аптек 0 жителей и 0 пенсионеров - мы ее не учитываем
                                if (_ThreeZones[i].CountOfPharmacy == 0 && _ThreeZones[i].CountOfResidents == 0 && _ThreeZones[i].CountOfRetired == 0)
                                {

                                }
                                else
                                {
                                    MinPharmaInZone = _ThreeZones[i].CountOfPharmacy;
                                    // ID нашей лучшей точки в списке всех лучших зон
                                    IDBestPoint = _ThreeZones[i].IDBufferZone;
                                }
                            }
                        }
                    }

                    // Если это критерий для жителей
                    else if (_TheMostImportantCriterion == weightResid)
                    {
                        // Максимум для жителей
                        double MaxResidentsInZone = -1;
                        // В списке лучших зон ищем, где больше жителей
                        for (int i = 0; i < _ThreeZones.Count; i++)
                        {
                            // Ищем точку, охватившую максимум жителей
                            if (_ThreeZones[i].CountOfResidents >= MaxResidentsInZone)
                            {
                                // Если изначально в точке 0 аптек 0 жителей и 0 пенсионеров - мы ее не учитываем
                                if (_ThreeZones[i].CountOfPharmacy == 0 && _ThreeZones[i].CountOfResidents == 0 && _ThreeZones[i].CountOfRetired == 0)
                                {

                                }
                                else
                                {
                                    MaxResidentsInZone = _ThreeZones[i].CountOfResidents;
                                    // ID нашей лучшей точки в списке всех лучших зон
                                    IDBestPoint = _ThreeZones[i].IDBufferZone;
                                }
                            }
                        }
                    }

                    // Если это критерий для пенсионеров
                    else
                    {
                        // Максимум для пенсионеров
                        double MaxRetiredInZone = -1;
                        // В списке лучших зон ищем, где больше пенсионеров
                        for (int i = 0; i < _ThreeZones.Count; i++)
                        {
                            // Ищем точку, охватившую максимум пенсионеров
                            if (_ThreeZones[i].CountOfRetired >= MaxRetiredInZone)
                            {
                                // Если изначально в точке 0 аптек 0 жителей и 0 пенсионеров - мы ее не учитываем
                                if (_ThreeZones[i].CountOfPharmacy == 0 && _ThreeZones[i].CountOfResidents == 0 && _ThreeZones[i].CountOfRetired == 0)
                                {

                                }
                                else
                                {
                                    MaxRetiredInZone = _ThreeZones[i].CountOfRetired;
                                    // ID нашей лучшей точки в списке всех лучших зон
                                    IDBestPoint = _ThreeZones[i].IDBufferZone;
                                }
                            }
                        }
                    }
                    // По итогу присвоить оптимальной точке - одно из трех значений
                    for (int i = 0; i < _listWithStartZones.Count; i++)
                        if (_listWithStartZones[i].IDBufferZone == IDBestPoint)
                            _BestPoint = _listWithStartZones[i];
                }
            }

            // Вернуть лучшую точку
            return _BestPoint.IDBufferZone;
        }

        /// <summary>
        /// Найти минимум среди трёх чисел - минимум по трем критериям одной альтернативы
        /// </summary>
        /// <param name="x">нормализованные значение критерия "Аптеки"</param>
        /// <param name="y">нормализованные значение критерия "Жители"</param>
        /// <param name="z">нормализованные значение критерия "Пенсионеры"</param>
        /// <returns></returns>
        private double FindMinFromThreeValues(double normalPharma, double normalResidents, double normalRetired)
        {
            return Math.Min(normalPharma, Math.Min(normalResidents, normalRetired));
        }

        /// <summary>
        /// Найти максимум среди трех весов - максимум по трем весам, равны они быть не могут
        /// </summary>
        /// <param name="x">важность критерия "Аптеки"</param>
        /// <param name="y">важность критерия "Жители"</param>
        /// <param name="z">важность критерия "Пенсионеры"</param>
        /// <returns></returns>
        private double FindMaxCriterion(double weightPharma, double weightResidents, double weightRetired)
        {
            return Math.Max(weightPharma, Math.Max(weightResidents, weightRetired));
        }
    }
}