using System;
using System.Collections.Generic;

namespace LibraryProject.Models;

public partial class LoanBook
{
    public int Id { get; set; }

    public string StarDate { get; set; } = null!;

    public string ReturnDate { get; set; } = null!;

    public int PersonsId { get; set; }

    public int BooksId { get; set; }

    public virtual Book Books { get; set; } = null!;
}
