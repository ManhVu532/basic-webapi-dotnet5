using basic_webapi.Datas;
using basic_webapi.Models;
using basic_webapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace basic_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult FindAll(string searh, double? from, double? to, string? orderBy, int limit = 5, int page = 1)
        {
            try
            {
                var result =  _repository.FindAll(searh, from, to, orderBy, limit, page);
                return Ok(result);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(ProductRequest request)
        {
            try
            {
                var res = _repository.Create(request);
                return Ok(res);
            }catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
