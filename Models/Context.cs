using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDBApp.Models
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
