using System;
using System.Collections.Generic;
namespace LibraryProject.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string TypeOfDocument { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;
 
    public string Password { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int RolesId { get; set; }

    public virtual Role Roles { get; set; } = null!;
}
