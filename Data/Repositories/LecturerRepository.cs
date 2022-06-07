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

        public void Create(string Name, string Login, string Password)
        {
            DB.Lecturer.Add
               (
               new Lecturer
               {
                   Name = Name,
                   Password = Password,
                   Login = Login
               }
               );
        }

        public void Delete(long Id)
        {
            DB.Lecturer.Remove(DB.Lecturer.Find(Id));
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public void Update(Lecturer Lecturer)
        {
            DB.Lecturer.Update(Lecturer);
        }
    }
}
