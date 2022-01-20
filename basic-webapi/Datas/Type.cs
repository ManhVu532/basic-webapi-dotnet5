using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace basic_webapi.Datas
{
    [Table("Type")]
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> products { get; set; }
    }
}
