using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBKNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBKNet.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewRepository reviewRepo;

		private IProductRepository productRepo = new EFProductRepository();

		public ReviewController(IReviewRepository repo = null)
		{
			if (repo == null)
			{
				this.reviewRepo = new EFReviewRepository();
			}
			else
			{
				this.reviewRepo = repo;
			}
		}

        public IActionResult Index()
        {
          return View(reviewRepo.Reviews.ToList());
        }

		public IActionResult Create(int id)
		{
			var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
			ViewBag.product = thisProduct;
			return View();
		}

		[HttpPost]
		public IActionResult Create(Reviews review)
		{
			reviewRepo.Save(review);
			return RedirectToAction("Details", "Product", new { id = review.ProductId });
		}

		public IActionResult Edit(int id)
		{
			var thisReview = reviewRepo.Reviews.FirstOrDefault((Review => Review.ReviewId == id));

			var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == thisReview.ProductId);
			ViewBag.product = thisProduct;

			return View(thisReview);
		}

		[HttpPost]
		public IActionResult Edit(Reviews Review)
		{

			reviewRepo.Edit(Review);
			return RedirectToAction("Details", "Product", new { id = Review.ProductId });
		}

		public IActionResult Delete(int id)
		{
			var thisReview = reviewRepo.Reviews.FirstOrDefault(Review => Review.ReviewId == id);
			return View(thisReview);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisReview = reviewRepo.Reviews.FirstOrDefault(Review => Review.ReviewId == id);
			reviewRepo.Remove(thisReview);
			return RedirectToAction("Details", "Product", new { id = thisReview.ProductId });
		}

		public IActionResult Details(int ReviewId)
		{
			var thisReview = reviewRepo.Reviews
			.FirstOrDefault(x => x.ReviewId == ReviewId);

			return View(thisReview);
		}
	}
}