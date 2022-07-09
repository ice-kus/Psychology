using Microsoft.EntityFrameworkCore;
using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly ApplicationDbContext DB;
        public ResultRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Result> List => DB.Result.Include(i => i.Criteria);
        public void Create(long PassageDataId, long CriteriaId, int Points)
        {
            DB.Result.Add
                (
                new Result
                {
                    PassageDataId = PassageDataId,
                    CriteriaId = CriteriaId,
                    Points = Points
                }
                );
        }
        public void Update(Result Result)
        {
            DB.Result.Update(Result);
        }

        public void Delete(long Id)
        {
            DB.Result.Remove(DB.Result.Find(Id));
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
