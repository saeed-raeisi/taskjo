using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using taskjo.Models;

namespace taskjo.Controllers
{
    public class ManagerPhasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManagerPhases
        public async Task<ActionResult> Index()
        {
            return View(await db.Phases.ToListAsync());
        }

        // GET: ManagerPhases/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Phase phase = await db.Phases.FindAsync(id);
            //Tasks tasks = db.Tasks.Where(p => p.phase.phaseId == id).FirstOrDefault();
            //if (phase == null)
            //{
            //    return HttpNotFound();
            //}
            //phase
            return View(await db.Tasks.Where(p => p.phase.phaseId == id).ToListAsync());
        }

        // GET: ManagerPhases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerPhases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "phaseId,phaseTitle,phaseState")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                db.Phases.Add(phase);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(phase);
        }

        // GET: ManagerPhases/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = await db.Phases.FindAsync(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            return View(phase);
        }

        // POST: ManagerPhases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "phaseId,phaseTitle,phaseState")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phase).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(phase);
        }

        // GET: ManagerPhases/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = await db.Phases.FindAsync(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            return View(phase);
        }

        // POST: ManagerPhases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Phase phase = await db.Phases.FindAsync(id);
            db.Phases.Remove(phase);
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
