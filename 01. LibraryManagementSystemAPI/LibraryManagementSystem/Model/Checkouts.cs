using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Models
{
    public class Checkouts
    {
        public int Id { get; set; }
        public int CopyId { get; set; }
        [JsonIgnore]
        public Book_Copies? Book_Copies { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public DateOnly Checkout_Date { get; set; }
        public DateOnly Return_Date { get; set; }
        public DateOnly Due_Date { get; set; }
        public Fine? Fine { get; set; }
    }
}
