using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDirectory.com;

namespace StudentDirectory.com.Controllers
{
    public class StudentTablesController : Controller
    {
        private Student_DirectoryEntities db = new Student_DirectoryEntities();

        // GET: StudentTables
        public ActionResult Index()
        {
            var studentTables = db.StudentTables.Include(s => s.Address).Include(s => s.Class).Include(s => s.Univeristytable);
            return View(studentTables.ToList());
        }

        // GET: StudentTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // GET: StudentTables/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "BuildingNo");
            ViewBag.ClassID = new SelectList(db.Classes1, "ClassID", "Class");
            ViewBag.ID = new SelectList(db.Univeristytables, "ID", "university");
            return View();
        }

        // POST: StudentTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Firstname,Lastname,DateOfBirth,AddressID,ID,ClassID")] StudentTable studentTable)
        {
            if (ModelState.IsValid)
            {
                db.StudentTables.Add(studentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "BuildingNo", studentTable.AddressID);
            ViewBag.ClassID = new SelectList(db.Classes1, "ClassID", "Class", studentTable.ClassID);
            ViewBag.ID = new SelectList(db.Univeristytables, "ID", "university", studentTable.ID);
            return View(studentTable);
        }

        // GET: StudentTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "BuildingNo", studentTable.AddressID);
            ViewBag.ClassID = new SelectList(db.Classes1, "ClassID", "Class", studentTable.ClassID);
            ViewBag.ID = new SelectList(db.Univeristytables, "ID", "university", studentTable.ID);
            return View(studentTable);
        }

        // POST: StudentTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Firstname,Lastname,DateOfBirth,AddressID,ID,ClassID")] StudentTable studentTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "BuildingNo", studentTable.AddressID);
            ViewBag.ClassID = new SelectList(db.Classes1, "ClassID", "Class", studentTable.ClassID);
            ViewBag.ID = new SelectList(db.Univeristytables, "ID", "university", studentTable.ID);
            return View(studentTable);
        }

        // GET: StudentTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // POST: StudentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentTable studentTable = db.StudentTables.Find(id);
            db.StudentTables.Remove(studentTable);
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
