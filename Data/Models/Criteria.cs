using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychology.Data.Models
{
    public class Criteria
    {
        public long Id { get; set; }      // integer (PRIMARY KEY)
        public string Name { get; set; }  // character varying (100)
        public long TestId { set; get; }  // integer (FOREING KEY)
        public List<int> ListNumQuestion { set; get; }  // integer[]
        public List<int> ListNumAnswer { set; get; }    // integer[]
    }
}
