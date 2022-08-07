using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class EntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
