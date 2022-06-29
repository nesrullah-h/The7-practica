using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The7_Backend.DAL;
using The7_Backend.Models;

namespace The7_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private AppDbContext _context;
        public ServicesController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            List<Service> services = _context.Services.ToList();
            return View(services);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Service service = await _context.Services.FindAsync(id);
            if(service == null) return NotFound();
            return View(service);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Service service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Service newservice = new Service();
            newservice.Title = service.Title;
            newservice.Icon = service.Icon;
            newservice.Description = service.Description;
            await _context.Services.AddAsync(newservice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Update(int? id)
        {
            if (id == null) return NotFound();
            Service dbService =await _context.Services.FindAsync(id);
            if(dbService == null) return NotFound();
            return View(dbService);
        }
        [HttpPost]
        public async Task<IActionResult>Update(Service service,int? id)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            Service dbService=await _context.Services.FindAsync(id);
            if(dbService == null) return NotFound();
            dbService.Title = service.Title;
            dbService.Icon = service.Icon;
            dbService.Description = service.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
