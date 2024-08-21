using System;
using System.Collections.Generic;

namespace LibraryProject.Database;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public string Category { get; set; } = null!;

    public sbyte Available { get; set; }

    public virtual ICollection<LoanBook> LoanBooks { get; set; } = new List<LoanBook>();
}
