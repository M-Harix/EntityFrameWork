using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Models
{
    public class Fine
    {
        public int Id { get; set; }
        public int CheckoutsId { get; set; }
        [JsonIgnore]
        public Checkouts? Checkouts { get; set; }
        public int Fine_Amount { get; set; }
        public DateOnly Fine_Date { get; set; }
        public string status { get; set; } // Paid or Unpaid
    }
}