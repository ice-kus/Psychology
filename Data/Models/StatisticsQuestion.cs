namespace Psychology.Data.Models
{
    public class StatisticsQuestion
    {
        public long Id { get; set; }             // integer (PRIMARY KEY)
        public long StatisticsId { set; get; }   // integer (FOREIGN KEY)
        public int NumQuestion { set; get; }    // integer
        public int NumAnswer { set; get; }      // integer
    }
}
