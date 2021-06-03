using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ITerminalDetailRepository : IDisposable
    {
        IEnumerable<terminal_detail> GetAllTerminals();
        terminal_detail GetTerminalById(Guid id);
        bool InsertTerminal(terminal_detail terminal_Detail);
        bool UpdateTerminal(terminal_detail terminal_Detail);
        bool DeleteTerminal(terminal_detail terminal_Detail);
        bool DeleteTerminal(Guid id);
        void Save();
    }
}
