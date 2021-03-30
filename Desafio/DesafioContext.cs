using Desafio.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Rick> Ricks { get; set; }

        public DbSet<Travel> Travels { get; set; }

        public DbSet<Dimension> Dimensions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("RickLocalization");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
