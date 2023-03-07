using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Invalid Number Entered")]
        public int NumberOfDays { get; set; }

        [Required]
        [Display(Name = "Allocation Period")]
        public int Period { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }
    }
}