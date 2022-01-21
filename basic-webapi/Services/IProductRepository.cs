using basic_webapi.Models;
using System.Collections.Generic;

namespace basic_webapi.Services
{
    public interface IProductRepository
    {
        List<ProductResponse> FindAll(string search, double? from, double? to, string? sortBy, int? limit, int? page);
        ProductResponse Create(ProductRequest request);
    }
}
