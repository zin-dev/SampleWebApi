using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Sample.Domains;
using Sample.Repositories;

namespace Sample.Services
{
    public class EmployeeService
    {
        private readonly DBContext _context;

        public EmployeeService(DBContext context)
        {
            _context = context;
        }

        public void Save(Employee newEmployee)
        {
            EmployeeRepository employeeRepo = new EmployeeRepository(_context);
            var employee = GetEmployee(newEmployee.Id);

            if (employee == null)
            {
                employeeRepo.Insert(newEmployee);
            }
            else
            {
                employeeRepo.Update(newEmployee);
            }
        }

        public async Task<Employee> GetEmployee(int employeeId) => await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);

        public async Task<IEnumerable<Employee>> GetAll() => await _context.Employees.ToListAsync();

    }
}
