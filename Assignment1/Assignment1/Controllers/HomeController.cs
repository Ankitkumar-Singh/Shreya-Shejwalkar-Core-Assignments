using Assignment1.Models;
using Assignment1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignment1.Controllers
{
    
    [Route("Home")]   
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        #region "IEmployeeRepository service Injection"
        /// <summary>
        /// Injecting IEmployeeRepository service into HomeController using Constructor
        /// </summary>
        /// <param name="employeeRepository"></param>
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region "Index"
        /// <summary>
        /// Display list of employees
        /// </summary>
        /// <returns></returns>
        [Route("/")]
        [Route("Index")]
        public ViewResult Index()
        {
            IEnumerable<EmployeeDetails> model = _employeeRepository.GetAllEmployees();
            return View(model);
        }
        #endregion

        #region "Details"
        /// <summary>
        /// Get employee Details by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Details")]
        public ViewResult Details(int id)
        {
            return View(_employeeRepository.GetEmployeeDetails(id));
        }
        #endregion

        #region "Add and Edit"
        /// <summary>
        /// Add and edit employee details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("SaveEmployeeDetails/{id?}")]
        [HttpGet]
        public ViewResult SaveEmployeeDetails(int id)
        {
            return View(_employeeRepository.GetEmployeeDetails(id));
        }

        [Route("SaveEmployeeDetails/{id?}")]
        [HttpPost]
        public IActionResult SaveEmployeeDetails(EmployeeDetails employee)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", _employeeRepository.SaveEmployeeDetails(employee));
            }
            return View();
        }
        #endregion

        #region "Delete  Employee"
        /// <summary>
        /// Delete employee by their id
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