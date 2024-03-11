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
    public class UniveristyController : Controller
    {
        private Student_DirectoryEntities db = new Student_DirectoryEntities();

        // GET: Univeristy
        public ActionResult Index()
        {
            return View(db.Univeristytables.ToList());
        }

        // GET: Univeristy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Univeristytable univeristytable = db.Univeristytables.Find(id);
            if (univeristytable == null)
            {
                return HttpNotFound();
            }
            return View(univeristytable);
        }

        // GET: Univeristy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Univeristy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,university")] Univeristytable univeristytable)
        {
            if (ModelState.IsValid)
            {
                db.Univeristytables.Add(univeristytable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(univeristytable);
        }

        // GET: Univeristy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Univeristytable univeristytable = db.Univeristytables.Find(id);
            if (univeristytable == null)
            {
                return HttpNotFound();
            }
            return View(univeristytable);
        }

        // POST: Univeristy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,university")] Univeristytable univeristytable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(univeristytable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(univeristytable);
        }

        // GET: Univeristy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Univeristytable univeristytable = db.Univeristytables.Find(id);
            if (univeristytable == null)
            {
                return HttpNotFound();
            }
            return View(univeristytable);
        }

        // POST: Univeristy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Univeristytable univeristytable = db.Univeristytables.Find(id);
            db.Univeristytables.Remove(univeristytable);
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
