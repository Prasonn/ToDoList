using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListProj01.Models
{
    [Table("ToDoListTbl")]
    public class TodoList
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int clientId {  get; set; }
        
    }
}
