using Assignment1.Models;
using System.Collections.Generic;

namespace Assignment1.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Declaration of methods which are implemented in MockEmployeeRepository
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeDetails> GetAllEmployees();

        EmployeeDetails GetEmployeeDetails(int Id);
      
        EmployeeDetails SaveEmployeeDetails(EmployeeDetails employee);      

        EmployeeDetails DeleteEmployee(int Id);
    }
}
