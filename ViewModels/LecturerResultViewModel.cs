using Psychology.Data.Models;
using System;
using System.Collections.Generic;

namespace Psychology.ViewModels
{
    public class LecturerResultViewModel
    {
        public PassageData PassageData { get; set; }
        public PassageData PassageDataComparison { get; set; }
        public IEnumerable<TestQuestion> ListTestQuestion { get; set; }
        public IEnumerable<Group> ListGroup { get; set; }
        public List<PassageData> ListPassageData { get; set; }
        public bool ComparisonGroup { get; set; }
        public long GroupId { get; set; }
        public long PassageDataId { get; set; }
        public long PassageDataComparisonId { get; set; }
        public double Percent { get; set; }
    }
}
