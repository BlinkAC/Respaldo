using Respaldo.DTOs;
using Respaldo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Respaldo.Services
{
    public class ProductsS : DBS
    {
        
        public Product GetProductId(int id)
        {
            return GetAllProducts().Where(w => w.ProductId == id).FirstOrDefault();
        }

        public IQueryable<Product> GetAllProducts()
        {          
            
            return dataContext.Products.Select(s => s);
        }

        public void AddProduct(ProductDto newProduct)
        {
            var newproduct = new Product() {
                ProductName = newProduct.Name,
                QuantityPerUnit = newProduct.Quantity,
                UnitPrice = newProduct.Price
            };

            dataContext.Products.Add(newproduct);
            dataContext.SaveChanges();
        }

        public void UpdateProductName(int id, string name)
        {
            var product = GetAllProducts().Where(w => w.ProductId == id).FirstOrDefault();
            if (product != null)
            {
                product.ProductName = name;
                dataContext.SaveChanges();
            }
        }
        public void DeleteProduct(int id)
        {
            
            var product = GetProductId(id);
            dataContext.Products.Remove(product);
            dataContext.SaveChanges();
        }

 
    }
}
