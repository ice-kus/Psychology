using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Psychology.Data.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext DB;
        public TestRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Test> List => DB.Test;
        public void Create(string Name, string Description, int Type, int Size, int Scale, string Instruction, string Processing, bool Availability, bool Mix, long LecturerId)
        {
            DB.Test.Add
                (
                new Test
                {
                    Name = Name,
                    Description = Description,
                    Type = Type,
                    Size = Size,
                    Scale = Scale,
                    Instruction = Instruction,
                    Processing = Processing,
                    Availability = Availability,
                    Mix = Mix,
                    LecturerId = LecturerId
                }
                );
        }
        public void Update(Test Test)
        {
            DB.Test.Update(Test);
        }
        public void Delete(long Id)
        {
            DB.Test.Remove(DB.Test.Find(Id));
        }
        public void Save()
        {
            DB.SaveChanges();
        }
    }
}
