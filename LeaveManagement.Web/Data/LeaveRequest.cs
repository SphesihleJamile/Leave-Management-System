using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; } = string.Empty;

        public bool? Approved { get; set; } //When Approved is null, then it means that this request is pending approval
        public bool Cancelled { get; set; }

        public string RequestingEmployeeId { get; set; } = string.Empty;
    }
}
