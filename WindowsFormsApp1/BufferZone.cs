namespace OptimumPharmacy
{
    public class BufferZone
    {
        public int idBufferZone { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int lengthRadiusSearch { get; set; }
        public double countOfPharmacy { get; set; }
        public double countOfResidents { get; set; }
        public double countOfRetired { get; set; }

        public BufferZone() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Id">ID буферной зоны</param>
        /// <param name="X">Координата X буферной зоны</param>
        /// <param name="Y">Координата Y буферной зоны</param>
        /// <param name="LengthRadius">Радиус буферной зоны</param>
        /// <param name="Countpharmacy">Количество аптек, попавших в буферную зону</param>
        /// <param name="Countresidents">Количество жителей, попавших в буферную зону</param>
        /// <param name="Countretired">Количество пенсионеров, попавших в буферную зону</param>
        public BufferZone(int Id, double X, double Y, int LengthRadius, double Countpharmacy, double Countresidents, double Countretired)
        {
            idBufferZone = Id;
            x = X;
            y = Y;
            lengthRadiusSearch = LengthRadius;
            countOfPharmacy = Countpharmacy;
            countOfResidents = Countresidents;
            countOfRetired = Countretired;
        }
    }
}