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
    public class UserSubTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserSubTasks
        public async Task<ActionResult> Index()
        {
            var subTasks = db.SubTasks.Include(s => s.task);
            return View(await subTasks.ToListAsync());
        }

        // GET: UserSubTasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = await db.SubTasks.FindAsync(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View(subTask);
        }

        // GET: UserSubTasks/Create
        public ActionResult Create(int id)
        {
            ViewBag.taskId = id;
            return View();
        }

        // POST: UserSubTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "subtaskId,subTaskName,subTascDesc,subTaskState,is_active,taskId,username")] SubTask subTask, int taskId)
        {
            subTask.taskId = taskId;
            if (ModelState.IsValid)
            {
                db.SubTasks.Add(subTask);
                await db.SaveChangesAsync();
                return RedirectToAction("ShowSubTask", "UserDashboard", new { id = taskId });
            }

            ViewBag.taskId = taskId;
            return View(subTask);
        }

        // GET: UserSubTasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = await db.SubTasks.FindAsync(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.taskId = new SelectList(db.Tasks, "taskId", "taskName", subTask.taskId);
            return View(subTask);
        }

        // POST: UserSubTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "subtaskId,subTaskName,subTascDesc,subTaskState,is_active,taskId,username")] SubTask subTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.taskId = new SelectList(db.Tasks, "taskId", "taskName", subTask.taskId);
            return View(subTask);
        }

        // GET: UserSubTasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = await db.SubTasks.FindAsync(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View(subTask);
        }

        // POST: UserSubTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubTask subTask = await db.SubTasks.FindAsync(id);
            db.SubTasks.Remove(subTask);
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
