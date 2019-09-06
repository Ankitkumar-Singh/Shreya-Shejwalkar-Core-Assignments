using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFAssignment.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        #region "Get All Employees"
        /// <summary>
        /// Get all employees and display list of employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDetails> GetAllEmployee()
        {
            return context.EmployeeDetails.Include(e => e.DepartmentDetails).ToList();
        }
        #endregion

        #region "Get Employee Details"
        /// <summary>
        /// Get Employee Details by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmployeeDetails GetEmployeeDetails(int Id)
        {
            return context.EmployeeDetails.Include(e => e.DepartmentDetails).SingleOrDefault(e => e.Id == Id);
        }
        #endregion

        #region "Add and Edit Employee details"
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
                    context.EmployeeDetails.Add(employee);
                }
                else
                {
                    context.Entry(employee).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            return context.EmployeeDetails.Where(e => e.Name == employee.Name).FirstOrDefault();
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
            EmployeeDetails employee = context.EmployeeDetails.Find(Id);
            if (employee != null)
            {
                context.EmployeeDetails.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }
        #endregion
    }
}
