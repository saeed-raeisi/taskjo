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
    public class AdminCateSkillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminCateSkills
        public async Task<ActionResult> Index()
        {
            return View(await db.CateSkills.ToListAsync());
        }

        // GET: AdminCateSkills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CateSkill cateSkill = await db.CateSkills.FindAsync(id);
            if (cateSkill == null)
            {
                return HttpNotFound();
            }
            return View(cateSkill);
        }

        // GET: AdminCateSkills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCateSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cateskillId,cateSkillName")] CateSkill cateSkill)
        {
            if (ModelState.IsValid)
            {
                db.CateSkills.Add(cateSkill);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cateSkill);
        }

        // GET: AdminCateSkills/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CateSkill cateSkill = await db.CateSkills.FindAsync(id);
            if (cateSkill == null)
            {
                return HttpNotFound();
            }
            return View(cateSkill);
        }

        // POST: AdminCateSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cateskillId,cateSkillName")] CateSkill cateSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cateSkill).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cateSkill);
        }

        // GET: AdminCateSkills/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CateSkill cateSkill = await db.CateSkills.FindAsync(id);
            if (cateSkill == null)
            {
                return HttpNotFound();
            }
            return View(cateSkill);
        }

        // POST: AdminCateSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CateSkill cateSkill = await db.CateSkills.FindAsync(id);
            db.CateSkills.Remove(cateSkill);
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
