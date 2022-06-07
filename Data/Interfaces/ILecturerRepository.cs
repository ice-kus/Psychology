using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface ILecturerRepository
    {
        IEnumerable<Lecturer> List { get; }
        void Create(string Name, string Login, string Password);
        void Update(Lecturer Lecturer);
        void Delete(long Id);
        void Save();
    }
}
