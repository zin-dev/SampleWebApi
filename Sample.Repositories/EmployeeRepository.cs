using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Sample.Domains;

namespace Sample.Repositories
{
    public interface IEmployeeRepository
    {
        void Insert(Employee newEmployee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBContext _context;

        public EmployeeRepository(DBContext context)
        {
            _context = context;
        }

        public void Insert(Employee newEmployee)
        {
            try
            {
                _context.Employees.Add(newEmployee);
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void Update(Employee updateEmployee)
        {
            try
            {
                Employee employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == updateEmployee.Id);

                employee.FirstName = updateEmployee.FirstName;
                employee.LastName = updateEmployee.LastName;
                employee.Age = updateEmployee.Age;
                employee.Gender = updateEmployee.Gender;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Employee deleteEmployee)
        {
            try
            {
                _context.Employees.Remove(deleteEmployee);
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
