using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface ITestQuestionRepository
    {
        IEnumerable<TestQuestion> List { get; }
        void Create(long TestId, long QuestionId, long AnswerId, int NumQuestion, int NumAnswer);
        void Delete(long Id);
        void Save();
    }
}
