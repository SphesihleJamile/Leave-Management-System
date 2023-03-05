using LeaveManagement.Web.Data;
using LeaveManagement.Web.Repositories.Abstract;

namespace LeaveManagement.Web.Repositories.Concrete
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
