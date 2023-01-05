using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Seventh.Domain.Entities.Recycles;
using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Videos;
using Seventh.Infra.Data.Mapping.Recycles;
using Seventh.Infra.Data.Mapping.Servers;
using Seventh.Infra.Data.Mapping.Videos;

namespace Seventh.Infra.Data.DataContext
{
    public class Context : DbContext
    {
        public DbSet<Server> Servers { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Recycle> Recycles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SeventhDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<ValidationFailure>();

            modelBuilder.ApplyConfiguration(new ServerMap());
            modelBuilder.ApplyConfiguration(new VideoMap());
            modelBuilder.ApplyConfiguration(new RecycleMap());
        }
    }
}