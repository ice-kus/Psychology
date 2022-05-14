namespace Psychology.Data.Models
{
    public class Result
    {
        public long Id { get; set; }            // integer (PRIMARY KEY)
        public long PassageDataId { set; get; }  // integer (FOREING KEY)
        public long CriteriaId { set; get; }    // integer (FOREING KEY)
        public int Points { set; get; }         // integer
        public virtual Criteria Criteria { set; get; }
    }
}
