using CRUDApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private TrainingDbContext _context;
        public EmployeeRepository(TrainingDbContext trainingDbContext)
        {
            this._context = trainingDbContext;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee GetEmployeeByID(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }
        public void InsertEmployee(Employee employees)
        {
            _context.Employees.Add(employees);
            _context.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            Employee employees = _context.Employees.Find(id);   
            _context.Employees.Remove(employees);
            _context.SaveChanges();
        }
        public void UpdateEmployee(Employee employees)
        {
            _context.Employees.Update(employees);
            _context.SaveChanges();
        }

    }
}
