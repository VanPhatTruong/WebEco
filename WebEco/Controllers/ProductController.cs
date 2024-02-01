using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEco.Cammon;
using WebEco.Models.Entity;
using WebEco.Models.Product;

namespace WebEco.Controllers
{
    public class ProductController : Controller
    {
        private readonly TruongVanPhatContext _context;
        public ProductController(TruongVanPhatContext context)
        {
            _context = context;
        }

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
        }
        public IActionResult Them()// [get] hien thi va show thong tin
        {
            return View();
        }
        [HttpPost]//su ly thong tin(hung truyen du lieu)
        public IActionResult Them(InputProduct input)
        {
            //Guid id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Id = Guid.NewGuid().ToString();
                product.TenSanPham = input.TenSanPham;
                product.Mota = input.Mota;
                product.Gia = input.Gia;
                product.Filter = input.TenSanPham.ToLower() + " " + input.TenSanPham.ToUpper() + " " + input.Mota.ToLower() + " " + input.Mota.ToUpper() + " " + Utility.ConvertToUnsign(input.TenSanPham.ToLower());
                product.UrlImage = UploadFiles.SaveImage(input.hinhanh);
                //product.Filter = tensanpham.ToLower() + " " + mota.ToLower() + " " + Utility.ConvertToUnsign(mota.ToLower());
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            // return Redirect("/Product/Index")-sẽ đi đến đường dẫn trong "" sau khi xong
        }

        //public IActionResult Them(string tensanpham, string mota, decimal gia, IFormFile hinhanh)
        //{


        //     //Guid id = Guid.NewGuid();
        //    if (!string.IsNullOrEmpty(tensanpham))
        //    {
        //        Product product = new Product();
        //        product.Id = Guid.NewGuid().ToString();
        //        product.TenSanPham = tensanpham;
        //        product.Mota = mota;
        //        product.Gia = gia;
        //        product.Filter = tensanpham.ToLower() + " " + tensanpham.ToUpper() + " " + mota.ToLower() + " " + mota.ToUpper() + " " + Utility.ConvertToUnsign(tensanpham.ToLower());
        //        product.UrlImage = UploadFiles.SaveImage(hinhanh);
        //        //product.Filter = tensanpham.ToLower() + " " + mota.ToLower() + " " + Utility.ConvertToUnsign(mota.ToLower());
        //        _context.Products.Add(product);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //     // return Redirect("/Product/Index")-sẽ đi đến đường dẫn trong "" sau khi xong
        //}
        public IActionResult Capnhat(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Capnhat(string id, string tensanpham, string mota, decimal gia)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            item.TenSanPham = tensanpham;
            item.Mota = mota;
            item.Gia = gia;
            _context.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Xoa(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Chitiet(string id)
        {
            var products = _context.Products.FirstOrDefault(c => c.Id == id);
            return View(products);
        }
    }
    }
