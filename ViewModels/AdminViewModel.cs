using Psychology.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Psychology.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<Group> ListGroup { get; set; }
        public IEnumerable<Student> ListStudent { get; set; }
        public IEnumerable<Lecturer> ListLecturer { get; set; }
        public Group Group { get; set; }
        public Student Student { get; set; }
        public Lecturer Lecturer { get; set; }
        public bool Delete { get; set; }
        public string Message { get; set; }
    }
}
