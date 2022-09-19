using core1.Data;
using core1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace core1.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly AppDbContext appDb;
        public ChallengeController(AppDbContext _appDb)
        {
            appDb = _appDb;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateChallenge(int Id)
        {
            return View(); 
        }
        public IActionResult Overzicht()
        {
            var challenges = appDb.Challenges.ToList();
            ViewBag.challenges = challenges;
            return View(); 
        }

        [HttpPost]
        public IActionResult ChallengePost(Challenge challenge)
        {
            appDb.Challenges.Add(challenge);
            appDb.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}
