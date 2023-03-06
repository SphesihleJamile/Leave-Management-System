namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationVM
    {
        public string Id { get; set; }
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
    }
}