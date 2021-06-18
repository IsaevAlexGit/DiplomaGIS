using System.Collections.Generic;

namespace OptimumPharmacy
{
    public class Quartet
    {
        public int idQuartet { get; set; }
		public int countBoundaryPoints { get; set; }
        public List<Location> listBoundaryPoints { get; set; }
        public double xCentreOfQuartet { get; set; }
        public double yCentreOfQuartet { get; set; }     
        public int countOfPharmacy { get; set; }
        public int countOfResidents { get; set; }
        public int countOfRetired { get; set; }

        public Quartet() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Id">ID квартала</param>
        /// <param name="Count">Количество граничных точек квартала</param>
        /// <param name="List">Список граничных точек квартала</param>
        /// <param name="X">Координата X центральной точки квартала</param>
        /// <param name="Y">Координата Y центральной точки квартала</param>
        /// <param name="Countpharmacy">Количество аптек, находящихся в квартале</param>
        /// <param name="Countresidents">Количество жителей, проживающих в квартале</param>
        /// <param name="Countretired">Количество пенсионеров, проживающих в квартале</param>
        public Quartet(int Id, int Count , List<Location> List, double X, double Y, int Countpharmacy, int Countresidents, int Countretired)
        {
            idQuartet = Id;
            countBoundaryPoints = Count;
            listBoundaryPoints = List;
            xCentreOfQuartet = X;
            yCentreOfQuartet = Y;
            countOfPharmacy = Countpharmacy;
            countOfResidents = Countresidents;
            countOfRetired = Countretired;
        }
    }
}