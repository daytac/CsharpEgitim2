using CsharpEgitim2.DataAccessLayer.Abstract;
using CsharpEgitim2.DataAccessLayer.Context;
using CsharpEgitim2.DataAccessLayer.Repositories;
using CsharpEgitim2.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitim2.DataAccessLayer.EntityFramework
{
    public class EfPRoductDal : GenericRepository<Product>, IProductDal
    {
        public List<object> GetProductsWithCategory()
        {
            var context = new KampContext();
            var values = context.Products
               .Select(x => new
               {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductStock = x.ProductStock,
                    ProductPrice = x.ProductPrice,
                    ProductDescription = x.ProductDescription,
                    CategoryName = x.Category.CategoryName
               }).ToList();

            return values.Cast<object>().ToList();
        }
    }
}
