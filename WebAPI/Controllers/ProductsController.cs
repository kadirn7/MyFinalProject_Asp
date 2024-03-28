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
        

        [HttpGet]
        public List<Product> Get()
        {
            var result=_productService.GetAll();
            return result.Data;

            //Dependency chain-- Bagımlılık zinciri
            //IProductService productService = new ProductManager(new EfProductDal());
            //var result = productService.GetAll();
            //return result.Data;
           
        }
    }
}
