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
    public class UserPhasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserPhases
        public async Task<ActionResult> Index()
        {
            var phases = db.Phases.Include(p => p.project);
            return View(await phases.ToListAsync());
        }

        // GET: UserPhases/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: UserPhases/Create
        public ActionResult Create(int id)
        {
            ViewBag.projectId = id;
            return View();
        }

        // POST: UserPhases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "phaseId,phaseTitle,phaseState,projectId")] Phase phase, int projectId)
        {
            phase.projectId = projectId;
            //System.Diagnostics.Debug.WriteLine(phase.phaseState);
            if (ModelState.IsValid)
            {
                db.Phases.Add(phase);
                await db.SaveChangesAsync();
                return RedirectToAction("ShowPhase", "UserDashboard", new { id = projectId });
            }

            ViewBag.projectId = phase.projectId;
            return View(phase);
        }

        // GET: UserPhases/Edit/5
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
            ViewBag.projectId = new SelectList(db.Project, "projectId", "projectName", phase.projectId);
            return View(phase);
        }

        // POST: UserPhases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "phaseId,phaseTitle,phaseState,projectId")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phase).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.projectId = new SelectList(db.Project, "projectId", "projectName", phase.projectId);
            return View(phase);
        }

        // GET: UserPhases/Delete/5
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

        // POST: UserPhases/Delete/5
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
