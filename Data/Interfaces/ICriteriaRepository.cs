using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface ICriteriaRepository
    {
        IEnumerable<Criteria> List { get; }
        void Create(string Name, long TestId, List<int> ListNumQuestion, List<int> ListNumAnswer);
        void Update(Criteria Criteria);
        void Delete(long Id);
        bool Save();
    }
}
