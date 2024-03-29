﻿using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.ViewModels
{
    public class LecturerUpdateQuestionViewModel
    {
        public IEnumerable<Question> ListQuestion { get; set; }
        public Question Question { get; set; }
        public List<Answer> ListAnswer { get; set; }
        public int Type { get; set; }
        public long TestId { get; set; }
    }
}
