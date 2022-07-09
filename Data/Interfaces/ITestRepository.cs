using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> List { get; }
        void Create(string Name, string Description, int Type, int Size, int Scale, string Instruction, string Processing, bool Availability, bool Mix, long LecturerId);
        void Update(Test Test);
        void Delete(long Id);
        bool Save();
    }
}
