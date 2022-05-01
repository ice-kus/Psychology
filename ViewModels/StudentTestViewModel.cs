using Psychology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychology.ViewModels
{
    public class StudentTestViewModel
    {
        public IEnumerable<Test> ListTest { get; set; }
        public Test Test { get; set; }
        public bool SortDate { get; set; }
        public bool SortDesc { get; set; }
    }
}
