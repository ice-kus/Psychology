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

        public void Create(long Id, string Name, string Password, long GroupId)
        {
            DB.Student.Add
              (
              new Student
              {
                  Id = Id,
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

        public bool Save()
        {
            try
            {
                DB.SaveChanges();
            }
            catch
            {
                DB.ChangeTracker.Clear();
                return false;
            }
            return true;
        }

        public void Update(Student Student)
        {
            DB.Student.Update(Student);
        }
    }
}
