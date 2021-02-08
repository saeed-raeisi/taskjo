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
        // Init Db
        private ApplicationDbContext db = new ApplicationDbContext();

        // Log Console 
        public void DebugLog(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }

        // 404 error page
        public ActionResult E404()
        {
            return View();
        }

        public ActionResult getUserId()
        {
            return Content(User.Identity.GetUserId());
        }

        public ActionResult getMyUserId(string id)
        {
            var userId = db.MyUsers.Where(u=>u.UserId==id).Select(u=>new { u.myUserId }).Single();
            return Content(userId.myUserId.ToString());
        }
        public ActionResult getName(string id)
        {
            var userId = User.Identity.GetUserId();
            var name = db.MyUsers.Where(u => u.UserId == id).Select(u => new {
                u.fname,
                u.lname
            }).Single();
            
            return Content(name.fname + " " + name.lname);
        }
        // GET: UserDashboard
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var list = db.Team.Join(db.TeamMembers.Where(c => c.UserId == userId), u => u.teamId, x => x.teamId, (u, x) => u).ToList();
            int sumProject = 0;
            foreach (var item in list)
            {
                sumProject += db.Project.Where(u => u.teamId == item.teamId).Count();
            }

            ViewBag.userId = userId;
            ViewBag.data = list;

            var name = db.MyUsers.Where(u => u.UserId == userId).Select(u => new { u.fname, u.lname }).Single();
            ViewBag.name = name.fname + " " + name.lname;
            // TODO logo 
            ViewBag.logo = "s.png";
            ViewBag.teamCount = list.Count() ;
            ViewBag.projectCount = sumProject;
            ViewBag.friendCount = db.Friends.Where(u=>u.userId==userId).Count();

            return View();
        }

        // Show Teams View by user Id 
        public ActionResult showTeams()
        {
            var userId = User.Identity.GetUserId();
            var list = db.Team.Join(db.TeamMembers.Where(c => c.UserId == userId), u => u.teamId, x => x.teamId, (u, x) => u).ToList();
            return PartialView(list);
        }

        // Show Project View 
        public ActionResult ShowProject(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("E404", "UserDashboard");
            }
            var userId = User.Identity.GetUserId();
            ViewBag.teamId = id;
            ViewBag.userId = userId;

            var name = db.MyUsers.Where(u=>u.UserId==userId).Select(u => new {
                u.fname , u.lname}).Single();
            ViewBag.user = name.fname+ " " + name.lname;

            var role = db.TeamMembers.Where(u => u.teamId == id && u.UserId == userId).Select(u=>new{u.memberRole}).Single();
            ViewBag.role = role.memberRole;

            var teamName = db.Team.Where(u => u.teamId == id).Select(u =>new { u.teamName }).Single();
            ViewBag.team = teamName.teamName;

            ViewBag.all_project = db.Project.Where(u => u.teamId == id).Count();
            ViewBag.done_project = db.Project.Where(u => u.teamId == id && u.projectSate=="1").Count();

            // team logo
            // if role == admin  edit and delte team 

            return View();
        }

        // Get Project by team Id --Partial View
        public ActionResult GetProject(int? id)
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Models.Project> listdata = db.Project.ToList().Where(u => u.teamId == id);
            ViewBag.data = listdata;
            ViewBag.userId = userId;

            ViewBag.name = "alireza";
            ViewBag.logo = "s.png";

            return PartialView(listdata);
        }

        // Show Phase View 
        public ActionResult ShowPhase(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("E404", "UserDashboard");
            }
            ViewBag.projectId = id;

            var userId = User.Identity.GetUserId();
            var teamId = db.Project.Where(u => u.projectId == id).Select(u => new { u.teamId,u.projectName,u.projectdate }).Single();
            var team = db.Team.Where(u => u.teamId == teamId.teamId).Select(u => new { u.teamName }).Single();

            ViewBag.project = teamId.projectName;
            ViewBag.team = team.teamName;
            ViewBag.teamId = teamId.teamId;
            ViewBag.date = teamId.projectdate;


            // role 
            var role = db.TeamMembers.Where(u => u.teamId == teamId.teamId && u.UserId == userId).Select(u => new { u.memberRole }).Single();
            ViewBag.role = role.memberRole;
            // phase detail 
            ViewBag.all_phase = db.Phases.Where(u => u.projectId == id).Count();
            ViewBag.done_phase = db.Phases.Where(u => u.projectId == id && u.phaseState == "1").Count();


            return View();
        }

        // Get Phase by project Id --Partial View
        public ActionResult GetPhase(int? id )
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Models.Phase> listdata = db.Phases.ToList().Where(u => u.projectId == id);
            ViewBag.userId = userId;
            List<int> percent = new List<int>();
            // count all task done and get percent 
            foreach (var item in listdata)
            {
                var all_task = db.Tasks.Count(u => u.phaseId == item.phaseId).ToString();
                var done_task = db.Tasks.Count(u => u.phaseId == item.phaseId && u.taskState == "1").ToString();
                try
                {
                    percent.Add(Int32.Parse(done_task) * 100 / Int32.Parse(all_task));
                }
                catch (Exception)
                {
                    percent.Add(0);
                }
            }

            ViewBag.percent = percent;

            return PartialView(listdata);
        }

        // Show Task View 
        public ActionResult ShowTask(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("E404", "UserDashboard");
            }
            ViewBag.phaseId = id;


            // phase 
            var phaseId = db.Phases.Where(u => u.phaseId == id).Select(u => new { u.projectId, u.phaseTitle,u.phaseState }).Single();
            var proejct = db.Project.Where(u => u.projectId == phaseId.projectId).Select(u => new { u.projectName }).Single();

            ViewBag.title = phaseId.phaseTitle;
            ViewBag.proejct = proejct.projectName;
            ViewBag.state = phaseId.phaseState;

            ViewBag.all_task = db.Tasks.Where(u => u.phaseId == id).Count();
            ViewBag.done_task = db.Tasks.Where(u => u.phaseId == id && u.taskState == "1").Count();

            return View();
        }

        // Get Task by Phase Id --Partial View
        public ActionResult GetTask(int? id)
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Models.Tasks> listdata = db.Tasks.ToList().Where(u => u.phaseId == id);


            List<int> percent = new List<int>();
            // count all task done and get percent 
            foreach (var item in listdata)
            {
                var all_task = db.SubTasks.Count(u => u.taskId == item.taskId).ToString();
                var done_task = db.SubTasks.Count(u => u.taskId == item.taskId && u.subTaskState == "1").ToString();
                try
                {
                    percent.Add(Int32.Parse(done_task) * 100 / Int32.Parse(all_task));
                }
                catch (Exception)
                {
                    percent.Add(0);
                }
            }

            ViewBag.percent = percent;

            return PartialView(listdata);
        }

        // Show SubTask View 
        public ActionResult ShowSubTask(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("E404", "UserDashboard");
            }
            ViewBag.taskId = id;

            // task
            var taskId = db.Tasks.Where(u => u.taskId == id).Select(u => new { u.taskName, u.taskState,u.phaseId }).Single();
            var phase = db.Phases.Where(u => u.phaseId == taskId.phaseId).Select(u => new { u.phaseTitle }).Single();

            ViewBag.title = taskId.taskName;
            ViewBag.phase = phase.phaseTitle;
            ViewBag.state = taskId.taskState;

            ViewBag.all_subTask = db.SubTasks.Where(u => u.taskId == id).Count();
            ViewBag.done_subTask = db.SubTasks.Where(u => u.taskId == id && u.subTaskState == "1").Count();
            return View();
        }

        // Get SubTask by Task Id --Partial View
        public ActionResult GetSubTask(int? id)
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Models.SubTask> listdata = db.SubTasks.ToList().Where(u => u.taskId == id);
            ViewBag.userId = userId;

            return PartialView(listdata);
        }
    }

}