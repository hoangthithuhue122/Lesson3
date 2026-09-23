using HtthLab06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using Microsoft.AspNetCore.Hosting; 
using System.IO; 
namespace HtthLab06.Controllers
{
    public class HtthStudentController : Controller
    {
        public static List<HtthStudent> ListStudents = new List<HtthStudent>()
        {
                new HtthStudent() { 
                    Id = 101, 
                    Name = "Hải Nam", 
                    HtthBranch = HtthBranch.IT,
                    HtthGender = HtthGender.Male, 
                    IsRegular=true,
                    Address = "A1-2018", 
                    Email = "nam@g.com" 
                },
                new HtthStudent() { 
                    Id = 102, 
                    Name = "Minh Tú",
                    HtthBranch = HtthBranch.BE,
                    HtthGender = HtthGender.Female, 
                    IsRegular=true,
                    Address = "A1-2019", 
                    Email = "tu@g.com"
                },
                new HtthStudent() { 
                    Id = 103, 
                    Name = "Hoàng Phong", 
                    HtthBranch = HtthBranch.CE,
                    HtthGender = HtthGender.Male, 
                    IsRegular=false,
                    Address = "A1-2020", 
                    Email = "phong@g.com" 
                },
                new HtthStudent() { 
                    Id = 104, 
                    Name = "Xuân Mai", 
                    HtthBranch = HtthBranch.EE,
                    HtthGender = HtthGender.Female, 
                    IsRegular = false,
                    Address = "A1-2021", 
                    Email = "mai@g.com" 
                }
        };
        
        private readonly IWebHostEnvironment _env;
        public HtthStudentController(IWebHostEnvironment env)
        {
            _env = env;
        }


        [Route("Admin/Student/List", Name = "Route_StudentList")]
        public IActionResult Index()
        {
            return View(ListStudents);
        }


        [HttpGet]
        [Route("Admin/Student/Add", Name = "Route_StudentAdd")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(HtthGender)).Cast<HtthGender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text = "CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        [Route("Admin/Student/Add", Name = "Route_StudentAdd")]
        public IActionResult Create(HtthStudent s)
        {
            s.Id = ListStudents.Last<HtthStudent>().Id + 1;
            if(s.AvatarFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(s.AvatarFile.FileName);
                string uploadFolder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                string filePath = Path.Combine(uploadFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    s.AvatarFile.CopyTo(fileStream);
                }
                s.AvatarUrl = "/images/" + fileName;
            }

            ListStudents.Add(s);
            return RedirectToAction("Index");
        }

    }
}
