using System.Collections.Generic;
using System.Linq;

namespace BuildingLibrary
{
    public class Creator
    {
        private static Dictionary<int, Building> _buildings = new Dictionary<int, Building>();
        private Creator() { }

        public static Building CreateBuilding(int buildingNumber, int height, int numberOfFloors, int numberOfApartments)
        {
            Building newBuilding = new Building(buildingNumber, height, numberOfFloors, numberOfApartments);
            _buildings.Add(buildingNumber, newBuilding);
            return newBuilding;
        }

        public static Building CreateBuilding(int buildingNumber, int height, int numberOfFloors)
        {
            return CreateBuilding(buildingNumber, height, numberOfFloors, 0);
        }

        public static Building GetBuilding(int buildingNumber)
        {
            _buildings.TryGetValue(buildingNumber, out Building building);
            return building;
        }

        public static bool DeleteBuilding(int buildingNumber)
        {
            return _buildings.Remove(buildingNumber);
        }

        public static IEnumerable<Building> GetAllBuildings()
        {
            return _buildings.Values.ToList();
        }

    }
}
