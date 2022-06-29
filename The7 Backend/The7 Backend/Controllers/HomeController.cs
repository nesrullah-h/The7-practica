using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using The7_Backend.DAL;
using The7_Backend.Models;
using The7_Backend.View_Models;

namespace The7_Backend.Controllers
{
   
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homevm = new HomeVM();
            homevm.intro = _context.Intros.FirstOrDefault();
            homevm.service = _context.Services.ToList();
            homevm.blogs = _context.Blogs.ToList();
            homevm.teams=_context.Teams.ToList();
            return View(homevm);
        }
    }
}