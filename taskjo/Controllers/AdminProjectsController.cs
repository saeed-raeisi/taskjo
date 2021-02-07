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
    public class AdminProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminProjects
        public async Task<ActionResult> Index()
        {
            var project = db.Project.Include(p => p.teams);
            return View(await project.ToListAsync());
        }

        // GET: AdminProjects/Details/5
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

        // GET: AdminProjects/Create
        public ActionResult Create()
        {
            ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName");
            return View();
        }

        // POST: AdminProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "projectId,projectName,projectDesc,projectdate,projectSate,projectDocFile,teamId")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Project.Add(project);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName", project.teamId);
            return View(project);
        }

        // GET: AdminProjects/Edit/5
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

        // POST: AdminProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
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

        // GET: AdminProjects/Delete/5
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

        // POST: AdminProjects/Delete/5
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
