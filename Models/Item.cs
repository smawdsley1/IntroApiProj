namespace moontest1.Models
{
    public class Item
    {
        public long ItemId{ get; set; }
        public long UserId { get; set; }
        public long CategoryId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int IsActive { get; set; }


    }
}
