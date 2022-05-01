﻿using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> List { get; }
    }
}