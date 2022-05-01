using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychology.Data.Models
{
    public class Group
    {
        public long Id { get; set; }        // integer (PRIMARY KEY)
        public string Name { get; set; }    // character varying(15)
    }
}
