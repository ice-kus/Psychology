using Psychology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychology.ViewModels
{
    public class LecturerResultViewModel
    {
        public Statistics Statistics { get; set; }
        public IEnumerable<TestQuestion> ListTestQuestion { get; set; }
    }
}
