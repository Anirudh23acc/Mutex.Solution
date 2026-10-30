using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mutex.DataLayer.Models;

public class Employee
{
    [Key]
    public int EmpId { get; set; }

    public string EmpName { get; set; }

    public int EmpAge { get; set; }

    public string EmpDept { get; set; }

    public string EmpDesignation { get; set; }

    public decimal EmpSalary { get; set; }
}
