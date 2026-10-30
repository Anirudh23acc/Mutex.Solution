using Microsoft.AspNetCore.Mvc;
using Mutex.DataLayer.Models;
using Mutex.Presentation.Models;
using Mutex.ServiceLayer.ServiceContracts;

namespace Mutex.Presentation.Controllers
{
    public class MutexController : Controller
    {
        private readonly IService _service;
        private readonly ILogger<MutexController> _logger;
        public MutexController(IService service,ILogger<MutexController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admins userDetail)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Errors = string.Join(",", ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
                return View(userDetail);
            }
            Admin admin = new Admin {UserName=userDetail.UserName,Password=userDetail.Password };
            bool success = _service.Authenticate(admin);
            if(success)
            {
                _logger.LogInformation("Admin authenticated successfully");
                return RedirectToAction("Create");
            }
            else
            {
                _logger.LogInformation("Admin authentication failed");
                ViewBag.Errors = "Invalid username or password";
                return View(userDetail);
            }
            
        }

        [HttpGet]
        public IActionResult Show()
        {
            List<Employee> employees = _service.GetEmployees();
            var model = employees.Select(x => new Employees {
               EmpId=x.EmpId,
               EmpName=x.EmpName
            }).ToList();
            return View(model);
        }   

        [HttpGet]
        public IActionResult MoreDetails(int id)
        {
            var employee = _service.GetDetails(id);
            if(employee==null)
            {
                ViewBag.Errors = "No Employee with the given id";
                return RedirectToAction("Show");
            }
            else
            {
                Employees model = new Employees
                {
                    EmpId = employee.EmpId,
                    EmpName = employee.EmpName,
                    EmpDesignation=employee.EmpDesignation,
                    EmpDept=employee.EmpDept,
                    EmpSalary=employee.EmpSalary,
                    EmpAge=employee.EmpAge
                };
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employees model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Errors = string.Join(",", ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
                return View(model);
            }
            Employee employee = new Employee { 
            EmpName=model.EmpName,
            EmpAge=model.EmpAge,
            EmpDept=model.EmpDept,
            EmpDesignation=model.EmpDesignation,
            EmpSalary=model.EmpSalary
            };
            bool success = _service.AddEmployee(employee);
            if(success)
            {
                return RedirectToAction("Show");
            }
            return View(model);
        }
    }
}
