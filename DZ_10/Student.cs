namespace DZ_10
{
    internal class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public int LastParticipations { get; set; }
        public Student(string name, string group) 
        { 
            Name = name;
            Group = group;
        }
        public override string ToString()
        {
            return $"{Name}({Group})";
        }
    }
}
