using BusinessLogic.DomainObjects;
using Microsoft.EntityFrameworkCore;
using DataAccess.FakeData;

namespace DataAccess
{
    public class SupportWheelOfFateDbContext : DbContext
    {
        public SupportWheelOfFateDbContext(DbContextOptions<SupportWheelOfFateDbContext> options) : base(options)
        {
        }

        public DbSet<Engineer> Engineers { get; set; }

        public DbSet<RotaEntry> RotaEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var fakeEngineer in FakeEntities.Engineers)
            {
                modelBuilder.Entity<Engineer>().HasData(fakeEngineer);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
