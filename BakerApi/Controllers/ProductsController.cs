using BakerApi.Context;
using BakerApi.Dto;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BakerContext _context;
        public ProductsController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet("with_category")]
        public IActionResult GetProductWithCategory()
        {
            var product = _context.Products.Include(p => p.Category).Select(p => new ProductWithCategoryDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                ImageUrl = p.ImageUrl,
                CategoryName = p.Category != null ? p.Category.CategoryName : null
            }).ToList();
            return Ok(product);
        }

        [HttpGet("CountProduct")]
        public IActionResult GetCountProduct()
        {
            var totalProduct = _context.Products.Count();
            return Ok(totalProduct);

        }
    }
}