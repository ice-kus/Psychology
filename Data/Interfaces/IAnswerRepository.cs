using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> List { get; }
        void Create(string Text);
        void Update(Answer Answer);
        void Delete(long Id);
        bool Save();
    }
}
