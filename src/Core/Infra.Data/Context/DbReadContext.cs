using Domain.Entities;
using Domain.Entities.Base;
using Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class DbReadContext : DbContext
{
    public DbReadContext(DbContextOptions<DbReadContext> options) : base(options)
    {
    }

    #region Entities
    public DbSet<OrganizationEntherprise> OrganizationEntherprises { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new OrganizationEntherpriseMapping());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is EntityBase && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                if (entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "CreateDate") != null)
                    entityEntry.Property("CreateDate").IsModified = false;

                if (entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "CreateUser") != null)
                    entityEntry.Property("CreateUser").IsModified = false;

                if (entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "UpdateDate") != null)
                    ((EntityBase)entityEntry.Entity).UpdateDate = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
