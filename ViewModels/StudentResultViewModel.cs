using Psychology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychology.ViewModels
{
    public class StudentResultViewModel
    {
        public IEnumerable<Statistics> ListStatistics { get; set; }
        public bool SortDate { get; set; }
        public bool SortDesc { get; set; }
        public Statistics Statistics { get; set; }
    }
}
