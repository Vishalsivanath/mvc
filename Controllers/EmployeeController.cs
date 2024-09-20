using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employe.Models;

namespace Employe.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ViewResult GetAllEmployee()
        {
            EmployeeModelManager modelManager = new EmployeeModelManager();
            List<Employee> employees = modelManager.GetEmployees();
            List<Employee> employees1 = employees;
            return View(employees1);
        }
        [HttpGet]
        public ViewResult CreateEmploye()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public ActionResult CreateEmploye(Employee employee)
        {
            EmployeeModelManager modelManager = new EmployeeModelManager();
            int insertedRow = modelManager.Create(employee);
            if(insertedRow > 0)
            {
                return RedirectToAction("GetAllEmployee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            EmployeeModelManager modelManager = new EmployeeModelManager();
            Employee employee = modelManager.GetEmployeebyId(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            EmployeeModelManager modelManager = new EmployeeModelManager();
            int UpdatedRow = modelManager.Update(employee);

            if (UpdatedRow > 0)
            {
                return RedirectToAction("GetAllEmployee");
            }
            return View(employee);
        }
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeModelManager modelManager = new EmployeeModelManager();
            int DeletedRow = modelManager.Delete(id);
            if (DeletedRow > 0)
            {
                return RedirectToAction("GetAllEmployee");
            }
            return View();
        }
    }
}