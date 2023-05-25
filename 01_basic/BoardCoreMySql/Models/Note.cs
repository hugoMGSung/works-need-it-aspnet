using System.ComponentModel.DataAnnotations;

namespace BoardCoreMySql.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        public int ReadCount { get; set; }

        public DateTime PostDate { get; set; }

        public string Contents { get; set; }
    }
}
