namespace Psychology.Data.Models
{
    public class Student
    {
        public long Id { get; set; }               // integer (PRIMARY KEY)
        public string Name { get; set; }           // character varying(150)
        public string Password { get; set; }       // character varying(25)
        public long GroupId { get; set; }          // integer (FOREING KEY)
    }
}
