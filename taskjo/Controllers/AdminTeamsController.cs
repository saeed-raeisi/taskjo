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
    public class AdminTeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public string Image_path = "/ImgLogo/";
        // GET: AdminTeams
        public async Task<ActionResult> Index()
        {
            return View(await db.Team.ToListAsync());
        }

        // GET: AdminTeams/Details/5
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

        // GET: AdminTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "teamId,teamName,teamDesc,teamStartDate,teamLogo")] Team team,
            HttpPostedFileBase uploadImage)
        {
            team.teamStartDate = DateTime.Now;
   
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    team.teamLogo = Guid.NewGuid() + Path.GetExtension(uploadImage.FileName);
                    uploadImage.SaveAs(Server.MapPath(Image_path + team.teamLogo));
                }
                db.Team.Add(team);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(team);
        }

        // GET: AdminTeams/Edit/5
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

        // POST: AdminTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
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
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: AdminTeams/Delete/5
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

        // POST: AdminTeams/Delete/5
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
