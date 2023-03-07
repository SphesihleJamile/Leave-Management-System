using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public EmployeesController(UserManager<Employee> userManager, 
                                    IMapper mapper,
                                    ILeaveAllocationRepository leaveAllocationRepository,
                                    ILeaveTypeRepository leaveTypeRepository)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var viewModel = _mapper.Map<List<EmployeeListVM>>(employees);
            return View(viewModel);
        }

        // GET: EmployeesController/ViewAllocations/employeeId
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(model);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/EditAllocation/5
        public async Task<IActionResult> EditAllocation(int id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocation(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        // POST: EmployeesController/EditAllocation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(int id, LeaveAllocationEditVM model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var leaveAllocation = await _leaveAllocationRepository.GetAsync(int.Parse(model.Id));
                    if(leaveAllocation == null)
                        return NotFound();
                    leaveAllocation.Period = model.Period;
                    leaveAllocation.NumberOfDays = model.NumberOfDays;
                    await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
                    return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId});
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Something Went Wrong. Please Try Again later");
            }

            //We need to reassign the employee and LeaveType to the model because it was not present in the form, so it will not be present in the model object
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = _mapper.Map<LeaveTypeVM>(await _leaveTypeRepository.GetAsync(model.LeaveTypeId));
            return View(model); //When you return the view, you have to return it with the data that was originally on the page
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
