using ConsoleAppStudentManagementSystem.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStudentManagementSystem.Data_Access
{
    internal class JSONStudentRepository : IStudentRepository
    {
        private readonly string _filePath = @"..//..//..//Sstudents.json";
        public void AddStudent(Student student)
        {
            var students = GetStudent().ToList();
            students.Add(student);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(students));
        }

        

        public IEnumerable<Student> GetStudent()
        {
            if (!File.Exists(_filePath)) return new List<Student>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        //public void UpdateStudent(Student student)
        //{
        //    throw new NotImplementedException();
        //}
        //public void DeleteStudent(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void UpdateStudent(Student student)
        {
            var students = GetStudent().ToList();
            var existing = students.FirstOrDefault(s => s.StuId == student.StuId);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
                File.WriteAllText(_filePath, JsonSerializer.Serialize(students));
            }
        }
        public void DeleteStudent(int id)
        {
            var students = GetStudent().ToList();
            students.RemoveAll(s => s.StuId == id);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(students));
        }
    }
}
