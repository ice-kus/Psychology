using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using System.Collections.Generic;

namespace Psychology.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext DB;
        public GroupRepository(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Group> List => DB.Group;
    }
}
