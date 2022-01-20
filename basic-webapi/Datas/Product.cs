using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basic_webapi.Datas
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Desc { get; set; }
        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }

        public int? TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Type Type { get; set; }

    }
}
