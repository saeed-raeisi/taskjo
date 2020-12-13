using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using taskjo.Models;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }




        public System.Data.Entity.DbSet<taskjo.Models.BackLog> backLogs { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.BlogPost> BlogPost { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.CateSkill> CateSkills { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.Friend> Friends { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.Importance> importances { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.Phase> Phases { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.Project> Project { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.Skills> Skills { get; set; }
        //public System.Data.Entity.DbSet<taskjo.Models.SprintBackLog> sprintBackLogs { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.State> states { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.SubTask> SubTasks { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.Task> Tasks { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.Team> Team { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.TeamMembers> TeamMembers { get; set; }
        //public System.Data.Entity.DbSet<taskjo.Models.TodoList> TodoLists { get; set; }
        public System.Data.Entity.DbSet<taskjo.Models.Users> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{


        //    // modelBuilder.Entity<Team>().Has
        //    //   .HasOne<TeamMembers>(s => s.)
        //    //.WithOne(ad => ad.Student)



        //}
    }
}