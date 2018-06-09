using ConnectedDot.Models;
using ConnectedDot.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ConnectedDot.Controllers
{
    public class RankingController : Controller
    {

        private readonly ApplicationDbContext db;

        public RankingController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Ranking
        [Authorize]
        public ActionResult Index()
        {
            var viewModel = new SkillsViewModel
            {
                ListOfSkills = null
            };

            return View("Index", viewModel);
        }

        // POST: Ranking
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SkillsViewModel model)
        {

            var usersWithSkill = db.Skills.Where(s => s.Name == model.Name && s.Level >= model.Level).OrderByDescending(s => s.Level);


            var viewModel = new SkillsViewModel
            {
                ListOfSkills = usersWithSkill
            };

            return View("Index", viewModel);
        }
    }
}