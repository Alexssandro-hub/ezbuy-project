using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Abstractions.Models;
using EzBuy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ezBuy.Abstractions.Mapping.EntityBuilder
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                    .IsRequired();

            builder.Property(x => x.Email)
                    .HasMaxLength(150)
                    .IsRequired();

            builder.Property(x => x.UserName)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(x => x.Password)
                    .HasMaxLength(40)
                    .IsRequired();

            builder.Property(x => x.FullName)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(x => x.GroupId)
                    .IsRequired();

            builder.Property(x => x.RuleId)
                    .IsRequired();  

            builder.Property(x => x.TenantId)
                    .IsRequired();

            builder.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(x => x.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
              
        }
    }
}
