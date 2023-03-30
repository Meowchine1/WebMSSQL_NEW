using System.ComponentModel.DataAnnotations;

namespace WebMSSQL.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public int Key { get; set; }
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Article { get; set; }

        public Categories(int key, string name, string? description, string? article)
        {
            Key = key;
            Name = name;
            Description = description;
            Article = article;
        }

        public Categories()
        {
        }
    }

}
