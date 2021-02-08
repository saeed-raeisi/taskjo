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
    public class UserTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserTasks
        public async Task<ActionResult> Index()
        {
            var tasks = db.Tasks.Include(t => t.phase);
            return View(await tasks.ToListAsync());
        }

        // GET: UserTasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = await db.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: UserTasks/Create
        public ActionResult Create(int id)
        {
            ViewBag.phaseId = id;
            return View();
        }

        // POST: UserTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "taskId,taskName,taskDesc,taskState,phaseId")] Tasks tasks, int phaseId)
        {
            tasks.phaseId = phaseId;
            System.Diagnostics.Debug.WriteLine(tasks.taskState);
            if (ModelState.IsValid)
            {
                db.Tasks.Add(tasks);
                await db.SaveChangesAsync();
                return RedirectToAction("ShowTask", "UserDashboard", new { id = phaseId });
            }

            ViewBag.phaseId = phaseId;
            return View(tasks);
        }

        // GET: UserTasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = await db.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.phaseId = new SelectList(db.Phases, "phaseId", "phaseTitle", tasks.phaseId);
            return View(tasks);
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "taskId,taskName,taskDesc,taskState,phaseId")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasks).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.phaseId = new SelectList(db.Phases, "phaseId", "phaseTitle", tasks.phaseId);
            return View(tasks);
        }

        // GET: UserTasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = await db.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tasks tasks = await db.Tasks.FindAsync(id);
            db.Tasks.Remove(tasks);
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
