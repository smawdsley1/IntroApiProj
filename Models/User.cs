namespace moontest1.Models
{
    public class User
    {
        // Testing git time 2
        public long UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string UserEntraId {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
