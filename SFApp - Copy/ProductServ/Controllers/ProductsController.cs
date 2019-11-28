using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServ.Models;
using ProductServ.Services;

namespace ProductServ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IService<Product, Guid> service;
        public ProductsController(IService<Product,Guid> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var res = await service.GetAsync();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Product product)
        {
            product.ProductId = Guid.NewGuid();
            var res = await service.CreateAsync(product);
            return Ok(res);
        }
    }
}