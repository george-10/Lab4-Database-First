﻿using System;
using System.Collections.Generic;

namespace Lab4.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public string? Isbn { get; set; }

    public DateOnly? PublishedYear { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
