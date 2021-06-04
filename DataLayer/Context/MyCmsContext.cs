
using System.Data.Entity;

namespace DataLayer
{
    public class MyCmsContext : DbContext
    {
        public DbSet<terminal_detail> terminal_Details { get; set; }
        public DbSet<terminal_groups> terminal_Groups { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
    }
}
