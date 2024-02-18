using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ezBuy.Abstractions.Models;
using EzBuy.Models;
using Rule = ezBuy.Abstractions.Models.Rule;

namespace EzBuy.Interfaces;

public interface IApplicationDbContext
{
    public IDbConnection Connection { get; }
    DatabaseFacade Database { get; }
    public DbSet<User> Users { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Rule> Rules { get; set; }
    public DbSet<Group> Groups { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}