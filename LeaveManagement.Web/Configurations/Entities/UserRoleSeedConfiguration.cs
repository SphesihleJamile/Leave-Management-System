using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "e19a7d84-998d-487d-ba54-3a8a1368c5c8",
                    UserId = "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "f9b7e84-998e-487e-cb54-3b8b1368d5d8a",
                    UserId = "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5"
                }
            );
        }
    }
}