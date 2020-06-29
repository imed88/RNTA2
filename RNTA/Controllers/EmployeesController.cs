using RNTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace RNTA.Controllers
{
    public class EmployeesController : Controller
    {
        private RNTAEntities entities = new RNTAEntities(); 
        // GET: Employees
        [Authorize(Roles ="Admin,Employee")]
        public ActionResult Index()
        {
            var employees = entities.Employee.Include(e =>e.Department);
            return View(employees.ToList());
        }

        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = entities.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(entities.Department, "DeptId", "DepartmentName");
            return View();
        }


        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,Name,Gender,Age,Position,Office,HireDate,Salary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                entities.Employee.Add(employee);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(entities.Department, "DeptId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        [Authorize(Roles = "Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = entities.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(entities.Department, "DeptId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,Name,Gender,Age,Position,Office,HireDate,Salary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                entities.Entry(employee).State = EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(entities.Department, "DeptId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = entities.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = entities.Employee.Find(id);
            entities.Employee.Remove(employee);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                entities.Dispose();
            }
            base.Dispose(disposing);
        }




    }
}