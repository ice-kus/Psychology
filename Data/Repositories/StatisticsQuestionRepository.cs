using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class StatisticsQuestionRepository : IStatisticsQuestionRepository
    {
        private readonly ApplicationDbContext DB;
        public StatisticsQuestionRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<StatisticsQuestion> List => DB.StatisticsQuestion;
        public void Create(long StatisticsId, int NumQuestion, int NumAnswer)
        {
            DB.StatisticsQuestion.Add
                (
                new StatisticsQuestion
                {
                    StatisticsId = StatisticsId,
                    NumQuestion = NumQuestion,
                    NumAnswer = NumAnswer
                }
                );
        }
        public void Delete(long Id)
        {
            DB.StatisticsQuestion.Remove(DB.StatisticsQuestion.Find(Id));
        }
        public void Save()
        {
            DB.SaveChanges();
        }
    }
}
