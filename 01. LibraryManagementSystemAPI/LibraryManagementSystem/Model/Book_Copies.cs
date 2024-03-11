using System.Reflection.Metadata;

namespace LibraryManagementSystem.Models
{
    public class Book_Copies
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public string Status { get; set; } = null!; // available or borrowed
        public DateOnly Due_Date { get; set; }
        public Checkouts? Checkouts { get; set; }
    }
}
