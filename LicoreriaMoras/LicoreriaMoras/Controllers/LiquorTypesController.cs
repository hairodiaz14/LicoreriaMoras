using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LicoreriaMoras.Models;

namespace LicoreriaMoras.Controllers
{
    public class LiquorTypesController : Controller
    {
        private LicoreriaMorasContext db = new LicoreriaMorasContext();

        // GET: LiquorTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.LiquorTypes.ToListAsync());
        }

        // GET: LiquorTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquorType liquorType = await db.LiquorTypes.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id_liquorType,Descripcion")] LiquorType liquorType)
        {
            if (ModelState.IsValid)
            {
                db.LiquorTypes.Add(liquorType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(liquorType);
        }

        // GET: LiquorTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquorType liquorType = await db.LiquorTypes.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id_liquorType,Descripcion")] LiquorType liquorType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liquorType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(liquorType);
        }

        // GET: LiquorTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquorType liquorType = await db.LiquorTypes.FindAsync(id);
            if (liquorType == null)
            {
                return HttpNotFound();
            }
            return View(liquorType);
        }

        // POST: LiquorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LiquorType liquorType = await db.LiquorTypes.FindAsync(id);
            db.LiquorTypes.Remove(liquorType);
            await db.SaveChangesAsync();
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
