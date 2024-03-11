using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Models;

public partial class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Publisher { get; set; }
    public DateOnly Publication_Date { get; set; }
    [JsonIgnore]
    public List<Book_Copies>? Book_Copies { get; set; }
}
