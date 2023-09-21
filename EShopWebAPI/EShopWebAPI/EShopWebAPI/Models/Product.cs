using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopWebAPI.Models
{
     public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Product Type")]
        [Required]
        [ForeignKey("ProductTypeId")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Special Tag")]
        [Required]
        [ForeignKey("SpecialTagId")]

        public int SpecialTagId { get; set; }

        //public virtual SpecialTag SpecialTag { get; set; }

        //public virtual List<ProductTypes> ProductType { get; set; }
        //public virtual List<SpecialTag> SpecialTags { get; set; }

    }
}
