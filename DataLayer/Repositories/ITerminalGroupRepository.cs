using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ITerminalGroupRepository : IDisposable
    {
        IEnumerable<terminal_groups> GetAllGroup();
        terminal_groups GetGroupById(Guid id);
        bool InsertGroup(terminal_groups terminal_Group);
        bool UpdateGroup(terminal_groups terminal_Group);
        bool DeleteGroup(terminal_groups terminal_Group);
        bool DeleteGroup(Guid id);
        void Save();
    }
}
