using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        //Loosely coupled gevşek bağlılık.
        //naming convertion
        //IoC Container -->Inversion of Control
        
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        

        [HttpGet("getall")]
        public IActionResult Getall()
        {
            //Swagger
            var result=_productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

            //Dependency chain-- Bagımlılık zinciri
            //IProductService productService = new ProductManager(new EfProductDal());
            //var result = productService.GetAll();
            //return result.Data;
            

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        
        [HttpPost("add")]
        //Post requestlerde sana veri vermesi gerekiyor veri göstermesi gerekmiyor.
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            } 
            return BadRequest();    
        }
    }
}
