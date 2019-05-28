using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDBApp.Areas.Admin.Models;
using CoreDBApp.Interface;
using CoreDBApp.Models;
using CoreDBApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreDBApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private IProduct repo;

        public HomeController(IProduct _repo)
        {
            repo = _repo;
        }


        public IActionResult Index()
        {
            var productList = repo.Products;
            ViewModel v = new ViewModel();
            v.Products = productList;
            //v.filter = FilterModel;
            //return View(v); yazacaksın.
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repo.AddProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int Id)
        {
            repo.DeleteProduct(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(repo.GetById(Id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Search(int? Id, string Name, string Description, float? Price)
        {
            //ViewModel view = new ViewModel();
            //return View(view.Products);
            var list = repo.GetFilterProducts(Id, Name, Description, Price);
            return View(list);
        }

        //[HttpPost]
        //public IActionResult Search(int? Id, string Name, string Description, float? Price)
        //{
        //    var list = repo.GetFilterProducts(Id, Name, Description, Price);
        //    return View(list);
        //}
    }
}