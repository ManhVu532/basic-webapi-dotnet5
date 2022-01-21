using basic_webapi.Datas;
using System;

namespace basic_webapi.Models
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double UnitPrice { get; set; }
        public basic_webapi.Datas.Type Type { get; set; }

        public ProductResponse(Product product)
        {
            Name = product.Name;
            Desc = product.Desc;
            UnitPrice = product.UnitPrice;
            Type = product.Type;
        }
        public ProductResponse()
        {

        }
    }
}
