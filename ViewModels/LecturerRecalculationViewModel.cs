using Psychology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
