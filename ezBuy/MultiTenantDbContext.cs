using ezBuy.Domain.Models;
using ezBuy.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ezBuy
{
    public class MultiTenantDbContext : DbContext
    {
        private readonly ITenantProvider _tenantProvider;

        public MultiTenantDbContext(DbContextOptions<MultiTenantDbContext> options, ITenantProvider tenantProvider)
            : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var schema = _tenantProvider.GetCurrentTenantSchema();
            modelBuilder.HasDefaultSchema(schema);

            // Configuração de entidades...
             
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
