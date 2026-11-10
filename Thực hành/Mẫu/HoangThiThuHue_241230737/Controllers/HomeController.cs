using System.Diagnostics;
using HoangThiThuHue_241230737.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using HoangThiThuHue_241230737.Models;
namespace HoangThiThuHue_241230737.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLHangHoaContext _db;
        public HomeController(QLHangHoaContext db)
        {
            _db = db;
        }
        private readonly ILogger<HomeController> _logger;
        public IActionResult Index()
        {
            var ds = _db.HangHoas.Where(h => h.Gia > 100).ToList();
            return View(ds);
        }
        public IActionResult LocTheoLoai(int id)
        {
            var ds = _db.HangHoas.Where(h => h.MaLoai == id).ToList();
            ViewData["TieuDe"] = "New Products";
            return PartialView("HoangThiThuHue_Main", ds);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DsLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public IActionResult Create(HangHoa model)
        {
            ModelState.Remove("MaLoaiNavigation");
            if (ModelState.IsValid)
            {
                _db.HangHoas.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.DsLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai", model.MaLoai);
            return View(model);
        }
    }
}
