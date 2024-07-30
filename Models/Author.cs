using System;
using System.Collections.Generic;

namespace Lab4.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? Name { get; set; }

    public DateOnly BirthDate { get; set; }

    public int CountryId { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Country Country { get; set; } = null!;
}
