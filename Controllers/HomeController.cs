using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDBApp.Interface;
using CoreDBApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDBApp.Controllers
{
    public class HomeController : Controller
    {
        private IProduct repo;

        public HomeController(IProduct _repo)
        {
            repo = _repo;
        }
        public IActionResult Index(string search)
        {
            var productList = repo.Products;
            if (!String.IsNullOrEmpty(search))
            {
                productList = productList.Where(s => s.Id.ToString().Contains(search)|| s.Name.Contains(search) || s.Description.Contains(search) || s.Price.ToString().Contains(search));
            }
            return View(productList);
        }

        //[HttpPost]
        //public IActionResult Index(string search)
        //{
        //    var productList = repo.Products;
        //    if (!String.IsNullOrEmpty(search))
        //    {
        //        productList = productList.Where(s => s.Name.Contains(search));
        //    }
        //    return View(productList);
        //}
    }
}