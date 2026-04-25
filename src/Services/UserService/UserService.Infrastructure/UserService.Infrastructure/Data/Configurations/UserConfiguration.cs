using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);

            builder.HasData(
                new User
                {
                    UserId = 1,
                    Email = "sumith.k.mohan@gmail.com",
                    FirstName = "Sumith",
                    LastName = "K Mohan",
                    Password = "123",
                    RoleId=1
                }
            );
        }
    }
}
