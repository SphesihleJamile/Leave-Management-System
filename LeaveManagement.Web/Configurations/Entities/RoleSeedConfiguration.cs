using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            //define data
            builder.HasData(
                new IdentityRole
                {
                    Id = "e19a7d84-998d-487d-ba54-3a8a1368c5c8",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                },
                new IdentityRole
                {
                    Id = "f9b7e84-998e-487e-cb54-3b8b1368d5d8",
                    Name = "User",
                    NormalizedName = "USER",
                }
            );
            throw new NotImplementedException();
        }
    }
}