using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            List<Product> products = (List<Product>) await productRepository.GetAsync();

            if (products == null) return NotFound();

            return products;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Product>> Create([FromBody] ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product newProduct = await productRepository.CreateAsync(product);

            return CreatedAtAction("Get", new { id = newProduct.Id }, newProduct);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await productRepository.DeleteAsync(id);

            if (product == null) NotFound();

            return product;
        }

        [HttpPut("[action]/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Update(int id, [FromBody] ProductDTO product)
        {
            bool ifUpdated = await productRepository.UpdateAsync(id, product);

            if (!ifUpdated) return BadRequest();

            return NoContent();
        }

    }
}
