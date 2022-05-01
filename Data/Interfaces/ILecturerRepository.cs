using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface ILecturerRepository
    {
        IEnumerable<Lecturer> List { get; }
    }
}
