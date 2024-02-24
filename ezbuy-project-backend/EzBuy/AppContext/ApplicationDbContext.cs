using ezBuy.Abstractions.Mapping.EntityBuilder;
using ezBuy.Abstractions.Models;
using EzBuy.Interfaces;
using EzBuy.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Rule = ezBuy.Abstractions.Models.Rule;

namespace EzBuy.AppContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuração do banco de dados, como string de conexão, provedor, etc.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schemas.RootSchema);
               
            new TenantMap().Configure(modelBuilder.Entity<Tenant>()); 
            new UserMap().Configure(modelBuilder.Entity<User>());
            new RuleMap().Configure(modelBuilder.Entity<Rule>());
            new GroupMap().Configure(modelBuilder.Entity<Group>());

            modelBuilder.Entity<Group>()
                        .HasOne(g => g.User)
                        .WithOne(u => u.Group)
                        .HasForeignKey<User>(u => u.GroupId);

            modelBuilder.Entity<Group>()
                        .HasOne(g => g.Tenant)
                        .WithOne(u => u.Group)
                        .HasForeignKey<Tenant>(u => u.GroupId);

            modelBuilder.Entity<Rule>()
                        .HasOne(g => g.User)
                        .WithOne(u => u.Rule)
                        .HasForeignKey<User>(u => u.RuleId);

            modelBuilder.Entity<Rule>()
                        .HasOne(g => g.Tenant)
                        .WithOne(u => u.Rule)
                        .HasForeignKey<Tenant>(u => u.RuleId);

            modelBuilder.Entity<Rule>()
                        .HasOne(g => g.Group)
                        .WithOne(u => u.Rule)
                        .HasForeignKey<Group>(u => u.RuleId);


            modelBuilder.Entity<User>()
                        .HasOne(g => g.Group)
                        .WithOne(u => u.User)
                        .HasForeignKey<Group>(u => u.UserId);

            modelBuilder.Entity<User>()
                        .HasOne(g => g.Rule)
                        .WithOne(u => u.User)
                        .HasForeignKey<Rule>(u => u.UserId);


            modelBuilder.Entity<User>()
                        .HasOne(g => g.Tenant)
                        .WithOne(u => u.User)
                        .HasForeignKey<Tenant>(u => u.UserId);


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

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Group> Groups { get; set; }


        public IDbConnection Connection => Database.GetDbConnection();
    }
}
