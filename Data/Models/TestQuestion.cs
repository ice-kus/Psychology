namespace Psychology.Data.Models
{
    public class TestQuestion
    {
        public long Id { get; set; }         // integer (PRIMARY KEY)
        public long TestId { get; set; }     // integer (FOREING KEY)
        public long QuestionId { get; set; } // integer (FOREING KEY)
        public long AnswerId { get; set; }   // integer (FOREING KEY)
        public int NumQuestion { get; set; } // integer
        public int NumAnswer { get; set; }   // integer

        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
