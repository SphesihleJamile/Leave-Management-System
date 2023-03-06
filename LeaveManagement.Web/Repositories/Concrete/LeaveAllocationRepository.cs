using LeaveManagement.Web.Data;
using LeaveManagement.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories.Concrete
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveAllocationRepository(ApplicationDbContext dbContext, 
                                            UserManager<Employee> userManager,
                                            ILeaveTypeRepository leaveTypeRepository) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<bool> AllocationExistsAsync(string employeeId, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId &&
                                                                q.LeaveTypeId == leaveTypeId &&
                                                                q.Period == period);
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetByIdAsync(leaveTypeId);

            var allocations = new List<LeaveAllocation>();

            foreach(var employee in employees)
            {
                if (await AllocationExistsAsync(employee.Id, leaveTypeId, period))
                    continue;
                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });
            }
            await AddRangeAsync(allocations);
        }
    }
}
