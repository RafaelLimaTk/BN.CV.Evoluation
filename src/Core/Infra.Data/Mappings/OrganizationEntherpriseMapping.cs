using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings;

public class OrganizationEntherpriseMapping : IEntityTypeConfiguration<OrganizationEntherprise>
{
    public void Configure(EntityTypeBuilder<OrganizationEntherprise> entitie)
    {
        var tableName = nameof(OrganizationEntherprise);

        entitie.ToTable(tableName);
        entitie.HasKey(a => a.Id);
        entitie.Property(a => a.Id).HasColumnName($"{tableName}Id");

        entitie.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(155);

        entitie.Property(a => a.ClassificationType)
            .IsRequired()
            .HasDefaultValue(ClassificationType.SMALL);
    }
}
