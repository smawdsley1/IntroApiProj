using System.ComponentModel.DataAnnotations.Schema;

namespace moontest1.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? UserEntraId {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [ForeignKey("Role")]
        // Roles are already set in the db table, when you're giving a role to someone you won't 
        // enter "Admin", "User" everytime. You will instead just state RoleId = 1, 2, etc. 
        public long RoleId { get; set; }
        // Navigation property that lets you access the Role object related to this user.
        // For example, user.Role.Name could return "Admin" if this user has the Admin role.
        public Role Role { get; set; }
    }
}