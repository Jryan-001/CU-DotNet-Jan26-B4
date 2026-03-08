namespace StudentDictionary
{
    class Student
    {
        public int StudId { get; set; }

        public string SName { get; set; }

        //public int Marks { get; set; }
        public Student(int id, string name)
        {
            StudId = id;
            SName = name;
        }
        public override bool Equals(object obj)
        {
            Student other = obj as Student;

            if (other == null)
                return false;

            return this.StudId == other.StudId && this.SName == other.SName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StudId, SName);
        }

    }
    class StudentManager
    {
        public static Dictionary<Student, int> records = new Dictionary<Student, int>();
        public static void Manager(Student s, int marks)
        {
            if (!records.ContainsKey(s))
                records.Add(s, marks);
            else if (marks > records[s])
                records[s] = marks;

        }
        public static void Display()
        {
            foreach(var rec in records)
            {
                Console.WriteLine($"{rec.Key.StudId} {rec.Key.SName} - {rec.Value}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Student stu1 = new Student(101, "Rahul");
            StudentManager.Manager(stu1, 98);

            StudentManager.Manager(new Student
            (
                102,
                "Raj"
            ), 77);

            Student s3 = new Student(103, "Ram");
            Student s4 = new Student(103, "Ram");
            StudentManager.Manager(s3, 88);
            StudentManager.Display();

            Console.WriteLine();
            StudentManager.Manager(s4, 68);
            Console.WriteLine();
            StudentManager.Display();
            Console.WriteLine();
            StudentManager.Manager(s4, 98);
            StudentManager.Display();
        }
    }
}
