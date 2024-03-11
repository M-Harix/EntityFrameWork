using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LibraryManagementSystem.Models;

public partial class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Phone { get; set; }
    public List<Checkouts>? Checkouts { get; set; }
}