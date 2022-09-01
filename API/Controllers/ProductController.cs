using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{

    private ProductRepository _productRepository;
    private ProductValidator _productValidator;
    
    public ProductController(ProductRepository repository)
    {
        _productRepository = repository;
        _productValidator = new ProductValidator();
    }

    [HttpGet]
    public List<Product> GetProducts()
    {
        return _productRepository.GetAllProducts();
    }

    [HttpPost]
    public ActionResult CreateNewProduct(Product product)
    {
        var validation = _productValidator.Validate(product);
        if (validation.IsValid)
        {
            return Ok(_productRepository.InsertProduct(product));
        }
        return BadRequest(validation.ToString());
    }

    [HttpGet]
    [Route("CreateDB")]
    public string CreateDB()
    {
        _productRepository.CreateDB();
        return "Db has been created";
    }
    
}