using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.ViewModels
{
    public class LecturerRecalculationViewModel
    {
        public IEnumerable<Group> ListGroup { get; set; }
        public IEnumerable<Test> ListTest { get; set; }
        public long GroupId { get; set; }
        public long TestId { get; set; }
    }
}
