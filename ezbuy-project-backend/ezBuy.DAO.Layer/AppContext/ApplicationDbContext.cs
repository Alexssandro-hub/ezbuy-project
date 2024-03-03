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
              
            //modelBuilder.Entity<User>().HasOne(x => x.Group).WithOne(x => x.User);
            //modelBuilder.Entity<User>().HasOne(x => x.Tenant).WithOne(x => x.User);
            //modelBuilder.Entity<User>().HasOne(x => x.Rule).WithOne(x => x.User);
            //modelBuilder.Entity<User>()
            //            .HasOne(e => e.Tenant)
            //            .WithMany()
            //            .HasForeignKey(e => e.TenantId)
            //            .HasForeignKey(x => x.RuleId)
            //            .HasForeignKey(x => x.GroupId)
            //            .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Rule>()
            //            .HasOne(e => e.Tenant)
            //            .WithMany()
            //            .HasForeignKey(e => e.TenantId)
            //            .HasForeignKey(x => x.UserId)
            //            .HasForeignKey(x => x.GroupId)
            //            .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Group>()
            //            .HasOne(e => e.Tenant)
            //            .WithMany()
            //            .HasForeignKey(e => e.TenantId)
            //            .HasForeignKey(x => x.UserId)
            //            .OnDelete(DeleteBehavior.Restrict);


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
