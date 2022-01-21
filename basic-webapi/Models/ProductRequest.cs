using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basic_webapi.Models
{
    public class ProductRequest
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Desc { get; set; }
        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }
    }
}
