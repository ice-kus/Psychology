namespace Psychology.Data.Models
{
    public class Lecturer
    {
        public long Id { get; set; }               // integer (PRIMARY KEY)
        public string Name { get; set; }           // character varying(150)
        public string Login { get; set; }           // character varying(20)
        public string Password { get; set; }       // character varying(25)
    }
}
