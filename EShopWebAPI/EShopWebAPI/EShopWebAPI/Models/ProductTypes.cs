using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopWebAPI.Models
{
    public class ProductTypes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public string ProductType { get; set; }

    }
}
