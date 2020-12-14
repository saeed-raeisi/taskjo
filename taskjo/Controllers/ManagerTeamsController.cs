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
using System.IO;

namespace taskjo.Controllers
{
    public class ManagerTeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManagerTeams
        public async Task<ActionResult> Index()
        {
            return View(await db.Team.ToListAsync());
        }

        // GET: ManagerTeams/Details/5
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

        // GET: ManagerTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "teamId,teamAdmin,teamName,teamDesc,teamStartDate,teamLogo,enChar")] Team team, HttpPostedFileBase uploadLogo)
        {

            //System.Diagnostics.Debug.WriteLine(""+team.teamLogo+uploadLogo.FileName);

            if (ModelState.IsValid)
            {
                //System.Diagnostics.Debug.WriteLine("salam ali");
                //team.teamStartDate = DateTime.Now;
                if (uploadLogo != null)
                {
                    team.teamLogo = Guid.NewGuid() + Path.GetExtension(uploadLogo.FileName);
                    uploadLogo.SaveAs(Server.MapPath("/ImgLogo/" + team.teamLogo));
                }
                db.Team.Add(team);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: ManagerTeams/Edit/5
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

        // POST: ManagerTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "teamId,teamAdmin,teamName,teamDesc,teamStartDate,teamLogo,enChar")] Team team, HttpPostedFile UploadLogo)
        {
            if (ModelState.IsValid)
            {
                team.teamStartDate = DateTime.Now;
                if (UploadLogo != null)
                {
                    if (team.teamLogo != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/ImgLogo/" + team.teamLogo));
                    }
                    team.teamLogo = Guid.NewGuid() + Path.GetExtension(UploadLogo.FileName);
                    UploadLogo.SaveAs(Server.MapPath("/ImgLogo/" + team.teamLogo));
                }
                db.Entry(team).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: ManagerTeams/Delete/5
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

        // POST: ManagerTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Team team = await db.Team.FindAsync(id);
            db.Team.Remove(team);
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
