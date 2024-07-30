using System.Data.Common;
using Lab4.Models;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LibraryController : ODataController
{

    private readonly ILogger<LibraryController> _logger;
    private readonly LibrarydbContext _context;
    public LibraryController(ILogger<LibraryController> logger, LibrarydbContext context )
    {
        _logger = logger;
        _context = context;
    }


    [EnableQuery]
    public IQueryable<Book> GetBooks()
    {
        return _context.Books.AsQueryable();
    }

    [EnableQuery]
    public IQueryable<Loan> GetLoans()
    {
        var filteredLoans = _context.Loans.Where(loan => loan.ReturnDate <DateOnly.FromDateTime(DateTime.Now));
    Console.WriteLine(DateTime.Now);
        return filteredLoans.AsQueryable();
    }
    
    [EnableQuery]
    public IQueryable<Author> GetAuthors()
    {
        var authors = _context.Authors.AsQueryable().Include(x =>x.Country);

        return authors;
    }
    
    [HttpGet]
    [EnableQuery]
    public ActionResult<List<Book>> getBookPage([FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var books = (from book in _context.Books
                select book)
            .Skip(pageSize*(pageNumber-1))
            .Take(pageSize)
            .ToList();
        return Ok(books);
    }
}
