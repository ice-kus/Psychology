using Psychology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IEnumerable<Statistics> ListStatistics { get; set; }
        public bool SortDate { get; set; }
        public bool SortDesc { get; set; }
    }
}
