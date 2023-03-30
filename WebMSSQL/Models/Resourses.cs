using Lombok.NET;
using System.ComponentModel.DataAnnotations;

namespace WebMSSQL.Models
{
    public class Resourses
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
        public string name { get; set; }
        public string description { get; set; }
        public int CategoryId { get; set; }
        public string path { get; set; }

        public Resourses(string name, string description, int categoryId, string path)
        {
            this.name = name;
            this.description = description;
            CategoryId = categoryId;
            this.path = path;
        }

        public Resourses()
        {
        }
    }
}
