using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.ViewModels
{
    public class LecturerTestViewModel
    {
        public IEnumerable<Test> ListTest { get; set; }
        public Test Test { get; set; }
        public bool SortDate { get; set; }
        public bool SortDesc { get; set; }
        public bool Delete { get; set; }
        public string Message { get; set; }
    }
}
