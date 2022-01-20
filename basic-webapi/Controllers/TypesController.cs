using basic_webapi.Datas;
using basic_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Type = basic_webapi.Datas.Type;

namespace basic_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TypesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var types = _context.Types.ToList();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var type = _context.Types.SingleOrDefault(t => t.Id == id);
            if (type == null)
            {
                return NotFound();
            }
            return Ok(type);
        }

        [HttpPost]
        public IActionResult Create(TypeRequest request)
        {
            try
            {
                var type = new Type
                {
                    Name = request.Name
                };
                _context.Add(type);
                _context.SaveChanges();

                return Ok(type);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TypeRequest request)
        {
            try
            {
                Type t = _context.Types.SingleOrDefault(t => t.Id == id);
                if (t == null)
                {
                    return NotFound();
                }
                t.Name = request.Name;
                _context.SaveChanges();

                return Ok(t);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Type t = _context.Types.SingleOrDefault(t => t.Id == id);
                if (t == null)
                {
                    return NotFound();
                }

                _context.Entry(t).State = EntityState.Deleted;
                _context.SaveChanges();
                return Ok(t);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    } 
}
