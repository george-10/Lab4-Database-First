using System;
using System.Collections.Generic;

namespace Lab4.Models;

public partial class Popularbook
{
    public long? Count { get; set; }

    public int? BookId { get; set; }

    public string? Title { get; set; }

    public DateOnly? PublishedYear { get; set; }

    public int? AuthorId { get; set; }

    public string? Isbn { get; set; }
}
