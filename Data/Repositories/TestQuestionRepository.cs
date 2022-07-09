using Microsoft.EntityFrameworkCore;
using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System.Collections.Generic;


namespace Psychology.Data.Repositories
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private readonly ApplicationDbContext DB;
        public TestQuestionRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<TestQuestion> List => DB.TestQuestion.Include(i => i.Question).Include(i => i.Answer);

        public void Create(long TestId, long QuestionId, long AnswerId, int NumQuestion, int NumAnswer)
        {
            DB.TestQuestion.Add
                (
                new TestQuestion
                {
                    TestId = TestId,
                    QuestionId = QuestionId,
                    AnswerId = AnswerId,
                    NumQuestion = NumQuestion,
                    NumAnswer = NumAnswer
                }
                );
        }
        public void Delete(long Id)
        {
            DB.TestQuestion.Remove(DB.TestQuestion.Find(Id));
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
