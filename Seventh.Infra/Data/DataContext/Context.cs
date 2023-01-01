using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Videos;
using Seventh.Infra.Data.Mapping;

namespace Seventh.Infra.Data.DataContext
{
    public class Context : DbContext
    {
        public DbSet<Server> Servers { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SeventhDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<ValidationFailure>();

            modelBuilder.ApplyConfiguration(new ServerMap());
        }
    }
}