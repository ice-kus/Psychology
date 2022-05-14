using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.ViewModels
{
    public class StudentPassingTestViewModel
    {
        public IEnumerable<TestQuestion> ListTestQuestion { get; set; }
        public int NumQuestion { get; set; }
        public long TestId { get; set; }
        public long PassageDataId { get; set; }
        public long TestSize { get; set; }
        public List<int> ListMix { get; set; }
    }
}
