using Psychology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychology.ViewModels
{
    public class StudentPassingTestViewModel
    {
        public IEnumerable<TestQuestion> ListTestQuestion { get; set; }
        public int NumQuestion { get; set; }
        public long TestId { get; set; }
        public long StatisticsId { get; set; }
        public long TestSize { get; set; }
        public List<int> ListMix { get; set; }
    }
}
