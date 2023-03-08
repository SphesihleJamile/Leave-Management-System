using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public SelectList? LeaveTypes { get; set; }
        [Required]
        public int LeaveTypeId { get; set; }
        [Display(Name = "Request Comments")]
        public string? RequestComments { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartDate > EndDate)
            {
                yield return new ValidationResult("Start Date must be before end date", new[]
                {
                    nameof(StartDate),
                    nameof(EndDate)
                });
            }
            if(RequestComments != null && RequestComments.Length > 250)
            {
                yield return new ValidationResult("Comments are too long", new[]
                {
                    nameof(RequestComments)
                });
            }
        }
    }
}
