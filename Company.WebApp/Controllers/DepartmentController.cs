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
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //List of Departments
        public ActionResult Department()
        {
            List<Department> model = unitOfWork.Department.GetAll();
            return View(model);
        }

        //Details
        public ActionResult Details([FromRoute] int id)
        {
            Department model = unitOfWork.Department.FindByID(id);
            return View(model);
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromForm] Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            unitOfWork.Department.Add(department);
            unitOfWork.Commit();
            return View("Department", unitOfWork.Department.GetAll());
        }

        // Edit
        [HttpGet]
        public ActionResult Edit([FromRoute] int id)
        {
            Department model = unitOfWork.Department.FindByID(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit([FromRoute]int id,[FromForm] Department department)
        {
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Department.UpdateDepartment(id, department);
                    unitOfWork.Commit();
                    return View("Department", unitOfWork.Department.GetAll());
                }
                return View();
            }
        }

        //Delete
        public ActionResult Delete([FromRoute] int id)
        {
            unitOfWork.Department.Delete(unitOfWork.Department.FindByID(id));
            unitOfWork.Commit();
            return View("Department", unitOfWork.Department.GetAll());
        }
    }
}
