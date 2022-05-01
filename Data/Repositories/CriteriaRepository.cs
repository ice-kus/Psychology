using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class CriteriaRepository : ICriteriaRepository
    {
        private readonly ApplicationDbContext DB;
        public CriteriaRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Criteria> List => DB.Criteria;

        public void Create(string Name, long TestId, List<int> ListNumQuestion, List<int> ListNumAnswer)
        {
            DB.Criteria.Add
                (
                new Criteria
                {
                    Name = Name,
                    TestId = TestId,
                    ListNumQuestion = ListNumQuestion,
                    ListNumAnswer = ListNumAnswer
                }
                );
        }
        public void Update(Criteria Criteria)
        {
            DB.Criteria.Update(Criteria);
        }
        public void Delete(long Id)
        {
            DB.Criteria.Remove(DB.Criteria.Find(Id));
        }
        public void Save()
        {
            DB.SaveChanges();
        }
    }
}
