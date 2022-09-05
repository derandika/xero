using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Xero.Domain.Models;
using Xero.Repository.Interface;

namespace Xero.Api.Controllers
{
    /// <summary>
    /// Product Option Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionController : ControllerBase
    {
        private readonly ILogger<ProductOptionController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// constrcutor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public ProductOptionController(
            ILogger<ProductOptionController> logger,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Get Options for given product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOptions(int productId)
        {
            var product = _unitOfWork.Products.Get(productId);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ProductOptions);
        }

        /// <summary>
        /// Create product option 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productOption"></param>
        /// <returns></returns>
        [Route("{productId:int}/options")]
        [HttpPost]
        public async Task<IActionResult> CreateProductOption(int productId, ProductOption productOption)
        {
            if (ModelState.IsValid)
            {
                productOption.ProductId = productId;
                _unitOfWork.ProductOptions.Add(productOption);
                _unitOfWork.Complete();

                return CreatedAtAction("GetOptions", new { productId }, productOption);
            }

            return new JsonResult("Invalid Product Option Data") { StatusCode = 500 };
        }


        /// <summary>
        /// Update Product Option
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="productOption"></param>
        /// <returns></returns>
        [HttpPut("{productId:int}/options/{id:int}")]
        public async Task<IActionResult> UpdateProductOption(int productId, int id, ProductOption productOption)
        {
            var product = _unitOfWork.Products.Get(productId);

            if (product == null)
            {
                return NotFound();
            }

            var productOptionItem = product.ProductOptions.FirstOrDefault(x => x.Id == id);

            if (productOptionItem == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductOptions.Update(productOption);
            _unitOfWork.Complete();

            return NoContent();
        }

        /// <summary>
        /// Delete Product Option
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductOption(int id)
        {
            var productOption = _unitOfWork.ProductOptions.Get(id);

            if (productOption == null)
            {
                return BadRequest();
            }

            _unitOfWork.ProductOptions.Remove(productOption);
            _unitOfWork.Complete();

            return Ok(productOption);

        }
    }
}
