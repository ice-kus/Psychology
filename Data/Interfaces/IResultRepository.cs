using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IResultRepository
    {
        IEnumerable<Result> List { get; }
        void Create(long StatisticsId, long CriteriaId, int Points);
        void Update(Result Result);
        void Delete(long Id);
        void Save();
    }
}
