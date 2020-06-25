﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplicationRazor.Models;

namespace WebApplicationRazor.Pages.BookList
{
  public class EditModel : PageModel
  {
    private readonly ApplicationDbContext _db;

    public EditModel(ApplicationDbContext db)
    {
      _db = db;
    }

    [BindProperty] public Book Book { get; set; }

    public async Task OnGet(int id)
    {
      Book = await _db.Book.FindAsync(id);
    }

    public async Task<IActionResult> OnPost()
    {
      if (ModelState.IsValid)
      {
        var bookFromDb = await _db.Book.FindAsync(Book.Id);
        bookFromDb.Name = Book.Name;
        bookFromDb.Author = Book.Author;
        bookFromDb.ISBN = Book.ISBN;
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
      }

      return Page();
    }
  }
}