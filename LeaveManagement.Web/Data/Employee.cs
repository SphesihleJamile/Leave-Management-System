using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Data
{
    public class Employee : IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? TaxId { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
