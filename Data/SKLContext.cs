using Microsoft.EntityFrameworkCore;

namespace IDDQD.Data
{
    public class SKLContext : DbContext
    {
        public SKLContext (
            DbContextOptions<SKLContext> options)
            : base(options)
        {
        }

        public DbSet<IDDQD.Models.SkillLevel> SkillLevel { get; set; }
    }
}