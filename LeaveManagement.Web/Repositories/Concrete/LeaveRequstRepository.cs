using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories.Concrete
{
    public class LeaveRequstRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequstRepository(ApplicationDbContext dbContext,
                                        IMapper mapper,
                                        IHttpContextAccessor httpContextAccessor,
                                        ILeaveAllocationRepository leaveAllocationRepository,
                                        UserManager<Employee> userManager) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._userManager = userManager;
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            if(model.RequestComments == null)
                model.RequestComments = string.Empty;
            var leaveREquest = _mapper.Map<LeaveRequest>(model);
            leaveREquest.DateCreated = DateTime.Now;
            leaveREquest.RequestingEmployeeId = user.Id;
            await AddAsync(leaveREquest);
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _dbContext.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved != null && q.Approved == true),
                PeningRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedRequests = leaveRequests.Count(q => q.Approved != null && q.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };
            model.LeaveRequests.ToList().ForEach(async request =>
            {
                request.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(request.RequestingEmployeeId));
            });
            return model;
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await _dbContext.LeaveRequests.Where(q => q.RequestingEmployeeId == employeeId).ToListAsync();
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = _mapper.Map<List<LeaveRequestVM>>(await GetAllAsync(user.Id));

            var model = new EmployeeLeaveRequestViewVM(allocations, requests);

            return model;
        }
    }
}
