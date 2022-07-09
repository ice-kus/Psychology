using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> List { get; }
        void Create(long Id, string Name, string Password, long GroupId);
        void Update(Student Student);
        void Delete(long Id);
        bool Save();
    }
}
