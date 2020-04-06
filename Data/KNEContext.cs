using Microsoft.EntityFrameworkCore;

namespace IDDQD.Data
{
    public class KNEContext : DbContext
    {
        public KNEContext (
            DbContextOptions<KNEContext> options)
            : base(options)
        {
        }

        public DbSet<IDDQD.Models.KnowledgeElements> KnowledgeElements { get; set; }
    }
}