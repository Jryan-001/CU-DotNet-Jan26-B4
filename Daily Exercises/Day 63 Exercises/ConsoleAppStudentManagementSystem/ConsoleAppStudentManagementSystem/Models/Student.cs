using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStudentManagementSystem.Models
{
    internal class Student
    {
        public int StuId { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public override string ToString()
        {
            return $"Id: {StuId}, Name: {Name}, Grade: {Grade}";
        }
    }
}
