using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RNTA2.Models;

namespace RNTA2.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private RNTAEntities db = new RNTAEntities();

        // GET: Employees

       /* public ActionResult Index()
        {
            var employee = db.Employee.Include(e => e.Department);
            return View(employee.ToList());
        }*/

        public ActionResult Index(string search)
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DeptId", "DepartmentName");
            List<Employee> listEmp = db.Employee.ToList();

            return View(db.Employee.Where(x=>x.Name.StartsWith(search)||search==null).ToList());
        }
        [HttpPost]
        public ActionResult Index(int DepartmentId)
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DeptId", "DepartmentName");
            var employee = db.Employee.Include(e => e.Department).Where(a=>a.DepartmentId==DepartmentId);
            return View(employee.ToList());

        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Roles ="admin, infirmier")]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DeptId", "DepartmentName");
            return View();
        }

        // POST: Employees/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, infirmier")]
        public ActionResult Create([Bind(Include = "EmpId,Name,Gender,Age,Position,Office,HireDate,Salary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Department, "DeptId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DeptId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "EmpId,Name,Gender,Age,Position,Office,HireDate,Salary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DeptId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
