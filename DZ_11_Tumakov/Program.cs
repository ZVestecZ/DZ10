using BuildingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_11_Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задания 11.1 11.2
            Console.WriteLine("Задания 11.1 11.2");
            Building building1 = Creator.CreateBuilding(1, 50, 5, 100);
            Building building2 = Creator.CreateBuilding(2, 75, 10);
            Building building3 = Creator.CreateBuilding(3, 30, 3, 40);


            Console.WriteLine("Все созданные здания:");
            foreach (Building building in Creator.GetAllBuildings())
            {
                Console.WriteLine(building);
            }
            Console.WriteLine();
            
            Building retrievedBuilding = Creator.GetBuilding(2);
            if (retrievedBuilding != null)
                Console.WriteLine($"Получено здание: {retrievedBuilding}");
            else
                Console.WriteLine($"Здание не найдено");
            Console.WriteLine();
            
            bool isDeleted = Creator.DeleteBuilding(2);
            if (isDeleted)
                Console.WriteLine("Здание 2 удалено");
            else
                Console.WriteLine("Здание 2 не найдено");

            foreach (Building building in Creator.GetAllBuildings())
            {
                Console.WriteLine(building);
            }
            Console.ReadKey();
        }
    }
}
