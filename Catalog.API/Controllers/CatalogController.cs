using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public CatalogController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetById")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("[action]/{category}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return BadRequest("Invalid Category!");
            }

            var products = await _repository.GetByCategoryAsync(category);

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            if (product is null)
            {
                return BadRequest("Invalid Product!");
            }

            await _repository.CreateAsync(product);

            return CreatedAtRoute("GetById", new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Update(Product product)
        {
            if (product is null)
            {
                return BadRequest("Invalid product!");
            }
            return Ok(await _repository.UpdateAsync(product));
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteById(string id)
        {
            return Ok(await _repository.DeleteAsync(id));
        }
    }
}