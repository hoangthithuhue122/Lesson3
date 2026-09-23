using HtthLesson06.Models;
using Microsoft.AspNetCore.Mvc;

namespace HtthLesson06.Controllers
{
    public class HtthMemberController : Controller
    {
        //mock data  - HtthMember
        private static readonly List<HtthMember> _members = new List<HtthMember>()
        {
            new HtthMember 
            {

                HtthMemberId = Guid.NewGuid().ToString(),
                HtthUserName = "hoangthithuhue", 
                HtthPassword = "Password123!", 
                HtthFullName = "Hoàng Thị Thu Huế", 
                HtthEmail = "nva@example.com" },
            new HtthMember 
            {
                HtthMemberId = Guid.NewGuid().ToString(),
                HtthUserName = "tranthib", 
                HtthPassword = "Password123!", 
                HtthFullName = "Trần Thị B", 
                HtthEmail = "ttb@example.com" },
            new HtthMember 
            {
                HtthMemberId = Guid.NewGuid().ToString(),
                HtthUserName = "levanc", 
                HtthPassword = "Password123!", 
                HtthFullName = "Lê Văn C", 
                HtthEmail = "lvc@example.com" },
        };
        //Get: danh sach thanh vien
        public IActionResult HtthIndex()
        {
            return View(_members);
        }

        public IActionResult HtthCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HtthCreate(HtthMember htthMember)
        {
            htthMember.HtthMemberId = Guid.NewGuid().ToString();
            _members.Add(htthMember);
            return RedirectToAction("HtthIndex");
        }

        public IActionResult HtthEdit(string id)
        {
            var htthMember = _members.FirstOrDefault(x => x.HtthMemberId.Equals(id));
            return View(htthMember);
        }

        [HttpPost]
        public IActionResult HtthEdit(string id, HtthMember htthMember)
        {
            for (int i=0; i < _members.Count; i++)
            {
                if(_members[i].HtthMemberId == id)
                {
                    _members[i].HtthMemberId = htthMember.HtthMemberId;
                    _members[i].HtthUserName = htthMember.HtthUserName;
                    _members[i].HtthPassword = htthMember.HtthPassword;
                    _members[i].HtthFullName = htthMember.HtthFullName;
                    _members[i].HtthEmail = htthMember.HtthEmail;
                    break;
                }
            }
            return RedirectToAction("HtthIndex");
        }

        public IActionResult HtthGetDetail()
        {
            var htthMember = new HtthMember()
            {
                HtthMemberId = Guid.NewGuid().ToString(),
                HtthUserName = "Thuhue",
                HtthPassword = "123",
                HtthFullName = "Hoang Thi Thu Hue",
                HtthEmail = "hoangthuthuhue87@gmail.com"
            };
            return View(htthMember);
        }
    }
}
