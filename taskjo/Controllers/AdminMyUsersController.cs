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
    public class AdminMyUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminMyUsers
        public async Task<ActionResult> Index()
        {
            var myUsers = db.MyUsers.Include(m => m.ApplicationUser);
            return View(await myUsers.ToListAsync());
        }

        // GET: AdminMyUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUsers myUsers = await db.MyUsers.FindAsync(id);
            if (myUsers == null)
            {
                return HttpNotFound();
            }
            return View(myUsers);
        }

        // GET: AdminMyUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: AdminMyUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "myUserId,fname,lname,mobile,birthdate,UserId")] MyUsers myUsers)
        {
            if (ModelState.IsValid)
            {
                db.MyUsers.Add(myUsers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", myUsers.UserId);
            return View(myUsers);
        }

        // GET: AdminMyUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUsers myUsers = await db.MyUsers.FindAsync(id);
            if (myUsers == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", myUsers.UserId);
            return View(myUsers);
        }

        // POST: AdminMyUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "myUserId,fname,lname,mobile,birthdate,UserId")] MyUsers myUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myUsers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", myUsers.UserId);
            return View(myUsers);
        }

        // GET: AdminMyUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUsers myUsers = await db.MyUsers.FindAsync(id);
            if (myUsers == null)
            {
                return HttpNotFound();
            }
            return View(myUsers);
        }

        // POST: AdminMyUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MyUsers myUsers = await db.MyUsers.FindAsync(id);
            db.MyUsers.Remove(myUsers);
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
