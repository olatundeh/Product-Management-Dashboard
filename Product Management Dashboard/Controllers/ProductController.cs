using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Management_Dashboard.Models;

namespace Product_Management_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ProductDbContext _productDbContext) : ControllerBase
    {
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productDbContext.Product.ToListAsync();
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<Product> AddProduct(Product product)
        {
            product.CreatedAt = DateTime.Now;
            await _productDbContext.Product.AddAsync(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        [HttpPatch]
        [Route("UpdateProduct")]
        public async Task<Product> UpdateProduct(Product product)
        {
            _productDbContext.Entry(product).State = EntityState.Modified;
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        [HttpDelete]
        [Route("deleteProduct/{id}")]
        public bool DeleteProduct(int id)
        {
            bool res = false;
            var product = _productDbContext.Product.Find(id);
            if (product != null)
            {
                _productDbContext.Entry(product).State = EntityState.Deleted;
                _productDbContext.SaveChanges();
                res = true;
            }
            return res;
        }

    }

}