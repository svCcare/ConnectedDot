using ConnectedDot.Models;
using ConnectedDot.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace ConnectedDot.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddSkill()
        {
            var viewModel = new SkillFormViewModel
            {
                Categories = db.Categories.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkill(SkillFormViewModel viewModel)
        {
            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());

            var skill = new Skill
            {
                UserId = User.Identity.GetUserId(),

                UserName = currentUser.FirstName + " " + currentUser.LastName,
                Name = viewModel.Name,
                CategoryId = viewModel.Category,

                isKnown = viewModel.isKnown,
                Level = viewModel.Level,
                Notes = viewModel.Notes
            };

            db.Skills.Add(skill);
            db.SaveChanges();

            if(skill.isKnown)
            {
                return RedirectToAction("Actual", "Home");
            } else return RedirectToAction("Future", "Home");

        }

        [Authorize]
        public ActionResult Actual()
        {
            var userId = User.Identity.GetUserId();

            var listOfSkills = db.Skills
                .Where(s => s.UserId == userId && s.isKnown == true);
                

            var viewModel = new SkillsViewModel
            {
                ListOfSkills = listOfSkills,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View("Actual", viewModel);
        }

        [Authorize]
        public ActionResult Future()
        {
            var userId = User.Identity.GetUserId();

            var listOfSkills = db.Skills.Where(s => s.UserId == userId && s.isKnown == false);


            var viewModel = new SkillsViewModel
            {
                ListOfSkills = listOfSkills,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View("Future", viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}