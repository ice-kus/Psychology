using Microsoft.EntityFrameworkCore;
using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly ApplicationDbContext DB;
        public StatisticsRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Statistics> List => DB.Statistics.Include(i => i.Test).Include(i => i.ListResult).Include(i => i.Student).Include(i => i.ListStatisticsQuestion);
        public void Create(long StudentId, long TestId, DateTime Date)
        {
            DB.Statistics.Add
                (
                new Statistics
                {
                    StudentId = StudentId,
                    TestId = TestId,
                    Date = Date
                }
                );
        }
        public void Update(Statistics Statistics)
        {
            DB.Statistics.Update(Statistics);
        }
        public void Delete(long Id)
        {
            DB.Statistics.Remove(DB.Statistics.Find(Id));
        }
        public void Save()
        {
            DB.SaveChanges();
        }
    }
}
