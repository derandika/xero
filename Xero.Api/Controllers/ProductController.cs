using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Xero.Domain.Models;
using Xero.Repository.Interface;

namespace Xero.Api.Controllers
{
    /// <summary>
    /// product controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public ProductController(
            ILogger<ProductController> logger,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = _unitOfWork.Products.GetAll().ToList();

            return Ok(products);
        }


        /// <summary>
        /// Find products by product name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> FindByName(string name)
        {
            var product = _unitOfWork.Products.Find(x => x.Name == name).FirstOrDefault();
           
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        /// <summary>
        /// Get products by product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = _unitOfWork.Products.Get(id);

            return Ok(product);
        }

        /// <summary>
        /// Create product instance
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Add(product);
                _unitOfWork.Complete();

                return CreatedAtAction("GetProduct", new { product.Id }, product);
            }

            return new JsonResult("Invalid Product Data") { StatusCode = 500 };
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var productItem = _unitOfWork.Products.Get(id);
            
            if (productItem == null)
            {
                return NotFound();
            }

            _unitOfWork.Products.Update(product);
            _unitOfWork.Complete();

            return NoContent();
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _unitOfWork.Products.Get(id);

            if (product == null)
            {
                return BadRequest();
            }

            _unitOfWork.Products.Remove(product);
            _unitOfWork.Complete();

            return Ok(product);
        }


    }
}
