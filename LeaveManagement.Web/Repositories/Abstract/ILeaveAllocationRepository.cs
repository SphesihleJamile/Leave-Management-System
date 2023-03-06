using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Repositories.Abstract
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExistsAsync(string employeeId, int leaveTypeId, int period);
    }
}
