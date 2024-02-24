using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBuy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ezBuy.Abstractions.Mapping.EntityBuilder
{
    public class TenantMap : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                    .IsRequired();

            builder.Property(x => x.Name)
                       .HasMaxLength(70) 
                       .IsRequired();

            builder.Property(x => x.Database)
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(x => x.Port)
                    .HasMaxLength(12)
                    .IsRequired();

            builder.Property(x => x.Domain)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(x => x.Server)
                    .HasMaxLength(70)
                    .IsRequired();

            builder.Property(x => x.IsActive)
                    .IsRequired();

            builder.Property(x => x.Type)
                    .IsRequired();
        }
    }
}
