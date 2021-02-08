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
    public class UserProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserProjects
        public async Task<ActionResult> Index()
        {
            var project = db.Project.Include(p => p.teams);
            return View(await project.ToListAsync());
        }

        // GET: UserProjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Project.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: UserProjects/Create
        public ActionResult Create(int id)
        {
            //ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName");
            ViewBag.teamId = id;

            return View();
        }

        // POST: UserProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "projectId,projectName,projectDesc,projectdate,projectSate,projectDocFile,teamId")] Project project,int teamId)
        {
            project.teamId = teamId;

            if (ModelState.IsValid)
            {
                db.Project.Add(project);
                await db.SaveChangesAsync();
                return RedirectToAction("ShowProject","UserDashboard",new { id = teamId});
            }

            //ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName", project.teamId);
            ViewBag.teamId = project.teamId;
            return View(project);
        }

        // GET: UserProjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Project.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName", project.teamId);
            return View(project);
        }

        // POST: UserProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "projectId,projectName,projectDesc,projectdate,projectSate,projectDocFile,teamId")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName", project.teamId);
            return View(project);
        }

        // GET: UserProjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Project.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: UserProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Project project = await db.Project.FindAsync(id);
            db.Project.Remove(project);
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
