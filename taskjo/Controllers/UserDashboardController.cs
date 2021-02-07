using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using taskjo.Models;

namespace taskjo.Controllers
{
    [Authorize]
    public class UserDashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void DebugLog(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }
        // GET: UserDashboard
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var list = db.Team.Join(db.TeamMembers.Where(c=>c.UserId==userId), u => u.teamId, x=>x.teamId,(u,x)=>u).ToList();

            ViewBag.userId = userId;
            ViewBag.data = list;

            ViewBag.name = "alireza";
            ViewBag.logo = "s.png";
            ViewBag.teamCount = "5";
            ViewBag.projectCount = "50";
            ViewBag.taskCount = "2";
            ViewBag.friendCount = "8";

            return View();
        }


        public ActionResult Getprogect(int? id)
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Models.Project> listdata = db.Project.ToList().Where(u => u.teamId == id);
            ViewBag.data = listdata;
            ViewBag.userId = userId;

            ViewBag.name = "alireza";
            ViewBag.logo = "s.png";

            return View();
        }

        public ActionResult Getphase(int? id)
        {
            var userId = User.Identity.GetUserId();
            //List<string> listdata = db.TeamMembers.Select(u => u.UserId = userId).ToList();
            IEnumerable<Models.Phase> listdata = db.Phases.ToList().Where(u => u.projectId == id);
            ViewBag.data = listdata;
            ViewBag.userId = userId;

            return View();
        }



        public ActionResult Gettask(int? id)
        {
            var userId = User.Identity.GetUserId();
            //List<string> listdata = db.TeamMembers.Select(u => u.UserId = userId).ToList();
            IEnumerable<Models.Tasks> listdata = db.Tasks.ToList().Where(u => u.taskId == id);
            ViewBag.data = listdata;
            ViewBag.userId = userId;

            return View();
        }



        public ActionResult Getsubtask(int? id)
        {
            var userId = User.Identity.GetUserId();
            //List<string> listdata = db.TeamMembers.Select(u => u.UserId = userId).ToList();
            IEnumerable<Models.SubTask> listdata = db.SubTasks.ToList().Where(u => u.taskId == id);
            ViewBag.data = listdata;
            ViewBag.userId = userId;

            return View();
        }

    }

}