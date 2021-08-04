using Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Data.Context
{
    public class ProdutosDbContext : DbContext
    {
        public ProdutosDbContext()
        {
        }

        public ProdutosDbContext(DbContextOptions<ProdutosDbContext> options) : base(options)
        {
            {
                ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                ChangeTracker.AutoDetectChangesEnabled = false;
            }
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutosDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
