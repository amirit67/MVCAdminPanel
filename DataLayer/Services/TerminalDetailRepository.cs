using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TerminalDetailRepository : ITerminalDetailRepository
    {
        MyCmsContext db;

        public TerminalDetailRepository(MyCmsContext context)
        {
            this.db = context;
        }


        public IEnumerable<terminal_detail> GetAllTerminals()
        {
            return db.terminal_Details;
        }

        public terminal_detail GetTerminalById(Guid id)
        {
            return db.terminal_Details.Find(id);
        }

        public bool InsertTerminal(terminal_detail terminal_Detail)
        {
            try
            {
                db.terminal_Details.Add(terminal_Detail);
                return true;
            }
            catch(Exception e)
            {
                return false;                
            }
            
        }

        public bool DeleteTerminal(terminal_detail terminal_Detail)
        {

            try
            {
                db.Entry(terminal_Detail).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteTerminal(Guid id)
        {
            try
            {
                var terminal = GetTerminalById(id);
                DeleteTerminal(terminal);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }                     

        public bool UpdateTerminal(terminal_detail terminal_Detail)
        {
            
            try
            {
                db.Entry(terminal_Detail).State = System.Data.Entity.EntityState.Modified;
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
