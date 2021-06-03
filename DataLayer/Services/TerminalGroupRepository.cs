using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TerminalGroupRepository : ITerminalGroupRepository
    { 

        MyCmsContext db;

        public TerminalGroupRepository(MyCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<terminal_groups> GetAllGroup()
        {
            return db.terminal_Groups;
        }

        public terminal_groups GetGroupById(Guid id)
        {
            return db.terminal_Groups.Find(id);
        }

        public bool DeleteGroup(terminal_groups terminal_Group)
        {
            try
            {
                db.Entry(terminal_Group).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteGroup(Guid id)
        {
            try
            {
                var group = GetGroupById(id);
                DeleteGroup(group);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
       
        public bool InsertGroup(terminal_groups terminal_Group)
        {
            try
            {
                db.terminal_Groups.Add(terminal_Group);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }        

        public bool UpdateGroup(terminal_groups terminal_Group)
        {
            try
            {
                db.Entry(terminal_Group).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}