using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcoraEmployeeManagement.Models;

namespace AcoraEmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private ACORAEntities db = new ACORAEntities();

        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }



        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }



        // GET: Employees/Create
        public ActionResult Create()
        {
            List<Department> DepartmentList = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(DepartmentList, "Name", "Name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM employee)
        {
            List<Department> DepartmentList = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(DepartmentList, "Name", "Name");
            return View();

            int age = get_age(Convert.ToDateTime(employee.DateOfBirth));
            if (age < 18 || age > 65)
            {
                var msg = "Employee age must be between 18 and 65";
                TempData["ErrorMessage"] = msg;
                return View(employee);
            }
            if (string.IsNullOrEmpty(employee.Department))
            {
                var msg = "Please select a department to continue";
                TempData["ErrorMessage"] = msg;
                return View(employee);
            }
            if (ModelState.IsValid)
            {
                Employee emp = new Employee();
                
                emp.EmployeeNumber = employee.EmployeeNumber;
                emp.DateOfBirth = employee.DateOfBirth;
                emp.Department = employee.Department;
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Address = employee.Address;
                emp.City = employee.City;

                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }





        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            List<Department> DepartmentList = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(DepartmentList, "Name", "Name");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee user, EmployeeVM employee)
        {
            List<Department> DepartmentList = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(DepartmentList, "Name", "Name");

            int age = get_age(Convert.ToDateTime(employee.DateOfBirth));
            if (age < 18 || age > 65)
            {
                var msg = "Employee age must be between 18 and 65";
                TempData["ErrorMessage"] = msg;
                return View(user);
            }

            if (string.IsNullOrEmpty(employee.Department))
            {
                var msg = "Please select a department to continue";
                TempData["ErrorMessage"] = msg;
                return View(user);
            }
            if (ModelState.IsValid)
            {
                Employee emp = db.Employees.Find(employee.Id);
                if (emp == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    emp.EmployeeNumber = employee.EmployeeNumber;
                    emp.DateOfBirth = employee.DateOfBirth;
                    emp.Department = employee.Department;
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.Address = employee.Address;
                    emp.City = employee.City;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        //Function to calculate age of rmployee
        public int get_age(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }





    }
}