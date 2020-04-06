using Microsoft.EntityFrameworkCore;

namespace IDDQD.Data
{
    public class DISPContext : DbContext
    {
        public DISPContext (
            DbContextOptions<DISPContext> options)
            : base(options)
        {
        }

        public DbSet<IDDQD.Models.Dispositions> Dispositions { get; set; }
    }
}