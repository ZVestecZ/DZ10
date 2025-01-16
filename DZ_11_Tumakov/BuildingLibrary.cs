namespace BuildingLibrary
{
    public class Building
    {
        public int BuildingNumber { get; }
        public int Height { get; }
        public int NumberOfFloors { get; }
        public int NumberOfApartments { get; }

        internal Building(int buildingNumber, int height, int numberOfFloors, int numberOfApartments)
        {
            BuildingNumber = buildingNumber;
            Height = height;
            NumberOfFloors = numberOfFloors;
            NumberOfApartments = numberOfApartments;
        }

        public override string ToString()
        {
            return $"Здание {BuildingNumber}: Высота {Height}, Этажей {NumberOfFloors}, Квартир {NumberOfApartments}";
        }
    }
}
