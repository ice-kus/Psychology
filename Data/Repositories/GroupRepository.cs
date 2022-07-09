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

        public void Create(string Name)
        {
            DB.Group.Add
               (
               new Group
               {
                   Name = Name
               }
               );
        }

        public void Delete(long Id)
        {
            DB.Group.Remove(DB.Group.Find(Id));
        }

        public bool Save()
        {
            try
            {
                DB.SaveChanges();
            }
            catch
            {
                DB.ChangeTracker.Clear();
                return false;
            }
            return true;
        }

        public void Update(Group Group)
        {
            DB.Group.Update(Group);
        }
    }
}
