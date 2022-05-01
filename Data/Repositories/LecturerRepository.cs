using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private readonly ApplicationDbContext DB;
        public LecturerRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Lecturer> List => DB.Lecturer;
    }
}
