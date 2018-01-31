using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GBKNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GBKNet.Controllers
{
    public class ProductController : Controller
    {

		private IProductRepository productRepo;

        private GBKNetContext db = new GBKNetContext();

		public ProductController(IProductRepository repo = null)
		{
			if (repo == null)
			{
				this.productRepo = new EFProductRepository();
			}
			else
			{
				this.productRepo = repo;
			}
		}


        public ViewResult Index()
        {
            return View(db.Products.Include(products => products.Category).ToList());
        }

        public IActionResult Details(int ProductId)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == ProductId);
            return View(thisItem);
        }

        public IActionResult Create()
        {
            ViewBag.productId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ProductId)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == ProductId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int ProductId)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == ProductId);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ProductId)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == ProductId);
            db.Products.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
