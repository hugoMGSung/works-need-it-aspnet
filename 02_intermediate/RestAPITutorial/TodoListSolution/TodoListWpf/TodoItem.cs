using System.ComponentModel.DataAnnotations;

namespace TodoListWpf
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsComplete { get; set; }
    }
}
