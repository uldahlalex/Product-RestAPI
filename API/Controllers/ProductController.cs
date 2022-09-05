using API.DTOs;
using AutoMapper;
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
    private readonly IMapper _mapper;
    
    public ProductController(ProductRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = repository;
        _productValidator = new ProductValidator();
    }

    [HttpGet]
    public List<Product> GetProducts()
    {
        return _productRepository.GetAllProducts();
    }

    [HttpPost]
    public ActionResult CreateNewProduct(PostProductDTO dto)
    {
        var validation = _productValidator.Validate(dto);
        Product prod = _mapper.Map<Product>(dto);
        if (validation.IsValid)
        {
            return Ok(_productRepository.InsertProduct(prod));
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