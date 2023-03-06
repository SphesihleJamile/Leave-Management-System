using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@assword1"),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5",
                    Email = "user1@localhost.com",
                    NormalizedEmail = "USER1@LOCALHOST.COM",
                    UserName = "user1@localhost.com",
                    NormalizedUserName = "USER1@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@assword1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}