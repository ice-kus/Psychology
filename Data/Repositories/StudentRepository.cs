using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext DB;
        public StudentRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Student> List => DB.Student;

        public void Create(string Name, string Password, long GroupId)
        {
            DB.Student.Add
              (
              new Student
              {
                  Name = Name,
                  Password = Password,
                  GroupId = GroupId
              }
              );
        }

        public void Delete(long Id)
        {
            DB.Student.Remove(DB.Student.Find(Id));
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public void Update(Student Student)
        {
            DB.Student.Update(Student);
        }
    }
}
