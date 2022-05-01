﻿using Psychology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychology.ViewModels
{
    public class LecturerUpdateCriteriaViewModel
    {
        public IEnumerable<Criteria> ListCriteria { get; set; }
        public Criteria Criteria { get; set; }
        public int Size { get; set; }
        public int Scale { get; set; }
        public int NumQuestion { get; set; }
        public int NumAnswer { get; set; }
        public int Index { get; set; }
    }
}
