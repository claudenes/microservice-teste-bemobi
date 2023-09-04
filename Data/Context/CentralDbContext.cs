using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class CentralDbContext : DbContext
    {
        public CentralDbContext(DbContextOptions<CentralDbContext> option) : base(option)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                .HaveColumnType("varchar")
                .HaveMaxLength(256);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Arquivo>(new ArquivoMap().Configure);   
        }
    }
}
