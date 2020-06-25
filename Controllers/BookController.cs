using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplicationRazor.Models;

namespace WebApplicationRazor.Controllers
{
  [ApiController]
  [Route("api/v1/book")]
  public class BookController : Controller
  {
    private readonly ApplicationDbContext _db;

    public BookController(ApplicationDbContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
      return Json(new
      {
        data = await _db.Book.ToListAsync()
      });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBook(int id)
    {
      var bookFromDb = await _db.Book.FindAsync(id);

      if (bookFromDb == null)
      {
        return Json((new
        {
          success = false,
          message = "Error while deleting book."
        }));
      }

      _db.Book.Remove(bookFromDb);
      await _db.SaveChangesAsync();

      return Json(new
      {
        success = true,
        message = "Delete successful."
      });
    }
  }
}