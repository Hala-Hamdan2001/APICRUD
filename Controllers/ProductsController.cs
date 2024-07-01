using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session1.Models;

namespace Session1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product> { 
            new Product { Id = 1, Name = "brush", Description = "this is brush"},
            new Product { Id = 2, Name = "spoon", Description = "this is spoon"},
            new Product { Id = 3, Name = "chair", Description = "this is chair"},
        };
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet("get")]
        public IActionResult All()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var product = products.First(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Add(Product request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            products.Add(product);
            return Ok(products);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product request)
        {
            var CurrentProduct = products.FirstOrDefault (product => product.Id == id);
            if (CurrentProduct == null)
            {
                return NotFound();
            }
            CurrentProduct.Name = request.Name;
            CurrentProduct.Description = request.Description;
            return Ok(CurrentProduct);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if(product == null)
                return NotFound();

            products.Remove(product);
            return Ok ();
        }
    }
}
