using Mutex.DataLayer.Models;

namespace Mutex.DataLayer.DataContracts;

public interface IRepository
{
    bool Authenticate(Admin admin);
    bool AddEmployee(Employee employee);
    Employee? GetDetails(int id);
    List<Employee> GetEmployees();

    List<Employee> SearchEmployees(string? searchItem);
}
