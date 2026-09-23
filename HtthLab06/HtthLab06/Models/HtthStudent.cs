namespace HtthLab06.Models
{
    public class HtthStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public HtthBranch HtthBranch { get; set; }
        public HtthGender HtthGender { get; set; } 
        public bool IsRegular { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile? AvatarFile { get; set; }
        public string? AvatarUrl { get; set; }

    }
}
