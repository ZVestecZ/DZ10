using System;
using System.Collections.Generic;
using System.IO;

namespace DZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("Задание 1");

            string eventsFilePath = "events.txt";

            List<Student> students = LoadStudentsFromFile();

            Console.WriteLine("Cтуденты:");
            foreach (Student student in students)
            {
                Console.WriteLine($"- {student}");
            }
            Console.WriteLine();

            Console.WriteLine("Введите название мероприятия:");
            string eventName = Console.ReadLine();
            Console.WriteLine("Введите дату мероприятия (ДД.ММ.ГГГГ):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime eventDate))
            {
                Console.WriteLine("Некорректный формат");
                return;
            }
            Console.WriteLine("Введите количество участников от каждой группы:");
            if (!int.TryParse(Console.ReadLine(), out int eventParticipants))
            {
                Console.WriteLine("Некорректный формат");
                return;
            }

            Event currentEvent = new Event(eventName, eventDate, eventParticipants);

            List<Student> selectedStudents = SelectParticipants(students, currentEvent);

            SaveEventToFile(eventsFilePath, currentEvent);
            SaveParticipantsToFile(eventsFilePath, selectedStudents);
            Console.ReadKey();



            //Задание 2
            Console.WriteLine("Задание 2");

            List<Person> people = new List<Person>
        {
            new Person("Alice", new List<string> { "a", "b", "c" }),
            new Person("Bob", new List<string> { "d", "e", "f" }),
            new Person("Charlie", new List<string> { "g", "a", "h" })
        };

            // Список возможных событий (для выбора пользователем)
            List<string> availableEvents = new List<string>
        {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h"
        };


            Console.WriteLine("Доступные события:");
            for (int i = 0; i < availableEvents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableEvents[i]}");
            }

            // Запрашиваем у пользователя событие
            int selectedIndex;
            do
            {
                Console.WriteLine("Введите номер события, которое вас интересует:");
            } while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 1 || selectedIndex > availableEvents.Count);

            string selectedEvent = availableEvents[selectedIndex - 1];

            Console.WriteLine();
            // Проверяем реакцию людей на событие
            Console.WriteLine($"Событие: {selectedEvent}");

            foreach (Person person in people)
            {
                person.ReactToEvent(selectedEvent);
            }
            Console.ReadKey();
        }
        private static List<Student> LoadStudentsFromFile()
        {
            List<Student> students = new List<Student>();
            string[] lines = File.ReadAllLines("..\\..\\students.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string name = parts[0].Trim();
                string group = parts[1].Trim();
                students.Add(new Student(name, group));
            }
            return students;
        }
        private static void SaveEventToFile(string filePath, Event currentEvent)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Дата: {DateTime.Now.ToShortDateString()}");
                writer.WriteLine($"Ивент: {currentEvent};");
            }
        }
        private static void SaveParticipantsToFile(string filePath, List<Student> selectedStudents)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Список выбранных студентов:");
                foreach (Student student in selectedStudents)
                {
                    writer.WriteLine($" - {student}");
                }
            }
        }
        private static List<Student> SelectParticipants(List<Student> students, Event currentEvent)
        {
            Dictionary<string, List<Student>> groupedStudents = new Dictionary<string, List<Student>>();
            foreach (Student student in students)
            {
                if (!groupedStudents.ContainsKey(student.Group))
                {
                    groupedStudents[student.Group] = new List<Student>();
                }
                groupedStudents[student.Group].Add(student);
            }

            List<Student> selectedStudents = new List<Student>();
            if (groupedStudents.Count < 2)
            {
                Console.WriteLine("Недостаточно человек");
                return selectedStudents;
            }

            foreach (KeyValuePair<string, List<Student>> group in groupedStudents)
            {
                List<Student> groupStudents = group.Value;

                groupStudents.Sort(delegate (Student s1, Student s2)
                {
                    return s1.LastParticipations.CompareTo(s2.LastParticipations);
                });

                int takeCount = Math.Min(currentEvent.ParticipantsPerGroup, groupStudents.Count);
                for (int i = 0; i < takeCount; i++)
                {
                    selectedStudents.Add(groupStudents[i]);
                    groupStudents[i].LastParticipations += 1;
                }
            }

            return selectedStudents;
        }
    }
}
