using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moontest1.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public long RoleId { get; set; }
        public string RoleName { get; set; }   
    }
}
