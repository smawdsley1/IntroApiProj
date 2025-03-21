namespace moontest1.Models
{
    public class Item
    {
        public long ItemId{ get; set; }
        public long UserId { get; set; }
        public long CategoryId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }


    }
}
