using ConsoleAppStudentManagementSystem.Models;
using ConsoleAppStudentManagementSystem.Data_Access;
using ConsoleAppStudentManagementSystem.Bussiness_Logic;
namespace ConsoleAppStudentManagementSystem.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("JSON or List (1/2)");
            var repoOption = int.Parse(Console.ReadLine());

            //var student = GetStudent();
            IStudentRepository repo = null;

            if (repoOption == 1)
            {
                repo = new JSONStudentRepository();
            }
            else if (repoOption == 2)
            {
                repo = new ListStudentRepository();
            }
            IStudentServices studentServices = new StudentService(repo);
            while (true)
            {
                Console.WriteLine("\nMenu: 1.Add  2.View  3.Update 4.Delete 5.Exit");
                var choice = int.Parse(Console.ReadLine());
                if (choice == 5) break;
                try
                {
                    if (choice == 1)
                    {

                        var student = GetStudent();

                        studentServices.AddStudent(student);
                        Console.WriteLine("Added!");
                    }
                    else if (choice == 2)
                    {
                        IEnumerable<Student> students = studentServices.GetStudent();

                        DisplayStudents(students);
                    }
                    else if (choice == 3)
                    {
                        var student = GetStudent();
                        studentServices.UpdateStudent(student);
                        Console.WriteLine("Updated!");

                    }
                    else if (choice == 4)
                    {
                        Console.Write("Enter ID to delete: ");
                        int id = int.Parse(Console.ReadLine());
                        studentServices.DeleteStudent(id);
                        Console.WriteLine("Deleted!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static Student GetStudent()
        {
            //Student student = new Student()
            //{
            //    StuId = 101,
            //    Name = "Chair",
            //    Grade = 95
            //};

            //return student;
            Console.Write("Enter ID: ");

            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");

            string name = Console.ReadLine();

            Console.Write("Enter Grade: ");

            int grade = int.Parse(Console.ReadLine());

            return new Student { StuId = id, Name = name, Grade = grade };
        }
        static void DisplayStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.StuId}, Name: {student.Name}, Grade: {student.Grade}");
            }
        }
    }
}
