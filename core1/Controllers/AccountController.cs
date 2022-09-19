using core1.Data;
using core1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace core1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private User RightUserName;
        private bool found; 
        public AccountController(AppDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            ViewBag.users = users;
            return View();
        }

        
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginCheck(User user)
        {
            foreach (User user2 in _context.Users)
            {
                if(user2.UserName == user.UserName)
                {
                    RightUserName = user2;
                    found = true; 
                    break; 
                }
                else
                {
                    found = false;
                }
            }
            if (found == true)
            {
                if (RightUserName.Password == user.Password)
                {
                    return RedirectToAction("Index", "Challenge"); 
                }
                else
                {
                    return RedirectToAction("Login"); 
                }
            }
            else
            {
                return RedirectToAction("Login"); 
            }

            return Ok(); 
        }
        
        public IActionResult SignUp(string Username)
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult SignUpPost(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges(); 
            return RedirectToAction("Login");
        }

    }
}
