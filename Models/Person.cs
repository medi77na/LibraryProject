using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace LibraryProject.Models;

public partial class Person
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full name is required")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Type of document is required")]
    public string TypeOfDocument { get; set; } = null!;

    [Required(ErrorMessage = "Document number is required")]
    public string DocumentNumber { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required")]
    public string PhoneNumber { get; set; } = null!;

    public int RolesId { get; set; }

    public virtual Role? Roles { get; set; }
}