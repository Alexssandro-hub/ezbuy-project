using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Abstractions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ezBuy.Abstractions.Mapping.EntityBuilder
{
    public class RuleMap : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id) 
                .IsRequired();

            builder.Property(x => x.Responsibility)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(x => x.TenantId).IsRequired();
            builder.Property(x => x.GroupId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            
        }
    }
}
