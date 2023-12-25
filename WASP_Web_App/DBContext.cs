using Microsoft.EntityFrameworkCore;
using WASP_Web_App;

namespace WASP_Web_App
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Zespol> ProgramowanieZespolowe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships, indexes, etc., if needed
            base.OnModelCreating(modelBuilder);
        }

    }
}
