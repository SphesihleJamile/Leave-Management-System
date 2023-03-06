using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;

        public EmployeesController(UserManager<Employee> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }

        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var viewModel = _mapper.Map<List<EmployeeListVM>>(employees);
            return View(viewModel);
        }

        // GET: EmployeesController/ViewAllocations/5
        public ActionResult ViewAllocations(int id)
        {
            return View();
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

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
