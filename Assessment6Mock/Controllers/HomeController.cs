using Assessment6Mock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assessment6Mock.Controllers
{
    public class HomeController : Controller
    {

        EmployeeDbEntities ORM = new EmployeeDbEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees()
        {
            List<Employee> employees = ORM.Employees.ToList();
            ViewBag.EmployeeList = ORM.Employees.ToList(); 
            return View(employees);
        }

        public ActionResult RetirementInfo(int Id)
        {
            Employee found = ORM.Employees.Find(Id);

            if(found.Age > 60)
            {
                ViewBag.CanRetire = true;
            }
            else
            {
                ViewBag.CanRetire = false;
            }

            ViewBag.Benefits = ((found.Salary * 6)/10).ToString("0,000.00");
            return View();
        }
    }
}