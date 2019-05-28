using CoreDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDBApp.Interface
{
    public interface IProduct
    {
        IQueryable<Product> Products { get; }
        Product GetById(int Id);
        bool AddProduct(Product product);
        bool DeleteProduct(int Id);
        bool UpdateProduct(Product product);
        IEnumerable<Product> GetFilterProducts(int? Id,string Name, string Description,float? Price);
        //List<Product> ProductsList();
    }
}
