using Giaolang.EmployeeManagement.DAL.Entities;
using Giaolang.EmployeeManagement.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giaolang.EmployeeManagement.BLL.Services
{
    public class EmployeeService
    {

        // GUI -- Service -- Repo -- DBContext -- Table
        private EmployeeRepository _EmployRepo = new();

        public List<EmployeeRecord> GetAllEmployee()
        {
            return _EmployRepo.GetAll();
        }

        public void CreateEmployee(EmployeeRecord obj)
        {
            _EmployRepo.AddEmployee(obj);
        }

        public void UpdateEmployee(EmployeeRecord obj)
        {
            _EmployRepo.UpdateEmployee(obj);
        }

        public void DeleteEmployee(EmployeeRecord obj) 
        { 
            _EmployRepo.DeleteEmployee(obj);
        }

        public List<EmployeeRecord> SearchEmployeeByNameAndSalary(string? name, string? salary)
        {
            List<EmployeeRecord> results = _EmployRepo.GetAll().ToList();
            if (!name.IsNullOrEmpty() && !salary.IsNullOrEmpty()) 
                results = results.Where(x => x.Salary == decimal.Parse(salary) && x.EmployeeName.ToLower().Contains(name.ToLower())).ToList();
            if (name.IsNullOrEmpty() && !salary.IsNullOrEmpty())
                results = results.Where(x => x.Salary == decimal.Parse(salary)).ToList();
            if (!name.IsNullOrEmpty() && salary.IsNullOrEmpty())
                results = results.Where(x => x.EmployeeName.ToLower().Contains(name.ToLower())).ToList();
            return results;
        }

    }
}
