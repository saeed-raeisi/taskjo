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
    public class ManagerTeamMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManagerTeamMembers
        public async Task<ActionResult> Index()
        {
            var teamMembers = db.TeamMembers.Include(t => t.user);
            return View(await teamMembers.ToListAsync());
        }

        // GET: ManagerTeamMembers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMembers teamMembers = await db.TeamMembers.FindAsync(id);
            if (teamMembers == null)
            {
                return HttpNotFound();
            }
            return View(teamMembers);
        }

        // GET: ManagerTeamMembers/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.User, "userId", "userName");
            return View();
        }

        // POST: ManagerTeamMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "teamMemberId,userId,memberRule")] TeamMembers teamMembers)
        {
            if (ModelState.IsValid)
            {
                db.TeamMembers.Add(teamMembers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.User, "userId", "userName", teamMembers.userId);
            return View(teamMembers);
        }

        // GET: ManagerTeamMembers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMembers teamMembers = await db.TeamMembers.FindAsync(id);
            if (teamMembers == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.User, "userId", "userName", teamMembers.userId);
            return View(teamMembers);
        }

        // POST: ManagerTeamMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "teamMemberId,userId,memberRule")] TeamMembers teamMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamMembers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.User, "userId", "userName", teamMembers.userId);
            return View(teamMembers);
        }

        // GET: ManagerTeamMembers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMembers teamMembers = await db.TeamMembers.FindAsync(id);
            if (teamMembers == null)
            {
                return HttpNotFound();
            }
            return View(teamMembers);
        }

        // POST: ManagerTeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TeamMembers teamMembers = await db.TeamMembers.FindAsync(id);
            db.TeamMembers.Remove(teamMembers);
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
