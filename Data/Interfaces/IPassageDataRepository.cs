using Psychology.Data.Models;
using System;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IPassageDataRepository
    {
        IEnumerable<PassageData> List { get; }
        void Create(long StudentId, long TestId, DateTime Date, bool Full);
        void Update(PassageData Statistics);
        void Delete(long Id);
        void Save();
    }
}
