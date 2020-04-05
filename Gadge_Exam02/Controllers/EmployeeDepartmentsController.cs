using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gadge_Exam02.DB;
using Gadge_Exam02.Models;

namespace Gadge_Exam02.Controllers
{
    public class EmployeeDepartmentsController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: EmployeeDepartments
        public ActionResult Index()
        {
            var employeeDepartments = db.EmployeeDepartments.Include(e => e.Department).Include(e => e.Employee);
            return View(employeeDepartments.ToList());
        }

        // GET: EmployeeDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDepartment employeeDepartment = db.EmployeeDepartments.Find(id);
            if (employeeDepartment == null)
            {
                return HttpNotFound();
            }
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            return View();
        }

        // POST: EmployeeDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeDepartmentID,DepartmentID,EmployeeID")] EmployeeDepartment employeeDepartment)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDepartments.Add(employeeDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employeeDepartment.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", employeeDepartment.EmployeeID);
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDepartment employeeDepartment = db.EmployeeDepartments.Find(id);
            if (employeeDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employeeDepartment.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", employeeDepartment.EmployeeID);
            return View(employeeDepartment);
        }

        // POST: EmployeeDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeDepartmentID,DepartmentID,EmployeeID")] EmployeeDepartment employeeDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employeeDepartment.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", employeeDepartment.EmployeeID);
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDepartment employeeDepartment = db.EmployeeDepartments.Find(id);
            if (employeeDepartment == null)
            {
                return HttpNotFound();
            }
            return View(employeeDepartment);
        }

        // POST: EmployeeDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDepartment employeeDepartment = db.EmployeeDepartments.Find(id);
            db.EmployeeDepartments.Remove(employeeDepartment);
            db.SaveChanges();
            return RedirectToAction("Index");
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
