using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.ViewModels
{
    public class LecturerResultViewModel
    {
        public PassageData PassageData { get; set; }
        public IEnumerable<TestQuestion> ListTestQuestion { get; set; }
    }
}
