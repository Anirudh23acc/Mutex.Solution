using Mutex.DataLayer.DataContracts;
using Mutex.DataLayer.Models;
using Mutex.ServiceLayer.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutex.ServiceLayer.Service;

public class Service : IService
{
    private readonly IRepository _repository;
    public Service(IRepository repository)
    {
        _repository = repository;
    }
    public bool AddEmployee(Employee employee)
    {
        return _repository.AddEmployee(employee);
    }

    public bool Authenticate(Admin admin)
    {
        return _repository.Authenticate(admin);
    }

    public Employee? GetDetails(int id)
    {
       return _repository.GetDetails(id);
    }

    public List<Employee> GetEmployees()
    {
        return _repository.GetEmployees();
    }

    public List<Employee> SearchEmployees(string? searchItem)
    {
        return _repository.SearchEmployees(searchItem);
    }
}
