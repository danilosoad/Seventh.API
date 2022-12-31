using Microsoft.EntityFrameworkCore;
using Seventh.Domain.Entities.Servers;

namespace Seventh.Infra.Data.DataContext
{
    public class Context : DbContext
    {
        public DbSet<Server> Servers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SeventhDb");
        }
    }
}