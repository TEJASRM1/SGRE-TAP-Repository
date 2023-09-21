using System.ComponentModel.DataAnnotations;

namespace EShopWebAPI.Models
{
    public class SpecialTag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
