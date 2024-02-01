using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEco.Cammon;
using WebEco.Models.Entity;

namespace WebEco.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]//đường dẫn đến trang.../admin/...(vd:danh-sach;CapNhat;Xoa,..)
    public class HomeController : Controller
    {
        private readonly TruongVanPhatContext _context;
        public HomeController(TruongVanPhatContext context)
        {
            _context = context;
        }
        [Route("danh-sach")]
        public IActionResult Index(string timkiem)
        {
			//var items = _context.Products.ToList();
			//return View(items);
			if (string.IsNullOrWhiteSpace(timkiem))
			{
				var items1 = _context.Products.ToList();
				return View(items1);
			}
			else
			{
				var items2 = _context.Products.Where(c => c.Filter.Contains(timkiem)).ToList();
				return View(items2);
			}
			//return View();
        }
        [Route("Them")]
        public IActionResult Them()
        {
            return View();
        }
        [Route("Them")]
        [HttpPost]
        public IActionResult Them(string tensanpham, string mota, decimal gia, IFormFile hinhanh)
        {

            //Guid id = Guid.NewGuid();
            if (!string.IsNullOrEmpty(tensanpham))
            {
                Product product = new Product();
                product.Id = Guid.NewGuid().ToString();
                product.TenSanPham = tensanpham;
                product.Mota = mota;
                product.Gia = gia;
                product.Filter = tensanpham.ToLower() + " " + tensanpham.ToUpper() + " " + mota.ToLower() + " " + mota.ToUpper() + " " + Utility.ConvertToUnsign(tensanpham.ToLower());
                product.UrlImage = UploadFiles.SaveImage(hinhanh);
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("CapNhat")]//có thể đổi tên khác tùy mục đích
        public IActionResult Capnhat(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(item);
        }
        [Route("CapNhat")]
        [HttpPost]
        public IActionResult Capnhat(string id, string tensanpham, string mota, decimal gia, IFormFile hinhanh)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            item.TenSanPham = tensanpham;
            item.Mota = mota;
            item.Gia = gia;
            item.UrlImage = UploadFiles.SaveImage(hinhanh);
            _context.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("Xoa")]
        public IActionResult Xoa(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
