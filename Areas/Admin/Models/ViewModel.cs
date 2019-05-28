using CoreDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDBApp.Areas.Admin.Models
{
    public class ViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public FilterModel filter = new FilterModel();
        //public IEnumerable<Product> Products { get; set; }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public float Price { get; set; }
    }
}
