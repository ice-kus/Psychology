using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class PassageDataQuestionRepository : IPassageDataQuestionRepository
    {
        private readonly ApplicationDbContext DB;
        public PassageDataQuestionRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<PassageDataQuestion> List => DB.PassageDataQuestion;
        public void Create(long PassageDataId, int NumQuestion, int NumAnswer)
        {
            DB.PassageDataQuestion.Add
                (
                new PassageDataQuestion
                {
                    PassageDataId = PassageDataId,
                    NumQuestion = NumQuestion,
                    NumAnswer = NumAnswer
                }
                );
        }
        public void Delete(long Id)
        {
            DB.PassageDataQuestion.Remove(DB.PassageDataQuestion.Find(Id));
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
