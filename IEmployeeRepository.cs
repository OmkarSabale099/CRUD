using CRUDApplication.Models;

namespace CRUDApplication.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int id);
        void InsertEmployee(Employee book);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
       
    }
}

