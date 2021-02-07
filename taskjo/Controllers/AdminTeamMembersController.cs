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
    public class AdminTeamMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminTeamMembers
        public async Task<ActionResult> Index()
        {
            var teamMembers = db.TeamMembers.Include(t => t.ApplicationUser).Include(t => t.team);
            return View(await teamMembers.ToListAsync());
        }

        // GET: AdminTeamMembers/Details/5
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

        // GET: AdminTeamMembers/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName");
            return View();
        }

        // POST: AdminTeamMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "teamMemberId,teamId,memberRole,UserId")] TeamMembers teamMembers)
        {
            if (ModelState.IsValid)
            {
                db.TeamMembers.Add(teamMembers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", teamMembers.UserId);
            ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName", teamMembers.teamId);
            return View(teamMembers);
        }

        // GET: AdminTeamMembers/Edit/5
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
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", teamMembers.UserId);
            ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName", teamMembers.teamId);
            return View(teamMembers);
        }

        // POST: AdminTeamMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "teamMemberId,teamId,memberRole,UserId")] TeamMembers teamMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamMembers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", teamMembers.UserId);
            ViewBag.teamId = new SelectList(db.Team, "teamId", "teamName", teamMembers.teamId);
            return View(teamMembers);
        }

        // GET: AdminTeamMembers/Delete/5
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

        // POST: AdminTeamMembers/Delete/5
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
