using Psychology.Data.Models;
using System;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IStatisticsRepository
    {
        IEnumerable<Statistics> List { get; }
        void Create(long StudentId, long TestId, DateTime Date);
        void Update(Statistics Statistics);
        void Delete(long Id);
        void Save();
    }
}
