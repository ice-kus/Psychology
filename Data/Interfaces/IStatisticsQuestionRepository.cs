using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IStatisticsQuestionRepository
    {
        IEnumerable<StatisticsQuestion> List { get; }
        void Create(long StatisticsId, int NumQuestion, int NumAnswer);
        void Delete(long Id);
        void Save();
    }
}
