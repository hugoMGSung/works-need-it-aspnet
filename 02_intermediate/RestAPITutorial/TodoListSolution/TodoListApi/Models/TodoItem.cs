using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Models
{
    public class TodoItem
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? IsComplete { get; set; }
    }
}
