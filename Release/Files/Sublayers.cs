using System.Collections.Generic;
using GMap.NET.WindowsForms;

namespace OptimumPharmacy
{
    public class SublayerLocation
    {
        public string nameOfOverlay;
        public List<Location> listWithLocation;
        public string iconOfOverlay;
        public GMapOverlay overlay;

        public SublayerLocation() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Название слоя</param>
        /// <param name="Icon">Значок слоя</param>
        public SublayerLocation(string Name, string Icon)
        {
            nameOfOverlay = Name;
            iconOfOverlay = Icon;
        }
    }

    public class SublayerQuartet
    {
        public string nameOfOverlay;
        public List<Quartet> listWithQuartets;
        public string iconOfOverlay;
        public GMapOverlay overlay;

        public SublayerQuartet() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Название слоя</param>
        /// <param name="Icon">Значок слоя</param>
        public SublayerQuartet(string Name, string Icon)
        {
            nameOfOverlay = Name;
            iconOfOverlay = Icon;
        }
    }

    public class SublayerDistrict
    {
        public string nameOfOverlay;
        public List<District> listWithDistricts;
        public string iconOfOverlay;
        public GMapOverlay overlay;

        public SublayerDistrict() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Название слоя</param>
        /// <param name="Icon">Значок слоя</param>
        public SublayerDistrict(string Name, string Icon)
        {
            nameOfOverlay = Name;
            iconOfOverlay = Icon;
        }
    }

    public class SublayerPharmacy
    {
        public string nameOfOverlay;
        public List<Pharmacy> listWithPharmacy;
        public string iconOfOverlay;
        public GMapOverlay overlay;

        public SublayerPharmacy() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Название слоя</param>
        /// <param name="Icon">Значок слоя</param>
        public SublayerPharmacy(string Name, string Icon)
        {
            nameOfOverlay = Name;
            iconOfOverlay = Icon;
        }
    }
}