using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> List { get; }
    }
}
