using EFAssignment.Models;
using EFAssignment.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace EFAssignment.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        readonly AppDbContext context;
        public EmployeeController(AppDbContext context, IEmployeeRepository employeeRepository)
        {
            this.context = context;
            _employeeRepository = employeeRepository;
        }

        #region "Index"
        /// <summary>
        /// Display list of Employees
        /// </summary>
        /// <returns></returns>
        [Route("/")]
        [Route("Index")]
        public ViewResult Index()
        {
            return View(_employeeRepository.GetAllEmployee());
        }
        #endregion

        #region "Details"
        /// <summary>
        /// Details of employee by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Details")]
        public ViewResult Details(int id)
        {
            return View(_employeeRepository.GetEmployeeDetails(id));
        }
        #endregion

        #region "Add and Edit employee Details"
        /// <summary>
        /// Add and Edit employee Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("SaveEmployeeDetails/{id?}")]
        [HttpGet]
        public ViewResult SaveEmployeeDetails(int id)
        {
            ViewBag.DepartmentId = context.DepartmentDetails.Select(e => new SelectListItem()
            {
                Value = e.Id.ToString(),
                Text = e.Name.ToString()
            });
            var model = _employeeRepository.GetEmployeeDetails(id);
            if (model == null)
                model = new EmployeeDetails();
            return View(model);
        }

        [Route("SaveEmployeeDetails/{id?}")]
        [HttpPost]
        public IActionResult SaveEmployeeDetails(EmployeeDetails employee)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index", _employeeRepository.SaveEmployeeDetails(employee));
            return View();
        }
        #endregion

        #region "Delete Employee"
        /// <summary>
        /// Delete employee Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete/{id?}")]
        [HttpGet]
        public ViewResult Delete(int? id)
        {
            return View(_employeeRepository.GetEmployeeDetails(id ?? 1));
        }

        [Route("Delete/{id?}")]
        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            return RedirectToAction("Index", _employeeRepository.DeleteEmployee(id));
        }
        #endregion
    }
}