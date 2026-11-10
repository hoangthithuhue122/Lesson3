using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace HoangThiThuHue_241230737.Models
{
    [ModelMetadataType(typeof(HangHoaMetadata))]

    public partial class HangHoa
    {
    }
    public class HangHoaMetadata
    {
        [Required(ErrorMessage ="Vui long nhan ten hang")]
        public string TenHang { get; set; }

        [Required(ErrorMessage ="Vui long nhap gia")]
        [Range(100, 5000, ErrorMessage ="Gia phai tu 100 den 5000")]
        public decimal? Gia { get; set; }

        [RegularExpression(@"^.+(jpg|png|tiff|gif)$", ErrorMessage ="Chi chap nhan file anh")]
        public string Anh { get; set; }
    }
}
