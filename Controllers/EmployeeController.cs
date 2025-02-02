using mvc_frame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mvc_frame.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeD
        public ViewResult GetAllEmployee()
        {
            EmployeeModelManger modelManager = new EmployeeModelManger();
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
            EmployeeModelManger modelManager = new EmployeeModelManger();
            int insertedRow = modelManager.Create(employee);
            if (insertedRow > 0)
            {
                return RedirectToAction("GetAllEmployee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            EmployeeModelManger modelManager = new EmployeeModelManger();
            Employee employee = modelManager.GetEmployeebyId(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            EmployeeModelManger modelManager = new EmployeeModelManger();
            int UpdatedRow = modelManager.Update(employee);

            if (UpdatedRow > 0)
            {
                return RedirectToAction("GetAllEmployee");
            }
            return View(employee);
        }
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeModelManger modelManager = new EmployeeModelManger();
            int DeletedRow = modelManager.Delete(id);
            if (DeletedRow > 0)
            {
                return RedirectToAction("GetAllEmployee");
            }
            return View();
        }
    }
}
