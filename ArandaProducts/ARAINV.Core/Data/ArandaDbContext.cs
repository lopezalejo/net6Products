using ARAINV.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ARAINV.Core.Data
{
    public partial class ArandaDbContext : DbContext
    {
        public ArandaDbContext() : base() { }

        public ArandaDbContext(DbContextOptions<ArandaDbContext> options) : base(options) { }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArandaDbContext).Assembly);
        }

    }
}
