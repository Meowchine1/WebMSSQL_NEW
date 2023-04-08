using Lombok.NET;

namespace WebMSSQL.Models
{

    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class ChatMessages
    {
        public int Id { get; set; }
        public int? IdCategory { get; set; }
        public string? Name { get; set; }
        public string Text { get; set; }
        public DateTime dateTime { get; set; }
    }
}
