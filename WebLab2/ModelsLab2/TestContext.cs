using Microsoft.EntityFrameworkCore;
namespace WebLab2.ModelsLab2
{
    public partial class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        { }

        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Cost).IsRequired();
            });
            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.TypeID).IsRequired();
            });

        }
    }
}
