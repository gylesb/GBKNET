using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBKNet.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}