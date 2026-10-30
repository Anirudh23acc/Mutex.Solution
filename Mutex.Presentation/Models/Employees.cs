using System.ComponentModel.DataAnnotations;

namespace Mutex.Presentation.Models;

public class Employees
{
    public int EmpId { get; set; }

    [Required]
    public string EmpName { get; set; }

    [Required]
    public int EmpAge { get; set; }

    [Required]
    public string EmpDept { get; set; }

    [Required]
    public string EmpDesignation { get; set; }

    [Required]
    public decimal EmpSalary { get; set; }
}
