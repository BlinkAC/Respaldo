using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Respaldo.Models;
using Respaldo.Services;
using Respaldo.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Respaldo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        // GET: api/<NorthController>
        new ProductsS prodS = new ProductsS();
        [HttpGet]
        public List<Product> GetProducts()
        {
            var products = prodS.GetAllProducts().Select(s => new Product { 
            ProductName = s.ProductName,
            ProductId = s.ProductId,
            QuantityPerUnit = s.QuantityPerUnit,
            UnitPrice = s.UnitPrice,
            Category = s.Category}).ToList();
            return products;
        }

        // GET api/<NorthController>/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = prodS.GetProductId(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
        

        // POST api/<NorthController>
        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductDto newProduct)
        {
            prodS.AddProduct(newProduct);
            return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            prodS.DeleteProduct(id);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePut(int id, string name)
        {
            prodS.UpdateProductName(id, name);
            return Ok();
        }

    }
}
