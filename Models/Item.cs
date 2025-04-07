using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroAPIProject.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public Int64 ItemId { get; set; }
        [ForeignKey("User")]
        public Int64? UserId { get; set; }
        [ForeignKey("Category")]
        public Int64? CategoryId { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
