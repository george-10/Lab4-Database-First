using System;
using System.Collections.Generic;

namespace Lab4.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
