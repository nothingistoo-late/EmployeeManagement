using Giaolang.EmployeeManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giaolang.EmployeeManagement.DAL.Repositories
{
    public class EmployeeRepository
    {
        private EmployeeManagementDbContext? _context;

        public List<EmployeeRecord> GetAll()
        {
            _context = new();
            return _context.EmployeeRecords.ToList();
        }

        public void AddEmployee(EmployeeRecord obj)
        {
            _context = new();
            _context.EmployeeRecords.Add(obj);
            _context.SaveChanges();
        }

        public void UpdateEmployee(EmployeeRecord obj)
        {

            _context = new();
            _context.EmployeeRecords.Update(obj);
            _context.SaveChanges();
        }

        public void DeleteEmployee(EmployeeRecord obj)
        {
            _context = new();
            _context.EmployeeRecords.Remove(obj);
            _context.SaveChanges();
        }
    }
}
