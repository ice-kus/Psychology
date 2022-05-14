namespace Psychology.Data.Models
{
    public class PassageDataQuestion
    {
        public long Id { get; set; }             // integer (PRIMARY KEY)
        public long PassageDataId { set; get; }   // integer (FOREIGN KEY)
        public int NumQuestion { set; get; }    // integer
        public int NumAnswer { set; get; }      // integer
    }
}
