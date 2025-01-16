using System;
using System.Collections.Generic;

namespace DZ_10
{
    internal class Person
    {
        public string Name { get; set; }
        public List<string> Hobbies { get; set; }

        public Person(string name, List<string> hobbies)
        {
            Name = name;
            Hobbies = hobbies;
        }

        public void ReactToEvent(string eventName)
        {
            if (Hobbies.Contains(eventName))
            {
                Console.WriteLine($"{Name}: Это же {eventName}! СЮДА ЛУТ!!! ");
            }
        }
    }
}
