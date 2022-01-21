using basic_webapi.Datas;
using basic_webapi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace basic_webapi.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public ProductResponse Create(ProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Id = Guid.NewGuid(),
                Desc = request.Desc,
                UnitPrice = request.UnitPrice
            };
            _context.Add(product);
            _context.SaveChanges();
            return new ProductResponse
            {
                Name = request.Name,
                Id = Guid.NewGuid(),
                Desc = request.Desc,
                UnitPrice = request.UnitPrice
            };
        }

        public List<ProductResponse> FindAll(string search, double? from, double? to, string? sortBy, int? limit, int? page)
        {
            var products = _context.Products.Include(p => p.Type ).AsQueryable();

            #region Filter
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.Contains(search));
            };
            if (from.HasValue)
            {
                products = products.Where(p => p.UnitPrice >= from);
            }

            if (to.HasValue)
            {
                products = products.Where(p => p.UnitPrice <= to);
            }
            #endregion

            #region Sorting
            products = products.OrderBy(hh => hh.Name);

            if(!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc":
                        products = products.OrderByDescending(p => p.Name);
                        break;
                    case "name_asc":
                        products = products.OrderBy(p => p.Name);
                        break;
                    case "price_desc":
                        products = products.OrderByDescending(p => p.UnitPrice);
                        break;
                    case "price_asc":
                        products = products.OrderBy(p => p.UnitPrice);
                        break;
                }
            }
            #endregion

            #region Paging
            //products = products.Skip((page-1)*limit).Take(limit);
            #endregion
            //var result = products.Select(p => new ProductResponse(p));
            var result = PaginatedList<Product>.Create(products, limit ?? 5, page ?? 1);
            return result.Select(h => new ProductResponse(h)).ToList();
        }

        
    }
}
