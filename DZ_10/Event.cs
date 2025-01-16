using System;

namespace DZ_10
{
    internal class Event
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantsPerGroup { get; set; }

        public Event(string name, DateTime date, int participantsPerGroup)
        {
            Name = name;
            Date = date;
            ParticipantsPerGroup = participantsPerGroup;
        }

        public override string ToString()
        {
            return $"{Name} в {Date.ToShortDateString()}";
        }
    }
}
