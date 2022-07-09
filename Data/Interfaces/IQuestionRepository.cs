using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> List { get; }
        void Create(string Text);
        void Update(Question Answer);
        void Delete(long Id);
        bool Save();
    }
}
