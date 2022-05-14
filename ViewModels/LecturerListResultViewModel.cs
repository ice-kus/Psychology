using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.ViewModels
{
    public class LecturerListResultViewModel
    {
        public IEnumerable<Group> ListGroup { get; set; }
        public IEnumerable<Student> ListStudent { get; set; }
        public IEnumerable<Test> ListTest { get; set; }
        public long TestId { get; set; }
        public long GroupId { get; set; }
        public long StudentId { get; set; }
        public IEnumerable<PassageData> ListPassageData { get; set; }
        public bool SortDate { get; set; }
        public bool SortDesc { get; set; }
    }
}
