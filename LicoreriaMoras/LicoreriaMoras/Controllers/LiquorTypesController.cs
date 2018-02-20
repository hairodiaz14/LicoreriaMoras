using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LicoreriaMoras.Models;

namespace LicoreriaMoras.Controllers
{
    public class LiquorTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LiquorTypes
        public ActionResult Index()
        {
            return View(db.LiquorTypes.ToList());
        }

        // GET: LiquorTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquorType liquorType = db.LiquorTypes.Find(id);
            if (liquorType == null)
            {
                return HttpNotFound();
            }
            return View(liquorType);
        }

        // GET: LiquorTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LiquorTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_liquorType,Descripcion")] LiquorType liquorType)
        {
            if (ModelState.IsValid)
            {
                db.LiquorTypes.Add(liquorType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(liquorType);
        }

        // GET: LiquorTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquorType liquorType = db.LiquorTypes.Find(id);
            if (liquorType == null)
            {
                return HttpNotFound();
            }
            return View(liquorType);
        }

        // POST: LiquorTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_liquorType,Descripcion")] LiquorType liquorType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liquorType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liquorType);
        }

        // GET: LiquorTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquorType liquorType = db.LiquorTypes.Find(id);
            if (liquorType == null)
            {
                return HttpNotFound();
            }
            return View(liquorType);
        }

        // POST: LiquorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LiquorType liquorType = db.LiquorTypes.Find(id);
            db.LiquorTypes.Remove(liquorType);
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
