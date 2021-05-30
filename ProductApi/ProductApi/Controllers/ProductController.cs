using ProductApi.Models;
using ProductApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IproductRepository _productRepository;

        public ProductController(IproductRepository ProductRepository)
        {
            _productRepository =ProductRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<products>> GetBooks()
        {
            return await _productRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<products>> GetBooks(int id)
        {
            return await _productRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<products>> PostBooks([FromBody] products product)
        {
            var newProduct= await _productRepository.Create(product);
            return CreatedAtAction(nameof(GetBooks), new { id = newProduct.id }, newProduct);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] products product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            await _productRepository.Update(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelete = await _productRepository.Get(id);
            if (productToDelete == null)
                return NotFound();

            await _productRepository.Delete(productToDelete.id);
            return NoContent();
        }
    }
}
