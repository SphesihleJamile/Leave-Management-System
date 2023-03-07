using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
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
        private readonly IMapper _mapper;

        public LeaveAllocationRepository(ApplicationDbContext dbContext, 
                                            UserManager<Employee> userManager,
                                            ILeaveTypeRepository leaveTypeRepository,
                                            IMapper mapper) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._leaveTypeRepository = leaveTypeRepository;
            this._mapper = mapper;
        }

        public async Task<bool> AllocationExistsAsync(string employeeId, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId &&
                                                                q.LeaveTypeId == leaveTypeId &&
                                                                q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId.Equals(employeeId))
                .ToListAsync();
            var emloyee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(emloyee);
            employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations);

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            var allocation = await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (allocation == null)
                return null;

            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);
            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(allocation.EmployeeId));

            return model;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);

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
