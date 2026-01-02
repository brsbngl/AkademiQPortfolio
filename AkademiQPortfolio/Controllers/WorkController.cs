using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult WorkList()
        {
            var context = _context.Works.ToList();
            return View(context);
        }
        [HttpGet]
        public IActionResult CreateWork()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateWork(Work wrk)
        {
            _context.Works.Add(wrk);
            _context.SaveChanges();
            return RedirectToAction("WorkList");
        }
        public IActionResult DeleteWork(int id)
        {
            var value = _context.Works.Find(id);
            if (value != null)
            {
                _context.Works.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("WorkList");
        }
        [HttpGet]
        public IActionResult UpdateWork(int id)
        {
            var value = _context.Works.Find(id);
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("WorkList");
        }
        [HttpPost]
        public IActionResult UpdateWork(Work work)
        {
            _context.Works.Update(work);
            _context.SaveChanges();
            return RedirectToAction("WorkList");

        }
    }
}