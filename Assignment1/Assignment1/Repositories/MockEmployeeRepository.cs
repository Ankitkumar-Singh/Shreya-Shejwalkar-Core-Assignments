using Assignment1.Models;
using System.Collections.Generic;
using System.Linq;
using static Assignment1.Models.EmployeeDetails;

namespace Assignment1.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<EmployeeDetails> _employeeList;

        #region "Employee Data"
        /// <summary>
        /// List of employees
        /// </summary>
        public MockEmployeeRepository()
        {
            _employeeList = new List<EmployeeDetails>()
            {
                new EmployeeDetails()
                {
                    Id = 1,
                    Name = "Mary",
                    Department = Departments.HR,
                    SelectedGenderType = GenderType.Female,
                    Email = "mary@gmail.com",
                    Address ="Araneta Center Post Office ",
                    AcceptsTerms = true
                },
                new EmployeeDetails()
                {
                    Id = 2,
                    Name = "John",
                    Department = Departments.IT,
                    SelectedGenderType = GenderType.Male ,
                    Email = "john@gmail.com",
                    Address ="  Kundiman Street, Sampaloc",
                    AcceptsTerms = true
                },
                new EmployeeDetails()
                {
                    Id = 3,
                    Name = "Sam",
                    Department = Departments.IT,
                    SelectedGenderType = GenderType.Male,
                    Email = "sam@gmail.com",
                    Address ="Quezon City, Metro Manila",
                    AcceptsTerms = false
                },
                new EmployeeDetails()
                {
                    Id = 4,
                    Name = "Shreya",
                    Department = Departments.HR,
                    SelectedGenderType = GenderType.Female,
                    Email = "shreya@gmail.com",
                    Address ="Domingo Street, Carmona, Makati City",
                    AcceptsTerms = true
                },
                new EmployeeDetails()
                {
                    Id = 5,
                    Name = "Hannah",
                    Department = Departments.Payroll,
                    SelectedGenderType = GenderType.Female,
                    Email = "hannah@gmail.com",
                    Address ="Del Pilar, San Fernando City" ,
                    AcceptsTerms = false
                },
            };
        }
        #endregion

        #region "Display all employees"
        /// <summary>
        /// display list of employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDetails> GetAllEmployees()
        {
            return _employeeList;
        }
        #endregion

        #region "Employee Details"
        /// <summary>
        /// Get employee details by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmployeeDetails GetEmployeeDetails(int Id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == Id);
        }
        #endregion

        #region "Add and edit employee details"
        /// <summary>
        /// Add and edit employee details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public EmployeeDetails SaveEmployeeDetails(EmployeeDetails employee)
        {
            if (employee != null)
            {
                if (employee.Id == 0)
                {
                    employee.Id = _employeeList.Max(e => e.Id) + 1;
                    _employeeList.Add(employee);
                }
                else
                {
                    EmployeeDetails employeeChanges = _employeeList.FirstOrDefault(e => e.Id == employee.Id);
                    employeeChanges.Name = employee.Name;
                    employeeChanges.SelectedGenderType = employee.SelectedGenderType;
                    employeeChanges.Email = employee.Email;
                    employeeChanges.Department = employee.Department;
                    employeeChanges.Address = employee.Address;
                    employeeChanges.AcceptsTerms = employee.AcceptsTerms;
                }
            }
            return _employeeList.Where(e => e.Name == employee.Name).FirstOrDefault();
        }
        #endregion

        #region "Delete Employee"
        /// <summary>
        /// Delete Employee by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmployeeDetails DeleteEmployee(int Id)
        {
            EmployeeDetails employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
                _employeeList.Remove(employee);          
            return employee;
        }
        #endregion
    }
}
