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
using Microsoft.AspNet.Identity;
using System.IO;

namespace taskjo.Controllers
{
    [Authorize]
    public class UserTeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public string Image_path = "/ImgLogo/";

        // GET: UserTeams
        public async Task<ActionResult> Index()
        {
            return View(await db.Team.ToListAsync());
        }

        // GET: UserTeams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Team.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: UserTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "teamId,teamName,teamDesc,teamStartDate,teamLogo")] Team team,
            HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                // Add in team member by team ID and UseID
                

                if (uploadImage != null)
                {
                    team.teamLogo = Guid.NewGuid() + Path.GetExtension(uploadImage.FileName);
                    uploadImage.SaveAs(Server.MapPath(Image_path + team.teamLogo));
                }

                // add logo and date 
                db.Team.Add(team);
                await db.SaveChangesAsync();
                // team member 
                var userId = User.Identity.GetUserId();
                TeamMembers t = new TeamMembers();
                t.teamId = team.teamId;
                t.UserId = userId;
                t.memberRole = "Admin";
                db.TeamMembers.Add(t);
                await db.SaveChangesAsync();

                return RedirectToAction("index", "UserDashboard");
            }

            return View(team);
        }

        // GET: UserTeams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Team.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: UserTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "teamId,teamName,teamDesc,teamStartDate,teamLogo")] Team team,
             HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    if (team.teamLogo != null)
                    {
                        System.IO.File.Delete(Server.MapPath(Image_path + team.teamLogo));
                    }
                    team.teamLogo = Guid.NewGuid() + Path.GetExtension(uploadImage.FileName);
                    uploadImage.SaveAs(Server.MapPath(Image_path + team.teamLogo));
                }

                db.Entry(team).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("index", "UserDashboard");
            }
            return View(team);
        }

        // GET: UserTeams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Team.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: UserTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            
            Team team = await db.Team.FindAsync(id);
            if (team.teamLogo != null)
            {
                System.IO.File.Delete(Server.MapPath(Image_path + team.teamLogo));
            }
            db.Team.Remove(team);
            await db.SaveChangesAsync();
            return RedirectToAction("index", "UserDashboard");
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
