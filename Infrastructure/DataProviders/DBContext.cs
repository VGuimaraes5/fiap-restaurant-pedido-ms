using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.DataProviders.EntityConfigurations;
using Infrastructure.Seeds;

namespace Infrastructure.DataProviders
{
    public class DBContext : DbContext
    {

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoriaEntityConfiguration());

            modelBuilder.ApplyConfiguration(new ProdutoEntityConfiguration());

            modelBuilder.ApplyConfiguration(new ClienteEntityConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);

            CategoriaSeed.Seed(modelBuilder);
            ProdutoSeed.Seed(modelBuilder);
        }
    }


}
