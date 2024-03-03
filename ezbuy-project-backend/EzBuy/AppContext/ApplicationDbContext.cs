using ezBuy.Abstractions.Mapping.EntityBuilder; 
using EzBuy.Interfaces;
using EzBuy.Models;
using Microsoft.EntityFrameworkCore;
using System.Data; 

namespace EzBuy.AppContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schemas.RootSchema);
                
            new UserMap().Configure(modelBuilder.Entity<User>()); 

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "System",
                    LastName = "Admin",
                    Email = "admin@ezbuy.com.br",
                    Password = "admin",
                    UserName = "admin",
                    IsActive = true,
                }
            );
             
            // MAPEAMENTO PARA ENTIDADE EM UM SCHEMA FILHO
            //modelBuilder.Entity<SuaEntidade>()
            //    .ToTable("Entity", "ChildSchema")
            //    .HasOne(e => e.Tenant)
            //    .WithMany()
            //    .HasForeignKey(e => e.TenantId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
         
        public DbSet<User> Users { get; set; } 
         
        public IDbConnection Connection => Database.GetDbConnection();
    }
}
