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
    public class AddressesController : Controller
    {
        private Student_DirectoryEntities db = new Student_DirectoryEntities();

        // GET: Addresses
        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.City).Include(a => a.County).Include(a => a.Postcode);
            return View(addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City");
            ViewBag.CountyID = new SelectList(db.Counties1, "CountyID", "County");
            ViewBag.PostcodeID = new SelectList(db.Postcodes1, "PostcodeID", "Postcode");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressID,BuildingNo,CityID,PostcodeID,CountyID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", address.CityID);
            ViewBag.CountyID = new SelectList(db.Counties1, "CountyID", "County", address.CountyID);
            ViewBag.PostcodeID = new SelectList(db.Postcodes1, "PostcodeID", "Postcode", address.PostcodeID);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", address.CityID);
            ViewBag.CountyID = new SelectList(db.Counties1, "CountyID", "County", address.CountyID);
            ViewBag.PostcodeID = new SelectList(db.Postcodes1, "PostcodeID", "Postcode", address.PostcodeID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressID,BuildingNo,CityID,PostcodeID,CountyID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", address.CityID);
            ViewBag.CountyID = new SelectList(db.Counties1, "CountyID", "County", address.CountyID);
            ViewBag.PostcodeID = new SelectList(db.Postcodes1, "PostcodeID", "Postcode", address.PostcodeID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
