using Microsoft.EntityFrameworkCore;
using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext DB;
        public QuestionRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Question> List => DB.Question;

        public void Create(string Text)
        {

            DB.Question.Add
            (
            new Question
            {
                Text = Text
            }
            );

        }
        public void Update(Question Question)
        {
            DB.Question.Update(Question);
        }
        public void Delete(long Id)
        {
            try
            {
                DB.Question.Remove(DB.Question.Find(Id));
            }
            catch
            {
                DB.ChangeTracker.Clear();
            }

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
