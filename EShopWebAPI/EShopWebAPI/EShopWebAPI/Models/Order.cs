using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShopWebAPI.Models
{
    public class Order
    {
        public Order()
        {
            CartDetails = new List<CartDetails>();
        }
        public int Id { get; set; }
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual List<CartDetails> CartDetails { get; set; }
    }
}
