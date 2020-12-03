using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Data.UnitOfWork;
using Company.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //List of Employees
        public ActionResult Employee()
        {
            List<Employee> model = unitOfWork.Employee.GetAll();
            return View(model);
        }

        //Details
        public ActionResult Details([FromRoute]int id)
        {
            Employee model = unitOfWork.Employee.FindByID(id);
            return View(model);
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromForm]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            unitOfWork.Employee.Add(employee);
            unitOfWork.Commit();
            return View("Employee", unitOfWork.Employee.GetAll());
        }

        // Edit
        [HttpGet]
        public ActionResult Edit([FromRoute]int id)
        {
            Employee model = unitOfWork.Employee.FindByID(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit([FromRoute]int id,[FromForm]Employee employee)
        {
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Employee.UpdateEmployee(id, employee);
                    unitOfWork.Commit();
                    return View("Employee", unitOfWork.Employee.GetAll());
                }
                return View();
            }
        }

        //Delete
        public ActionResult Delete([FromRoute]int id)
        {
            unitOfWork.Employee.Delete(unitOfWork.Employee.FindByID(id));
            unitOfWork.Commit();
            return View("Employee", unitOfWork.Employee.GetAll());
        }
    }
}
