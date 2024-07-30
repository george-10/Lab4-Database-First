using System;
using System.Collections.Generic;

namespace Lab4.Models;

public partial class Borrower
{
    public int BorrowerId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
