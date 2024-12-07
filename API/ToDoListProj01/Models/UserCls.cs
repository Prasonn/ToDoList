using System.ComponentModel.DataAnnotations;

namespace ToDoListProj01.Models
{
    public class UserCls
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; } 
    }
}
