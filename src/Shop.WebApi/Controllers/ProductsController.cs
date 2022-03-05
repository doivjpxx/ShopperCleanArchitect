using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationCore.DTOs;
using Shop.ApplicationCore.Exceptions;
using Shop.ApplicationCore.Interfaces;

namespace Shop.WebApi.Controllers;

[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public ActionResult<List<ProductResponse>> GetProducts()
    {
        return Ok(_productRepository.GetProducts());
    }

    [HttpGet("{id}")]
    public ActionResult GetProductById(int id)
    {
        try
        {
            var product = _productRepository.GetProductById(id);
            return Ok(product);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult Create([FromBody] CreateProductRequest productRequest)
    {
        var product = _productRepository.CreateProduct(productRequest);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] UpdateProductRequest productRequest)
    {
        try
        {
            var product = _productRepository.UpdateProduct(id, productRequest);
            return Ok(product);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            _productRepository.DeleteProductById(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
