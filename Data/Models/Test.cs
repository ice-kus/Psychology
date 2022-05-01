namespace Psychology.Data.Models
{
    public class Test
    {
        public long Id { get; set; }               // integer (PRIMARY KEY)
        public string Name { get; set; }           // character varying(150)
        public string Description { get; set; }    // character varying(400)
        public int Type { get; set; }              // integer
        public int Size { get; set; }              // integer
        public int Scale { get; set; }             // integer
        public string Instruction { get; set; }    // character varying(50)
        public string Processing { get; set; }     // text
        public bool Availability { get; set; }     // boolean
        public bool Mix { get; set; }              // boolean
    }
}
