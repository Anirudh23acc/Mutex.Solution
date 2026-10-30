using Microsoft.EntityFrameworkCore;
using Mutex.DataLayer.DataContracts;
using Mutex.DataLayer.ModelDbContext;
using Mutex.DataLayer.Models;

namespace Mutex.DataLayer.DataServices;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    public bool AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        return _context.SaveChanges() > 0;
    }

    public bool Authenticate(Admin admin)
    {
        return _context.Admins.Any(a=>a.UserName==admin.UserName && a.Password == admin.Password);
    }

    public Employee? GetDetails(int id)
    {
        return _context.Employees.FirstOrDefault(x=>x.EmpId== id);
    }

    public List<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }

    public List<Employee> SearchEmployees(string? searchItem)
    {
        if(string.IsNullOrEmpty(searchItem))
        {
            return _context.Employees.ToList();
        }

        searchItem = searchItem.Trim();

        return _context.Employees
        .Where(e =>
        EF.Functions.Like(e.EmpName, $"%{searchItem}%") ||
        EF.Functions.Like(e.EmpDept, $"%{searchItem}%") ||
        EF.Functions.Like(e.EmpDesignation, $"%{searchItem}%"))
    .ToList();
    }
}
