using ConsoleAppStudentManagementSystem.Models;
using ConsoleAppStudentManagementSystem.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStudentManagementSystem.Bussiness_Logic
{
    internal class StudentService : IStudentServices
    {
        private IStudentRepository _repository {  get; set; }
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }


        public void AddStudent(Student student)
        {
            if (student.Grade < 0 || student.Grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100");
            _repository.AddStudent(student);
        }
        public IEnumerable<Student> GetStudent()
        {
            return _repository.GetStudent();
        }

        public void UpdateStudent(Student student)
        {
            _repository.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }
    }
}
