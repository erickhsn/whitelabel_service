using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Whitelabel.Service.Domain.Entities;

namespace Whitelabel.Service.Impl.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("id").IsRequired();
            builder.Property(u => u.Name).HasColumnName("name").IsRequired();
        }
    }
}
