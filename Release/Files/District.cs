using System.Collections.Generic;

namespace OptimumPharmacy
{
    public class District
    {
        public int idDistrict { get; set; }
        public string nameOfDistrict { get; set; }
        public double xCentreOfDistrict { get; set; }
        public double yCentreOfDistrict { get; set; }
        public int countBoundaryPoints { get; set; }
        public List<Location> listBoundaryPoints { get; set; }

        public District() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Id">ID района</param>
        /// <param name="Name">Название района</param>
        /// <param name="X">Координата X центральной точки района</param>
        /// <param name="Y">Координата Y центральной точки района</param>
        /// <param name="Count">Количество граничных точек района</param>
        /// <param name="List">Список граничных точек района</param>
        public District(int Id, string Name, double X, double Y, int Count, List<Location> List)
        {
            idDistrict = Id;
            nameOfDistrict = Name;
            xCentreOfDistrict = X;
            yCentreOfDistrict = Y;
            countBoundaryPoints = Count;
            listBoundaryPoints = List;
        }
    }
}