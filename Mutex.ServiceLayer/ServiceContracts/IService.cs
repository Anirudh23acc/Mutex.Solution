using Mutex.DataLayer.Models;

namespace Mutex.ServiceLayer.ServiceContracts;

public interface IService
{
    bool Authenticate(Admin admin);
    bool AddEmployee(Employee employee);
    Employee? GetDetails(int id);
    List<Employee> GetEmployees();
    List<Employee> SearchEmployees(string? searchItem);
}
