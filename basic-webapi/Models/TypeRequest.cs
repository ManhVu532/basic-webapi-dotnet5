using System.ComponentModel.DataAnnotations;

namespace basic_webapi.Models
{
    public class TypeRequest
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
