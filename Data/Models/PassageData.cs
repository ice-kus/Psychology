using System;
using System.Collections.Generic;

namespace Psychology.Data.Models
{
    public class PassageData
    {
        public long Id { get; set; }         // integer (PRIMARY KEY)
        public long StudentId { set; get; }  // integer (FOREING KEY)
        public long TestId { set; get; }     // integer (FOREING KEY)
        public DateTime Date { set; get; }   // date timestamp without time zone
        public bool Full { get; set; }       // boolean
        public virtual Test Test { set; get; }
	    public virtual Student Student { set; get; }
        public virtual IEnumerable<Result> ListResult { set; get; }
        public virtual IEnumerable<PassageDataQuestion> ListPassageDataQuestion { set; get; }
    }
}
