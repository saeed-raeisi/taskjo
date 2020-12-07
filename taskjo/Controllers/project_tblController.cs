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
    [Authorize]
    public class project_tblController : Controller

    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        // GET: project_tbl
        public async Task<ActionResult> Index()
        {
            var project_tbl = db.project_tbl.Include(p => p.group);
            return View(await project_tbl.ToListAsync());
        }

        // GET: project_tbl/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project_tbl project_tbl = await db.project_tbl.FindAsync(id);
            if (project_tbl == null)
            {
                return HttpNotFound();
            }
            return View(project_tbl);
        }

        // GET: project_tbl/Create
        public ActionResult Create()
        {
            ViewBag.groupId = new SelectList(db.group_tbl, "groupId", "groupName");
            return View();
        }

        // POST: project_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "projectId,projectAdmin,projectName,des,groupId")] project_tbl project_tbl)
        {
            if (ModelState.IsValid)
            {
                db.project_tbl.Add(project_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.groupId = new SelectList(db.group_tbl, "groupId", "groupName", project_tbl.groupId);
            return View(project_tbl);
        }

        // GET: project_tbl/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project_tbl project_tbl = await db.project_tbl.FindAsync(id);
            if (project_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.groupId = new SelectList(db.group_tbl, "groupId", "groupName", project_tbl.groupId);
            return View(project_tbl);
        }

        // POST: project_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "projectId,projectAdmin,projectName,des,groupId")] project_tbl project_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.groupId = new SelectList(db.group_tbl, "groupId", "groupName", project_tbl.groupId);
            return View(project_tbl);
        }

        // GET: project_tbl/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project_tbl project_tbl = await db.project_tbl.FindAsync(id);
            if (project_tbl == null)
            {
                return HttpNotFound();
            }
            return View(project_tbl);
        }

        // POST: project_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            project_tbl project_tbl = await db.project_tbl.FindAsync(id);
            db.project_tbl.Remove(project_tbl);
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
