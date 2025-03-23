using Microsoft.EntityFrameworkCore;
using QueueApi.Entities;

namespace QueueApi.DbContexts
{
    public class QueueContext(DbContextOptions<QueueContext> options) : DbContext(options)
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Name = "Pending"
                },
                new Status
                {
                    Id = 2,
                    Name = "In Progress"
                },
                new Status
                {
                    Id = 3,
                    Name = "Completed"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
