using EFAssignment.Models;
using System.Collections.Generic;

namespace EFAssignment.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDetails> GetAllEmployee();

        EmployeeDetails GetEmployeeDetails(int Id);

        EmployeeDetails SaveEmployeeDetails(EmployeeDetails employee);

        EmployeeDetails DeleteEmployee(int Id);
    }
}
