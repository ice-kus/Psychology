using Microsoft.EntityFrameworkCore;
using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class PassageDataRepository : IPassageDataRepository
    {
        private readonly ApplicationDbContext DB;
        public PassageDataRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<PassageData> List => DB.PassageData.Include(i => i.Test).Include(i => i.ListResult).Include(i => i.Student).Include(i => i.ListPassageDataQuestion);
        public void Create(long StudentId, long TestId, DateTime Date, bool Full)
        {
            DB.PassageData.Add
                (
                new PassageData
                {
                    StudentId = StudentId,
                    TestId = TestId,
                    Date = Date,
                    Full = Full
                }
                );
        }
        public void Update(PassageData Statistics)
        {
            DB.PassageData.Update(Statistics);
        }
        public void Delete(long Id)
        {
            DB.PassageData.Remove(DB.PassageData.Find(Id));
        }
        public bool Save()
        {
            try
            {
                DB.SaveChanges();
            }
            catch
            {
                DB.ChangeTracker.Clear();
                return false;
            }
            return true;
        }
    }
}
