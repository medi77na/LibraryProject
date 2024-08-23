using System;
using System.Collections.Generic;

namespace LibraryProject.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
