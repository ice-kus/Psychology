using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> List { get; }
        void Create(string Name);
        void Update(Group Group);
        void Delete(long Id);
        bool Save();
    }
}
