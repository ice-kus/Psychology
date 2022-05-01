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
    }
}
