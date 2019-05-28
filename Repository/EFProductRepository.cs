using CoreDBApp.Interface;
using CoreDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDBApp.Repository
{
    public class EFProductRepository : IProduct
    {
        private Context context;
        public EFProductRepository(Context _context)
        {
            context = _context;
        }
        public IQueryable<Product> Products => context.Products;

        public bool AddProduct(Product product)
        {
            context.Products.Add(product);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProduct(int Id)
        {
            var product = GetById(Id);
            context.Products.Remove(product);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product GetById(int Id)
        {
            return context.Products.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Product> GetFilterProducts(int? Id, string Name, string Description, float? Price)
        {
            IQueryable<Product> query = null;

            if (Id != null)
            {
                query = query.Where(x => x.Id == Id);
            }
            if (Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(Name.ToLower()));
            }
            if (Description != null)
            {
                query = query.Where(x => x.Description.ToLower().Contains(Description.ToLower()));
            }
            if (Price != null)
            {
                query = query.Where(x => x.Price >= Price);
            }
            return query.ToList();
        }

        //public List<Product> ProductsList()
        //{

        //}

        //public IEnumerable<Product> GetFilterProducts(int Id, string Name, string Description, float? Price = null)
        //{
        //    throw new NotImplementedException();
        //}

        public bool UpdateProduct(Product product)
        {
            var productOld = GetById(product.Id);
            productOld.Name = product.Name;
            productOld.Description = product.Description;
            productOld.Price = product.Price;
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
