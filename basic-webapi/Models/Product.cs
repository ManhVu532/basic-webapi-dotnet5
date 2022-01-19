using System;

namespace basic_webapi.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
    }

    public class ProductRequest
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
    }
}
