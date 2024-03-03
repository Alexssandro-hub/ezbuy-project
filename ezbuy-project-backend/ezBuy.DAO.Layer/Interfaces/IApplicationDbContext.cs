using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data; 
using EzBuy.Models; 

namespace EzBuy.Interfaces;

public interface IApplicationDbContext
{
    public IDbConnection Connection { get; }
    DatabaseFacade Database { get; }
    public DbSet<User> Users { get; set; }  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}