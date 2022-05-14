using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.ViewModels
{
    public class StudentResultViewModel
    {
        public IEnumerable<PassageData> ListPassageData { get; set; }
        public bool SortDate { get; set; }
        public bool SortDesc { get; set; }
        public PassageData PassageData { get; set; }
    }
}
