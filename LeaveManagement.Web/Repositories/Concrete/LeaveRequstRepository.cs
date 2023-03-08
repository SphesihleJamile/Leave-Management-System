using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Repositories.Concrete
{
    public class LeaveRequstRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequstRepository(ApplicationDbContext dbContext,
                                        IMapper mapper,
                                        IHttpContextAccessor httpContextAccessor,
                                        UserManager<Employee> userManager) : base(dbContext)
        {
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
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
    }
}
