using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IPassageDataQuestionRepository
    {
        IEnumerable<PassageDataQuestion> List { get; }
        void Create(long PassageDataId, int NumQuestion, int NumAnswer);
        void Delete(long Id);
        bool Save();
    }
}
