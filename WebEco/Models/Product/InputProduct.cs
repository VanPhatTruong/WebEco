using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebEco.Models.Product
{
    public class InputProduct
    {
        
        public string? TenSanPham { get; set; }
        public string? Mota { get; set; }
        public decimal? Gia { get; set; }
        public IFormFile hinhanh { get; set; }
    }
}
